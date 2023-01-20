using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace domash_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            textBox2.Text = "60";

            label1.Text = "RUBLES";
            label2.Text = "Currency conversion into rubles";

            comboBox1.Text = "USD";
            button1.Text = "Converting";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ---------- Input validation ---------- 

            // ---------- Line check ----------
            if (int.TryParse(textBox1.Text, out int k)) { }
            else
            {
                MessageBox.Show("Введите целое число");
                throw new Exception("Конвертировать можно только целое число");
            }

            // ---------- Fraction check ----------
            if (double.TryParse(textBox1.Text, out double n)) { }
            else
            {
                MessageBox.Show("Введите целое число");
                throw new Exception("Конвертировать можно только целое число");
            }



            // ---------- Currency check ----------

            if (comboBox1.Text == "USD")
            {
                USD usd = new USD (Convert.ToInt32(textBox1.Text));
                int rub = usd.convert_to_Rouble();
                textBox2.Text = Convert.ToString(rub);
            }

            else if (comboBox1.Text == "EURO")
            {
                EURO euro = new EURO (Convert.ToInt32(textBox1.Text));
                int rub = euro.convert_to_Rouble();
                textBox2.Text = Convert.ToString(rub);
            }

            else if (comboBox1.Text == "YUAN")
            {
                YUAN yuan = new YUAN (Convert.ToInt32(textBox1.Text));
                int rub = yuan.convert_to_Rouble();
                textBox2.Text = Convert.ToString(rub);
            }

            else if (comboBox1.Text == "POUND")
            {
                POUND pound = new POUND (Convert.ToInt32(textBox1.Text));
                int rub = pound.convert_to_Rouble();
                textBox2.Text = Convert.ToString(rub);
            }

            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }



    // --------------------- Class ------------------------------



    abstract class Currency
    {
        protected int amount_of_currency;

        public int Amount_of_currency
        { get { return amount_of_currency; } set { } }

        public virtual int convert_to_Rouble() { return amount_of_currency; }

    }


    // ---------- USD ----------
    class USD : Currency
    {

        public USD(int amount_of_dollar)
        {
            amount_of_currency = amount_of_dollar;
        }

        public override int convert_to_Rouble()
        {
            base.convert_to_Rouble();
            return amount_of_currency * 60;
        }

    }


    // ---------- EURO ----------
    class EURO : Currency
    {

        public EURO(int amount_of_euro)
        {
            amount_of_currency = amount_of_euro;
        }

        public override int convert_to_Rouble()
        {
            base.convert_to_Rouble();
            return amount_of_currency * 63;
        }

    }


    // ---------- POUND ----------
    class POUND : Currency
    {

        public POUND(int amount_of_pound)
        {
            amount_of_currency = amount_of_pound;
        }

        public override int convert_to_Rouble()
        {
            base.convert_to_Rouble();
            return amount_of_currency * 73;
        }

    }


    // ---------- YUAN ----------
    class YUAN : Currency
    {

        public YUAN(int amount_of_yuan)
        {
            amount_of_currency = amount_of_yuan;
        }

        public override int convert_to_Rouble()
        {
            base.convert_to_Rouble();
            return amount_of_currency * 8;
        }

    }


}
