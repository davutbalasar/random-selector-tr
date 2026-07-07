using System.IO;
using System.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private string filePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "RastgeleSecici",
            "ogeler.txt"
        );

        public Form1()
        {
        InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                string[] savedItems = File.ReadAllLines(filePath);
                listBox1.Items.AddRange(savedItems);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Clear();
                SaveItems();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                SaveItems();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                Random rnd = new Random();
                int index = rnd.Next(listBox1.Items.Count);
                label1.Text = "Seçilen: " + listBox1.Items[index].ToString();
            }
            else
            {
                label1.Text = "Seçilecek hiçbir şey yok!";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void SaveItems()
        {
            string folder = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            File.WriteAllLines(filePath, listBox1.Items.Cast<string>());
        }
    }
}
