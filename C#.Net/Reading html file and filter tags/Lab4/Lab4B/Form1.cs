using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


/// <summary>
///  Program: Read Html file and display html elements
///  Author: Darshil Gajera
///  Date: 10 November, 2022
///  Purpose: Check weather html file has balanced tags or not
/// </summary>

namespace Lab4B
{
    public partial class Form1 : Form
    {
        private string filePath; // file location
        private FileInfo fileInfo; // file data
        private Stack<String> fileTagElements; // to store tags
        private DialogResult dialogResult; // file result
        public Form1()
        {
            InitializeComponent();
            listBoxTaglist.Items.Clear();
            checkTagsToolStripMenuItem.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// to select and read file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileTagElements = new Stack<String>(); // initialize
            using (OpenFileDialog fileChooser = new OpenFileDialog()) // opening file dialog
            {
                fileChooser.Filter = "HTML files (*.html)|*.html"; // filtering only html files
                dialogResult = fileChooser.ShowDialog(); // file selection result
                try
                {
                    filePath = fileChooser.FileName; //storing file path
                    fileInfo = new FileInfo(filePath); // storing file data
                }
                catch(Exception)
                {
                    labelMessage.Text = "File not Selected"; // If file not selected displaying message
                }
                
            }
            if (dialogResult == DialogResult.OK)
            {
                // user enter invalid file name
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("File is Invalid ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // file is valid
                else
                {
                    try
                    {
                        string fileText = ""; // to store file text
                        StreamReader input = new StreamReader(filePath); // reading file data

                        while ((fileText = input.ReadLine()) != null) // input is not null
                        {
                            fileTagElements.Push(fileText);    // adding data in to stack from string 
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error reading from file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                checkTagsToolStripMenuItem.Enabled = true; // enabling to check file
                labelMessage.Text = fileInfo.Name + "   File Loaded ...."; // displaying message
            }
        }

        /// <summary>
        /// to check file 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // tags that don't have closing tags
            string[] singletonTags = {  "<img>", "<hr>", "<br>" };  // tags are excluded from the html file

            int openingTagsCount = 0;  // to count opening tags
            int closingTagsCount = 0;  // to count closing tags

            Stack<String> fileDataResult = new Stack<String>(); 

            // if stack is not empty
            while (fileTagElements.Count > 0)
            {
                string stackLine = (string)fileTagElements.Pop();  //   pop the data of from the stack and store it in string
                char[] lineChar = stackLine.ToCharArray();      //  lineChar to convert the string to char
                bool flag = true; 
                string fileTagName = "";  // html tag names

                // array length is greater than 0
                if (lineChar.Length > 0)
                {
                    // traversing through each char
                    for (int i = 0; i < lineChar.Length; i++)
                    {

                        int k = i;
                        if (lineChar[i].Equals('<')) // found opening tag
                        {

                            while (flag && !lineChar[k].Equals('>')) // not found closing tag
                            {
                                if (lineChar[k].Equals(' '))
                                {
                                    flag = false; // turminating loop
                                }
                                fileTagName += lineChar[k].ToString(); // adding tag name char
                                k++;
                            }
                            fileTagName+= ">";
                        }
                        if (lineChar[i].Equals('>')) //found closing tag
                        {

                            // if filetagname not matches singleton tag
                            if (!singletonTags.Contains(fileTagName))
                            {
                                // if tag contains /
                                if (fileTagName.Contains('/')) //if tagname does contain '/' than data is pushed and printed in the lisbox as closing tag
                                {
                                    // adding tag into stack
                                    fileDataResult.Push("\t\tFound Closing Tag: " + fileTagName);
                                    closingTagsCount++; // increment closing tag count
                                    
                                }
                                // if tag does not conains /
                                else if (!fileTagName.Contains('/'))  //if tagname doesn't contain '/' than data is pushed and printed in the lisbox as opening tag
                                {
                                    // adding tag into stack
                                    fileDataResult.Push("\tFound Opening Tag: " + fileTagName);
                                    openingTagsCount++; // increment opening tag count
                                }
                                
                            }
                            else  // tag is singleton
                            {
                                fileDataResult.Push("Found Non-Container Tag: " + fileTagName); // adding tag in to stack
                            }
                            fileTagName = ""; // emptying filetagname
                        }
                    }
                }
            }

            foreach (string stringLine in fileDataResult)
            {
                listBoxTaglist.Items.Add(stringLine);  //add the data to the listbox 
            }

            if (openingTagsCount == closingTagsCount) //if both tags are equal
            {
                labelMessage.Text = fileInfo.Name + " has balanced tags.";
            }
            else   //if both tags are not equal
            {
                labelMessage.Text = fileInfo.Name + " does not have balanced tags.";

            }
        }

        /// <summary>
        /// To close the Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
