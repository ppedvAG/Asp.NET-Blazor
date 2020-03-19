using System;
using System.Net.Http;
using System.Windows.Forms;

namespace HalloREST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            double zahl = 74.474747474;
            string text = "lala" + zahl + "lala";
            string text2 = string.Format("lala {0:c} lala", zahl);
            string text3 = $"lala {zahl:c} lala";

            var url = $"https://www.googleapis.com/books/v1/volumes?q={textBox1.Text}";
            var http = new HttpClient();
            var json = await http.GetStringAsync(url);

        }
    }
}
