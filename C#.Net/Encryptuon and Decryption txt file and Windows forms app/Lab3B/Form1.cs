using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab3B
{
    /// <summary>
    /// Purpose:    To get form data and performing operations and returns result
    /// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
    ///             No other person's work has been used without due acknowledgement.            
    /// </summary>
    public partial class Form1 : Form
    {
        private double hairDresserPrice; // for hair dresser price
        private double servicePrice; // for service price

        public Form1()
        {
            InitializeComponent();
            buttonAddService.Enabled = false;
            buttonCalculate.Enabled = false;
            buttonReset.Enabled = false;
            listBoxChargedItems.SelectionMode = SelectionMode.None; // selection off
            listBoxPrice.SelectionMode = SelectionMode.None; // selection off
            listBoxTotalPrice.SelectionMode = SelectionMode.None; // selection off
        }
        

        /// <summary>
        /// enum to store all hair dresser price
        /// </summary>
        private enum selectHairDresser
        {
            Jane = 30,
            Pat = 45,
            Ron = 40,
            Sue = 50,
            Laurie = 55
        }

        /// <summary>
        /// enum to store all service price
        /// </summary>
        private enum selectService
        {
            Cut = 30,
            WashBlowDryStyle = 20,
            Colour = 40,
            Highlights = 50,
            Extension = 200,
            Updo = 60
        }

        /// <summary>
        /// to choose hair dresser price from enum
        /// </summary>
        public void addHairdresser()
        {
            // for hair dresser name
            string hairDresserName = (string)comboBoxHairDresser.SelectedItem;
            // getting index of selected item of combobox
            int comboindex = (int)comboBoxHairDresser.SelectedIndex;
            // assigning hair dresser price as per selected index
            if (comboindex == 0)
            {
                hairDresserPrice = (double)selectHairDresser.Jane;
            }
            else if (comboindex == 1)
            {
                hairDresserPrice = (double)selectHairDresser.Pat;
            }
            else if (comboindex == 2)
            {
                hairDresserPrice = (double)selectHairDresser.Ron;
            }
            else if (comboindex == 3)
            {
                hairDresserPrice = (double)selectHairDresser.Sue;
            }
            else if (comboindex == 4)
            {
                hairDresserPrice = (double)selectHairDresser.Laurie;
            }

            // adding hair dresser name and price in charged item and price listbox if it's not added
            if (!listBoxChargedItems.Items.Contains(hairDresserName))
            {
                listBoxChargedItems.Items.Add(hairDresserName);
                listBoxPrice.Items.Add(hairDresserPrice);
            }
        }

        /// <summary>
        /// to choose service price from enum
        /// </summary>
        public void addServices()
        {
            string servicename = ""; // for service name
            // getting index of selected item from service listbox
            int selectserviceindex = listBoxSelectService.SelectedIndex;
            // assigning service price as per selected index
            if (selectserviceindex == 0)
            {
                servicePrice = (double)selectService.Cut;
            }
            if (selectserviceindex == 1)
            {
                servicePrice = (double)selectService.WashBlowDryStyle;
            }
            if (selectserviceindex == 2)
            {
                servicePrice = (double)selectService.Colour;
            }
            if (selectserviceindex == 3)
            {
                servicePrice = (double)selectService.Highlights;
            }
            if (selectserviceindex == 4)
            {
                servicePrice = (double)selectService.Extension;
            }
            if (selectserviceindex == 5)
            {
                servicePrice = (double)selectService.Updo;
            }
            // getting service name
            servicename = listBoxSelectService.SelectedItem.ToString();
            // adding service name and price in charged item and price listbox if it is not added
            if (!listBoxChargedItems.Items.Contains(servicename))
            {
                listBoxChargedItems.Items.Add(servicename);
                listBoxPrice.Items.Add(servicePrice);
            }
        }

        /// <summary>
        /// Button click to add hairdresser and service to listboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddService_Click(object sender, EventArgs e)
        {
            addHairdresser();
            addServices();
            comboBoxHairDresser.Enabled = false;
            buttonCalculate.Enabled = true;
        }

        /// <summary>
        /// Close application button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// to calculate total price
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            int total = 0;
            for (int i = 0; i <listBoxPrice.Items.Count; i++)
            {
                total += (int)listBoxPrice.Items[i];
            }
            // displaying total price
            if (!listBoxTotalPrice.Items.Contains(total))
            {
                listBoxTotalPrice.Items.Clear();
                listBoxTotalPrice.Items.Add($"{total:C}");
            }
            
        }

        /// <summary>
        /// To clear all data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            comboBoxHairDresser.SelectedIndex = 0;
            comboBoxHairDresser.Enabled = true;
            listBoxSelectService.SelectedIndex = 0;
            buttonAddService.Enabled = false;
            buttonCalculate.Enabled = false;
            buttonReset.Enabled = false;
            listBoxTotalPrice.Items.Clear();
            listBoxChargedItems.Items.Clear();
            listBoxPrice.Items.Clear();
        }

        private void listBoxSelectService_SelectedValueChanged(object sender, EventArgs e)
        {
            buttonAddService.Enabled = true;
            buttonReset.Enabled = true;
        }
    }
}
