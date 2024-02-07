using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LengthConversions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int i;

        string[,] conversionTable = {
            {"Miles to kilometers", "Miles:", "Kilometers:", "1.6093"},
            {"Kilometers to miles", "Kilometers:", "Miles:", "0.6214"},
            {"Feet to meters", "Feet:", "Meters:", "0.3048"},
            {"Meters to feet", "Meters:", "Feet:", "3.2808"},
            {"Inches to centimeters", "Inches:", "Centimeters:", "2.54"},
            {"Centimeters to inches", "Centimeters:", "Inches:", "0.3937"}
        };

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsDecimal(TextBox textBox, string name)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(name + " must be a decimal number.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Add all conversion in combo box in form load
            cboConversions.Items.Add(conversionTable[0, 0]);
            cboConversions.Items.Add(conversionTable[1, 0]);
            cboConversions.Items.Add(conversionTable[2, 0]);
            cboConversions.Items.Add(conversionTable[3, 0]);
            cboConversions.Items.Add(conversionTable[4, 0]);
            cboConversions.Items.Add(conversionTable[5, 0]);

            //show firt item by default in combo box
            cboConversions.SelectedIndex = 0;
            
        }

        private void cboConversions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCalculatedLength.Clear();
            txtLength.Clear();

            i = cboConversions.SelectedIndex;
            lblFromLength.Text = conversionTable[i, 1]; //changes label depending on user selection
            lblToLength.Text = conversionTable[i, 2];

            //bring focus to length text box 
            txtLength.Focus();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            bool p = IsDecimal(txtLength, "Length"); //checks decimal

            if (p== true)
            {
                double a = Convert.ToDouble(txtLength.Text);
                double unit = Convert.ToDouble(conversionTable[i, 3]);
                double answer = a * unit;

                txtCalculatedLength.Text = answer.ToString(); //Final conversion display
                
            }

            
        }
    }
}
