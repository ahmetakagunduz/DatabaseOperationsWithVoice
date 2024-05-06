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


namespace Machine_Learning_with_c_
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
            dataGridView1_CellContentClick.DataSource = products;
        }
        DbProductAIEntities db = new DbProductAIEntities();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
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
            if (richTextBox1.Text == "List of product" || )
            {
                ProductList();
            }
        }
    }
}
