using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using EzLaunchr.Properties;


namespace EzLaunchr.Scripts
{
    class XMLHandler
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        string filePath = "";

        public XMLHandler()
        {

        }


        public void HandleXMLSave(FlowLayoutPanel panelToUseForButtonSave)
        {
            saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            saveFileDialog.Filter = "xml Files (*.xml)|*.xml";
            saveFileDialog.FilterIndex = 2;
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

            try  //if the user saves a file and does not exit the application
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

        public void HandleXMLLoad(FlowLayoutPanel panelToUseForButtonSave)
        {
            string link = "";
            string description = "";

            filePath = Settings.Default["SaveFilePath"].ToString();

           /*  Keeping those comments for now. Will remove later
            string filePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            filePath += fileName;
            Console.WriteLine(filePath);
            */
            if (File.Exists(filePath))
            {

                XmlTextReader xmlTextReader = new XmlTextReader(filePath);

                while (!xmlTextReader.EOF)
                {


                    if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Link")
                    {
                        link = xmlTextReader.ReadElementContentAsString();
                        Console.WriteLine("reading the Link: " + link);
                    }
                    if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Description")
                    {
                        description = xmlTextReader.ReadElementContentAsString();
                        Console.WriteLine("reading the description: " + description);
                    }

                    if (!String.IsNullOrWhiteSpace(link) && !String.IsNullOrWhiteSpace(description)) //This will not load a button if either the description or the link does not exist.
                    {
                        LinkButton lb = new LinkButton(link, description);
                        panelToUseForButtonSave.Controls.Add(lb);
                        link = String.Empty;
                        description = String.Empty;
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



    }
}
