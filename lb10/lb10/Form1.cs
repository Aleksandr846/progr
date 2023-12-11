using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb10
{
    public partial class Form1 : Form
    {
        private const string filePath = "contacts.txt";

        public Form1()
        {
            InitializeComponent();
            LoadContacts();
        }
        private void LoadContacts()
        {
            listBoxContacts.Items.Clear();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                listBoxContacts.Items.AddRange(lines);
            }
        }

        private void SaveContacts()
        {
            File.WriteAllLines(filePath, listBoxContacts.Items.Cast<string>());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelname_Click(object sender, EventArgs e)
        {

        }

        private void textBoxname_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelphonenumber_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxContacts.SelectedIndex != -1)
            {
                string selectedContact = listBoxContacts.SelectedItem.ToString();
                string[] parts = selectedContact.Split(':');
                if (parts.Length == 2)
                {
                    textBoxname.Text = parts[0].Trim();
                    textBoxPhoneNumber.Text = parts[1].Trim();
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string contact = $"{textBoxname.Text}: {textBoxPhoneNumber.Text}";
            listBoxContacts.Items.Add(contact);
            SaveContacts();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxContacts.SelectedIndex != -1)
            {
                listBoxContacts.Items.RemoveAt(listBoxContacts.SelectedIndex);
                SaveContacts();
            }
        }
    }
}
