/*
 * This class is responsible for saving and loading the xml file.
 * When the user chooses a save location then the full xml file path is stored in the application settings in order to be loaded on next launch
 * Buttons with no links will not be loaded
 */


using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Reflection;
using EzLaunchr.Properties;
using System.Collections.Generic;

namespace EzLaunchr.Scripts
{
    class XMLHandler
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        string filePath = "";


        public XMLHandler(){ } //empty constructor


        public void HandleXMLSave(FlowLayoutPanel panelToUseForButtonSave)
        {
            saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog.FileName))
                    File.Delete(saveFileDialog.FileName);

                XMLWriterSave(panelToUseForButtonSave,false);
            }

            try  //if the user saves a file
            {
                filePath = Path.GetFullPath(saveFileDialog.FileName); // Get the full path of the save file
                Settings.Default["SaveFilePath"] = filePath; // Update the application property "SaveFilePath" with the full path of the save file
                Settings.Default.Save(); //Save all application properties
                Console.WriteLine("Application properties have saved the following SaveFilePath: " + Settings.Default["SaveFilePath"]);
            }
            catch (System.ArgumentException e) //this happens if the user exits without saving a file
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                Console.WriteLine("Arguments were not specified when saving the application. File will not be saved");
            }

        }


        // We can either specify a custom path or load the last saved XML. Custom path is only specified when the user tries to load an XML after the application has started
        public void HandleXMLLoad(FlowLayoutPanel panelToUseForButtonSave, bool isCustomPath)
        {
            string filePath="";
            string link = "";
            string description = "";
            string imagePath = "";
            int A=0, R=0, G=0, B=0; // Ints that represent values of an argb color that will be used to determine the color of a description label.
            bool inFinalNode = false; // This bool is used to only allow the creation of a LinkButton ONLY when we've read the entries from our last node. If there's no check then a lot of problematic/empty buttons will be created.

            if (isCustomPath) // This bool is set when the method is called.
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    filePath = openFileDialog.FileName;
            }
            else // This is only reached when we load the application
                filePath = Settings.Default["SaveFilePath"].ToString();

            if (String.IsNullOrWhiteSpace(filePath)) // This should only be reached if the user clicks on the Load file button and closes the file dialogue without selecting anything.
                return;

            if (File.Exists(filePath))
            {
                Settings.Default["SaveFilePath"] = filePath; //Setting the default saveFilePath to the latest loaded file
                Settings.Default.Save(); //Save all application properties
                Console.WriteLine("Application properties have saved the following SaveFilePath: " + Settings.Default["SaveFilePath"]);
                ClearFlowLayoutPanel(panelToUseForButtonSave); // We only clear the flowLayoutPanel if the user loads a file or on program launch. If he cancels out of the window this part is not reached and the panel is not cleared.

                XmlTextReader xmlTextReader = new XmlTextReader(filePath);

                while (!xmlTextReader.EOF)
                {

                    if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Link")
                    {
                        link = xmlTextReader.ReadElementContentAsString();
                        //Console.WriteLine("reading the Link: " + link +" node:  "+inFinalNode); //enable for debug
                    }

                    if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Description")
                    {
                        description = xmlTextReader.ReadElementContentAsString();
                        //Console.WriteLine("reading the description: " + description + " node:  " + inFinalNode); //enable for debug
                    }

                    if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "ImagePath")
                    {
                        //inFinalNode = true;
                        imagePath = xmlTextReader.ReadElementContentAsString();
                        //Console.WriteLine("reading the imagepath: " + imagePath + " node:  " + inFinalNode); //enable for debug
                    }

                    if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Color.A")
                    {
                        string a;
                        bool success = int.TryParse(a = xmlTextReader.ReadElementContentAsString(), out A);

                        if (!success)
                            A = 255;

                        //Console.WriteLine("Color.A: "+A); // enable for debug
                    }
                    if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Color.R")
                    {
                        string r;
                        bool success = int.TryParse(r = xmlTextReader.ReadElementContentAsString(), out R);

                        if (!success)
                            R = 255;

                        //Console.WriteLine("Color.R: "+R); // enable for debug
                    }
                    if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Color.G")
                    {
                        string g;
                        bool success = int.TryParse(g = xmlTextReader.ReadElementContentAsString(), out G);

                        if (!success)
                            G = 255;

                        //Console.WriteLine("Color.G: "+G); // enable for debug
                    }
                    if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Color.B")
                    {
                        inFinalNode = true;
                        string b;
                        bool success = int.TryParse(b = xmlTextReader.ReadElementContentAsString(), out B);

                        if (!success)
                            B = 255;

                        //Console.WriteLine("Color.B: "+B); // enable for debug
                    }

                    //This will not load if the link is missing or if we haven't been in the description node yet.
                    if (!String.IsNullOrWhiteSpace(link) && inFinalNode) 
                    {
                        LinkButton lb = new LinkButton(link, description);
                        lb.ChangeBackgroundImage(imagePath);
                        lb.displayName.ForeColor = System.Drawing.Color.FromArgb(A,R,G,B);
                        panelToUseForButtonSave.Controls.Add(lb);
                        link = String.Empty;
                        description = String.Empty;
                        imagePath = String.Empty;
                        inFinalNode = false;
                    }
                    try { xmlTextReader.Read(); }
                    catch (System.Xml.XmlException e) // This error has occured when the user tried to load an empty XML file. 
                    {
                        Console.WriteLine("Exception: " + e.Message + "in file: " + filePath);
                        string messageBoxMessage = "There was a problem loading the file at location: " + filePath + "\nFile might be corrupted or empty. Saves not loaded";
                        MessageBox.Show(messageBoxMessage, "Saves not loaded", MessageBoxButtons.OK);
                        break;
                    }

                }
                xmlTextReader.Close();
            }
            else
            {
                Console.WriteLine("Could not find file at location: " + filePath);
            }
        }



        public void HandleXMLOverwrite(FlowLayoutPanel panelToUseForButtonSave)
        {
            string saveFilePath=Settings.Default["SaveFilePath"].ToString();

            // We can only save if there is a default save path in our settings
            if (File.Exists(saveFilePath))
            {
                XMLWriterSave(panelToUseForButtonSave,true);
                Console.WriteLine("Overwritten file path at: " + saveFilePath);
            }
        }

        // This method can handle both the Saving as new file and overwriting an existing save file
        private void XMLWriterSave(FlowLayoutPanel panelToUseForButtonSave, bool overwriteSave)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            XmlWriter xmlWriter = null;


            // If we don't overwrite our save file then we are picking a save location from a saveFiledialog
            // Otherwise we save at the default save path
            if (!overwriteSave)
                xmlWriter = XmlWriter.Create(saveFileDialog.FileName, settings);
            else if (overwriteSave)
                xmlWriter = XmlWriter.Create(Settings.Default["SaveFilePath"].ToString(), settings);



            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement(string.Empty, "ButtonInfo", string.Empty);



            foreach (LinkButton lb in panelToUseForButtonSave.Controls.OfType<LinkButton>())
            {
                xmlWriter.WriteStartElement("Link");
                xmlWriter.WriteString(lb.link);
                xmlWriter.WriteEndElement();



                xmlWriter.WriteStartElement("Description");
                xmlWriter.WriteString(lb.displayName.Text);
                xmlWriter.WriteEndElement();



                xmlWriter.WriteStartElement("ImagePath");
                xmlWriter.WriteString(lb.imagePath);
                xmlWriter.WriteEndElement();


                xmlWriter.WriteStartElement("Description_Label_ForeColor");



                xmlWriter.WriteStartElement("Color.A");
                xmlWriter.WriteString(lb.displayName.ForeColor.A.ToString());
                xmlWriter.WriteEndElement();



                xmlWriter.WriteStartElement("Color.R");
                xmlWriter.WriteString(lb.displayName.ForeColor.R.ToString());
                xmlWriter.WriteEndElement();



                xmlWriter.WriteStartElement("Color.G");
                xmlWriter.WriteString(lb.displayName.ForeColor.G.ToString());
                xmlWriter.WriteEndElement();


                xmlWriter.WriteStartElement("Color.B");
                xmlWriter.WriteString(lb.displayName.ForeColor.B.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement(); //Description_Label_ForeColor
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }





        //Method used to clear the flowlayout panel off of all the LinkButtons before loading the new xml file that the user specifies
        private void ClearFlowLayoutPanel(FlowLayoutPanel panelToUseForButtonSave)
        {
            //We first create a list will all the LinkButtons present in flowlayoutpanel

            List<LinkButton> listLinkButtons = new List<LinkButton>();

            //Populating the list
            foreach (LinkButton lb in panelToUseForButtonSave.Controls.OfType<LinkButton>())
                listLinkButtons.Add(lb);

            //Disposing each LinkButton 1 by 1
            foreach (LinkButton lb in listLinkButtons)
            {
                lb.UnsbscribeFromAllEvents();
                panelToUseForButtonSave.Controls.Remove(lb);
                lb.Dispose();
            }
        }

    }
}
