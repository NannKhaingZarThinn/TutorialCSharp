using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesSystemProject
{
    public partial class Form1 : Form
    {
        Double jobDetails;
        Double labour;
        Double travel;
        Double plastic;
        Double copper;
        Double chrome;
        Double iTax = 17.5;

        Double firstnum;
        Double secondnum;
        Double answer;
        String operations;

        double[] i = new double[5];

        Double Nigerian_Naira = 302.96;
        Double US_Dollar = 1.52;
        Double Kenyan_Shilling = 156.21;
        Double Brazilian_Real = 5.86;
        Double Canadian_Dollar = 2.03;
        Double Indian_Rupee = 100.68;
        Double Philippne_Peso = 71.74;
        Double Indonesian_Rupiah = 20746.75;

        public Form1()
        {
            InitializeComponent();
        }

        private void jobBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.jobBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.loginDataSet);

        }

        private void jobBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.jobBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.loginDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'loginDataSet.Job' table. You can move, or remove it, as needed.
            this.jobTableAdapter.Fill(this.loginDataSet.Job);

            DateTime iDate = DateTime.Now;
            lbDate.Text = iDate.ToLongDateString();
            timer1.Start();

            i[0] = 24.99;
            i[1] = 4.99;
            i[2] = 10.99;
            i[3] = 8.90;
            i[4] = 7.99;

            chkDiscount.Checked = false;
            comCurrency.Text = "Choose One";
            comCurrency.Items.Add("USA");
            comCurrency.Items.Add("Nigeria");
            comCurrency.Items.Add("Kenyan");
            comCurrency.Items.Add("Canada");
            comCurrency.Items.Add("Brazil");
            comCurrency.Items.Add("India");
            comCurrency.Items.Add("Philippne");
            comCurrency.Items.Add("Indonesia");
        }

        private void jobDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime iDate = DateTime.Now;
            lbTime.Text = iDate.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Double NetTax;
            int Job_Ref;
            Random rnd = new Random();
            Job_Ref = rnd.Next(1000, 32665);
            job_IDTextBox.Text = Convert.ToString(Job_Ref);

            labour = Double.Parse(labourTextBox.Text);
            travel = Double.Parse(travelTextBox.Text);
            copper = Double.Parse(copper_PipTextBox.Text);
            plastic = Double.Parse(plastic_PipTextBox.Text);
            chrome = Double.Parse(chrome_PipTextBox.Text);

            i[0] = 24.99 * labour;
            i[1] = 4.99 * travel;
            i[2] = 10.99 * copper;
            i[3] = 8.90 * chrome;
            i[4] = 7.99 * plastic;

            if (chkDiscount.Checked == false)
            {

                jobDetails = i[0] + i[1] + i[2] + i[3] + i[4];
                NetTax = ((jobDetails) * iTax) / 100;
                subTotalTextBox.Text = System.Convert.ToString(jobDetails);
                taxTextBox.Text = System.Convert.ToString(NetTax);
                discountTextBox.Text = System.Convert.ToString(0);

                totalTextBox.Text = System.Convert.ToString(NetTax + jobDetails);

                discountTextBox.Text = String.Format("{0:C}", Double.Parse(discountTextBox.Text));
                taxTextBox.Text = String.Format("{0:C}", Double.Parse(taxTextBox.Text));
                subTotalTextBox.Text = String.Format("{0:C}", Double.Parse(subTotalTextBox.Text));
                totalTextBox.Text = String.Format("{0:C}", Double.Parse(totalTextBox.Text));
            }
            if (chkDiscount.Checked == true)
            {

                jobDetails = i[0] + i[1] + i[2] + i[3] + i[4];
                NetTax = ((jobDetails) * iTax) / 100;
                subTotalTextBox.Text = System.Convert.ToString(jobDetails);
                taxTextBox.Text = System.Convert.ToString(NetTax);
                discountTextBox.Text = System.Convert.ToString(((NetTax + jobDetails) * 10) / 100);

                totalTextBox.Text = System.Convert.ToString((NetTax + jobDetails) - (((NetTax + jobDetails) * 10) / 100));

                discountTextBox.Text = String.Format("{0:C}", Double.Parse(discountTextBox.Text));
                taxTextBox.Text = String.Format("{0:C}", Double.Parse(taxTextBox.Text));
                subTotalTextBox.Text = String.Format("{0:C}", Double.Parse(subTotalTextBox.Text));
                totalTextBox.Text = String.Format("{0:C}", Double.Parse(totalTextBox.Text));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;

            if (lblDisplay.Text == "0")
                lblDisplay.Text = num.Text;
            else
                lblDisplay.Text = lblDisplay.Text + num.Text;
        }

        private void Cal_Function(object sender, EventArgs e)
        {
            Button ops = (Button)sender;
            firstnum = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = "";
            operations = ops.Text;
            lblShowCal.Text = System.Convert.ToString(firstnum) + " " + operations; // To Display
        }

        private void button12_Click(object sender, EventArgs e)
        {
            lblShowCal.Text = "";
            secondnum = Double.Parse(lblDisplay.Text);
            switch (operations)
            {
                case "+":
                    answer = (firstnum + secondnum);
                    lblDisplay.Text = System.Convert.ToString(answer);
                    break;
                case "-":
                    answer = (firstnum - secondnum);
                    lblDisplay.Text = System.Convert.ToString(answer);
                    break;
                case "*":
                    answer = (firstnum * secondnum);
                    lblDisplay.Text = System.Convert.ToString(answer);
                    break;
                case "/":
                    answer = (firstnum / secondnum);
                    lblDisplay.Text = System.Convert.ToString(answer);
                    break;
                default: break;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 0)
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1, 1);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (num.Text == ".")
            {
                if (!lblDisplay.Text.Contains("."))
                    lblDisplay.Text = lblDisplay.Text + num.Text;
            }
        }

        private void btnCC_Click(object sender, EventArgs e)
        {
            btnCC.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            Double British_Pound = Double.Parse(txtConvert.Text);

            if (comCurrency.Text == "Nigeria")
            {
                lblConvert.Text = System.Convert.ToString((British_Pound * Nigerian_Naira));
            }
            if (comCurrency.Text == "Kenyan")
            {
                lblConvert.Text = System.Convert.ToString((British_Pound * Kenyan_Shilling));
            }
            if (comCurrency.Text == "USA")
            {
                lblConvert.Text = System.Convert.ToString((British_Pound * US_Dollar));
            }
            if (comCurrency.Text == "Canada")
            {
                lblConvert.Text = System.Convert.ToString((British_Pound * Canadian_Dollar));
            }
            if (comCurrency.Text == "Brazil")
            {
                lblConvert.Text = System.Convert.ToString((British_Pound * Brazilian_Real));
            }
            if (comCurrency.Text == "India")
            {
                lblConvert.Text = System.Convert.ToString((British_Pound * Indian_Rupee));
            }
            if (comCurrency.Text == "Philippine")
            {
                lblConvert.Text = System.Convert.ToString((British_Pound * Philippne_Peso));
            }
            if (comCurrency.Text == "Indonesia")
            {
                lblConvert.Text = System.Convert.ToString((British_Pound * Indonesian_Rupiah));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnCC.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            labourTextBox.Text = "";
            travelTextBox.Text = "";
            copper_PipTextBox.Text = "";
            chrome_PipTextBox.Text = "";
            taxTextBox.Text = "";
            chkDiscount.Checked = false;
            subTotalTextBox.Text = "";
            totalTextBox.Text = "";
            firstnameTextBox.Text = "";
            surnameTextBox.Text = "";
            discountTextBox.Text = "";
            dOBTextBox.Text = "";
            addressTextBox.Text = "";
            emailTextBox.Text = "";
            phoneTextBox.Text = "";
            job_IDTextBox.Text = "";
            plastic_PipTextBox.Text = "";
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            lblShowCal.Text = "";
            lblShowCal.AppendText("\t\t\t" + " Job Estimator" + Environment.NewLine);
            lblShowCal.AppendText("\t\t\t" + " #################" + Environment.NewLine);

            lblShowCal.AppendText("\tName\t" + firstnameTextBox.Text + "\t Surname" + surnameTextBox.Text + "\t Ref No" + job_IDTextBox.Text + Environment.NewLine);
            lblShowCal.AppendText("\tLabour\t" + labourTextBox.Text + "\t Travel" + travelTextBox.Text + "\t" + Environment.NewLine);
            lblShowCal.AppendText(Environment.NewLine + "\t\tAddress\t" + addressTextBox.Text + Environment.NewLine);
            lblShowCal.AppendText(Environment.NewLine + "\t\tPlastic\t" + plastic_PipTextBox.Text + "\t\tChrome\t" + chrome_PipTextBox.Text + Environment.NewLine);
            lblShowCal.AppendText(Environment.NewLine + "\t\tCopper\t" + copper_PipTextBox.Text + Environment.NewLine);
            lblShowCal.AppendText("\tDiscount\t" + discountTextBox.Text + "\t Tax" + taxTextBox.Text + "\t Sub Total" + subTotalTextBox.Text + Environment.NewLine);
            lblShowCal.AppendText("\tTotal\t" + totalTextBox.Text + Environment.NewLine);
        }
    }
}
