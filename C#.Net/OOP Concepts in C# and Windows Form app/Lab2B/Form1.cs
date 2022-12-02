using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Purpose:    To get form data and performing operations and returns result
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab2B
{
    public partial class Form1 : Form
    {

        private int hair_dresser_price; // hairdresser price
        private int services_price; // services price
        private int Client_Type; // client type discount
        private int Client_visit; // client visits discount
        private string Clientvisits; // to get client visit from form
        
        /// <summary>
        ///   to assing hair dresser price every time when user change hair dresser         
        /// </summary>
        private enum Hair_Dresser_Price
        {
            Jane = 30,
            Pat = 45,
            Ron = 40,
            Sue = 50,
            Laurie = 55
        }
        /// <summary>
        ///   to assing services price every time when user add or remove services         
        /// </summary>
        private enum Services
        {
            Cut = 30,
            Colour = 40,
            Highlights = 50,
            Extension = 200

        }
        /// <summary>
        ///   to assing client type discount every time when user change client type         
        /// </summary>
        private enum Client_type
        {
            Adult = 0,
            Child = 10,
            Student = 5,
            Senior = 15
        }
        /// <summary>
        ///   to assing client visit discount every time when user change client visit number         
        /// </summary>
        private enum Client_Visit
        {
            oneto3 = 0,
            fourto8 = 5,
            nineto13 = 10,
            fourteenplus = 15
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        ///   to set hairdresser price as per radio button checked         
        /// </summary>
        private void hairdresser()
        {
            if (radioButtonJane.Checked == true)
            {
                hair_dresser_price = (int)Hair_Dresser_Price.Jane;
            }
            else if (radioButtonPat.Checked == true)
            {
                hair_dresser_price = (int)Hair_Dresser_Price.Pat;
            }
            else if (radioButtonRon.Checked == true)
            {
                hair_dresser_price = (int)Hair_Dresser_Price.Ron;
            }
            else if (radioButtonSue.Checked == true)
            {
                hair_dresser_price = (int)Hair_Dresser_Price.Sue;
            }
            else if (radioButtonLaura.Checked == true)
            {
                hair_dresser_price = (int)Hair_Dresser_Price.Laurie;
            }
        }

        /// <summary>
        ///   to set client visits discount as per textbox value         
        /// </summary>
        private void clientvisits()
        {
            if (int.Parse(Clientvisits) <= 3 && int.Parse(Clientvisits) >= 1)
            {
                Client_visit = (int)Client_Visit.oneto3;
            }
            else if (int.Parse(Clientvisits) >= 4 && int.Parse(Clientvisits) <= 8)
            {
                Client_visit = (int)Client_Visit.fourto8;
            }
            else if (int.Parse(Clientvisits) >= 9 && int.Parse(Clientvisits) <= 13)
            {
                Client_visit = (int)Client_Visit.nineto13;
            }
            else if (int.Parse(Clientvisits) >= 14)
            {
                Client_visit = (int)Client_Visit.fourteenplus;
            }
        }

        /// <summary>
        ///   to set services price as per checkbox button checked         
        /// </summary>
        private void services()
        {
            if (checkBoxCut.Checked == true)
            {
                services_price += (int)Services.Cut;
            }
            if (checkBoxColour.Checked == true)
            {
                services_price += (int)Services.Colour;
            }
            if (checkBoxHighlights.Checked == true)
            {
                services_price += (int)Services.Highlights;
            }
            if (checkBoxExtension.Checked == true)
            {
                services_price += (int)Services.Extension;
            }
        }

        /// <summary>
        ///   to set client type discount as per radio button checked         
        /// </summary>
        private void clienttype()
        {
            if (radioButtonAdult.Checked == true)
            {
                Client_Type = (int)Client_type.Adult;

            }
            else if (radioButtonChild.Checked == true)
            {
                Client_Type = (int)Client_type.Child;

            }
            else if (radioButtonStudent.Checked == true)
            {
                Client_Type = (int)Client_type.Student;

            }
            else if (radioButtonSenior.Checked == true)
            {
                Client_Type = (int)Client_type.Senior;
            }
        }

        /// <summary>
        ///   Setting to default values         
        /// </summary>
        private void clear()
        {
            hair_dresser_price = 0;
            services_price = 0;
            Client_Type = 0;
            Client_visit = 0;
            labelTotalPrice.Text = "Total Price: ";
        }

        /// <summary>
        ///   to calculate total amount on button click        
        /// </summary>
        private void buttonCalculate_Click_1(object sender, EventArgs e)
        {
            clear(); // clearing previous data
            Clientvisits = textBoxNumofClientVisit.Text; // getting client visits
            if (int.Parse(Clientvisits) > 0) // if client visit more than 0 executes every functions
            {
                hairdresser();
                services();
                int sum = hair_dresser_price + services_price;
                clienttype();
                clientvisits();
                int discountpercent = Client_Type + Client_visit;
                int discount = discountpercent * sum / 100;

                int total = sum - discount;
                labelTotalPrice.Text = "Total Price: " + total.ToString();   
            }
            else // show error
            {
                MessageBox.Show("Client visit can not be 0 or Negative");
                textBoxNumofClientVisit.Text = "1";
                clear();
            }
        }

        /// <summary>
        ///   Clear all fields and set to default values         
        /// </summary>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            radioButtonJane.Checked = true;
            radioButtonPat.Checked = false;
            radioButtonRon.Checked = false;
            radioButtonSue.Checked = false;
            radioButtonLaura.Checked = false;
            radioButtonAdult.Checked = true;
            radioButtonChild.Checked = false;
            radioButtonStudent.Checked = false;
            radioButtonSenior.Checked = false;
            textBoxNumofClientVisit.Text = "1";
            checkBoxCut.Checked = true;
            checkBoxColour.Checked = false;
            checkBoxHighlights.Checked = false;
            checkBoxExtension.Checked = false;
            labelTotalPrice.Text = "Total Price: ";
        }

        /// <summary>
        ///   close the application         
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxNumofClientVisit_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxNumofClientVisit_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxNumofClientVisit_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
