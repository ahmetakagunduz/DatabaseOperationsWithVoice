using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;
using System.Speech.Recognition;


namespace DbOperationIdeas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ProductList()
        {
            var products = db.TBLPRODUCT.ToList();

            dataGridView1.DataSource = products;
        }
        DbProductAIEntities db = new DbProductAIEntities();

        void enabled()
        {
            TextName.Enabled = false;
            TextBuyPrice.Enabled = false;
            TextSellPrice.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox6.Enabled = false;

        }

        void colormethod()
        {
            TextBuyPrice.BackColor = Color.White;
            TextSellPrice.BackColor = Color.White;
            TextName.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox6.BackColor = Color.White;

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar g = new DictationGrammar();
            sr.LoadGrammar(g);
            try
            {
                BtnSpeak.Text = "Please Speak ";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult res = sr.Recognize();
                richTextBox1.Text = res.Text;
            }

            catch (Exception)
            {
                BtnSpeak.Text = "Please Try Again";
            }

        }

        private void BtnListen_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(richTextBox1.Text);

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {


            if (TextName.BackColor == Color.Green && TextName.Enabled == true)
            {
                TextName.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }
            if (TextBuyPrice.BackColor == Color.Green && TextBuyPrice.Enabled == true)
            {
                TextBuyPrice.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }
            if (textBox2.BackColor == Color.Green && TextBuyPrice.Enabled == true)
            {
                textBox2.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }

            if (richTextBox1.Text == "List of product" || richTextBox1.Text == "Products list")
            {
                ProductList();
            }

            if (richTextBox1.Text == "Add")
            {
                TBLPRODUCT t = new TBLPRODUCT();
                t.NAME = TextName.Text;
                t.BRAND = textBox2.Text;
                t.SELLPRİCE = decimal.Parse(TextSellPrice.Text);
                t.BUYPRİCE = decimal.Parse(TextBuyPrice.Text);
                db.TBLPRODUCT.Add(t);
                db.SaveChanges();
                label10.Text = "The product has been saved in the database ";
            }
            if (richTextBox1.Text == "Products name")
            {
                TextName.Focus();
                TextName.BackColor = Color.Green;
                TextName.Enabled = true;
            }
            if (richTextBox1.Text == "Brand")
            {
                textBox2.Focus();
                textBox2.BackColor = Color.Green;
                textBox2.Enabled = true;
            }
            if (richTextBox1.Text == "Sell price")
            {
                TextSellPrice.Focus();
                TextSellPrice.BackColor = Color.Green;
                TextSellPrice.Enabled = true;
            }
            if (richTextBox1.Text == "Buy  price")
            {
                TextBuyPrice.Focus();
                TextBuyPrice.BackColor = Color.Green;
                TextBuyPrice.Enabled = true;
            }

        }
        private void Form1_load(object sender, EventArgs e)
        {
            enabled();
            colormethod();
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            TBLPRODUCT t = new TBLPRODUCT();
            t.NAME = TextName.Text;
            t.BRAND = textBox2.Text;
            t.SELLPRİCE = decimal.Parse(TextSellPrice.Text);
            t.BUYPRİCE = decimal.Parse(TextBuyPrice.Text);
            db.TBLPRODUCT.Add(t);
            db.SaveChanges();
            label10.Text = "The product has been saved in the database ";
        }
    }
}
