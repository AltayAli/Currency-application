using MerkeziBankApp.XMLModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace MerkeziBankApp
{
    public partial class Form1 : Form
    {
        string date;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = GetVAlCur(date).ValType.SelectMany(x=>x.Valute.Where(y=>y.Code==comboBox1.SelectedItem.ToString())
                                                                .Select(t=> new {Tarix = date,Valuta = t.Value})).ToList();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            var result = GetVAlCur(date).ValType.SelectMany(x => x.Valute.
                                                             Select(y => y.Code.ToString())).ToArray();
            var result2 = result.Clone();
            var result3 = result.Clone();
            comboBox1.DataSource = result;
            comboBox2.DataSource = result2;
            comboBox3.DataSource = result3;
        }

        private ValCurs GetVAlCur(string date)
        {
            string url = $"https://www.cbar.az/currencies/{date}.xml";

            HttpClient clicent = new HttpClient();

            ValCurs myVAlCurs = new ValCurs();
            Stream fileStream = clicent.GetAsync(url).GetAwaiter().GetResult().Content.ReadAsStreamAsync().GetAwaiter().GetResult();
            using (fileStream)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));
                myVAlCurs = (ValCurs)serializer.Deserialize(fileStream);

            }
            return myVAlCurs;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
             date = dateTimePicker1.Value.ToString("dd.MM.yyyy");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var first = GetVAlCur(DateTime.Now.ToString("dd.MM.yyyy")).ValType
                                                                 .SelectMany(x => x.Valute.Where(y => y.Code == comboBox2.SelectedItem.ToString())
                                                                 .Select(t => t.Value)).ToList();
            var second = GetVAlCur(DateTime.Now.ToString("dd.MM.yyyy")).ValType
                                                                 .SelectMany(x => x.Valute.Where(y => y.Code == comboBox3.SelectedItem.ToString())
                                                                 .Select(t => t.Value)).ToList();

            txbx_result.Text= (Convert.ToDecimal(first[0]) * Convert.ToDecimal(textBox1.Text) / Convert.ToDecimal(second[0])).ToString();
        }
    }
}
