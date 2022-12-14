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


                XmlWriter xmlWriter = XmlWriter.Create(saveFileDialog.FileName);
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement(string.Empty, "ButtonInfo", string.Empty);

                xmlWriter.WriteString("\n ");

                foreach (LinkButton lb in panelToUseForButtonSave.Controls.OfType<LinkButton>())
                {
                    xmlWriter.WriteStartElement("Link");
                    xmlWriter.WriteString(lb.link);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteString("\n ");

                    xmlWriter.WriteStartElement("Description");
                    xmlWriter.WriteString(lb.displayName.Text);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteString("\n ");

                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();

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


        public void HandleXMLLoad(FlowLayoutPanel panelToUseForButtonSave, bool isCustomPath)
        {
            string filePath="";
            string link = "";
            string description = "";
            bool inDescriptionNode = false;

            if (isCustomPath)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    filePath = openFileDialog.FileName;
            }
            else
                filePath = Settings.Default["SaveFilePath"].ToString();

            if (File.Exists(filePath))
            {
                ClearFlowLayoutPanel(panelToUseForButtonSave); //We only clear the flowLayoutPanel if the user loads a file or on program launch. If he cancels out of the window this part is not reached and the panel is not cleared.

                XmlTextReader xmlTextReader = new XmlTextReader(filePath);

                while (!xmlTextReader.EOF)
                {

                    if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Link")
                    {
                        link = xmlTextReader.ReadElementContentAsString();
                        //Console.WriteLine("reading the Link: " + link +" node:  "+inNode); //enable for debug
                    }
                    
                    if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Description")
                    {
                        inDescriptionNode = true;
                        description = xmlTextReader.ReadElementContentAsString();
                        //Console.WriteLine("reading the description: " + description + " node:  " + inNode); //enable for debug
                    }

                    //This will not load if the link is missing or if we haven't been in the description node yet.
                    if (!String.IsNullOrWhiteSpace(link) && inDescriptionNode) 
                    {
                        LinkButton lb = new LinkButton(link, description);
                        panelToUseForButtonSave.Controls.Add(lb);
                        link = String.Empty;
                        description = String.Empty;
                        inDescriptionNode = false;
                    }
                    try { xmlTextReader.Read(); }
                    catch (System.Xml.XmlException e)
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
