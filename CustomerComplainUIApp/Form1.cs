using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerComplainUIApp
{
    public partial class Form1 : Form
    {
        private Complains aComplain = new Complains();

        public Form1()
        {
            InitializeComponent();
        }

        private void enqueueButton_Click(object sender, EventArgs e)
        {
            Complain newComplain = new Complain();
            newComplain.serialNo = aComplain.lastSerial;
            newComplain.customerName = enqNameTextBox.Text;
            newComplain.customerComplain = enqComplainTextBox.Text;
            aComplain.Add(newComplain);

            lvGenerator();
            clear_InputText();
        }

        private void dequeueButton_Click(object sender, EventArgs e)
        {
            if (aComplain.queCom.Count >0)
            {
                dequeueSerialTextBox.Text = aComplain.queCom.First().serialNo.ToString();
                deqNameTextBox.Text = aComplain.queCom.First().customerName;
                deqComplainTextBox.Text = aComplain.queCom.First().customerComplain;
                aComplain.queCom.Dequeue();

                lvGenerator();
            }

            else
            {
                MessageBox.Show("No More Complains Remain");
            }
        }


        public void clear_InputText()
        {
            enqNameTextBox.Text = "";
            enqComplainTextBox.Text = "";
        }

        public void lvGenerator()
        {
            waitingListView.Items.Clear();

            foreach (Complain complain in aComplain.queCom)
            {
                ListViewItem nwListViewItem = new ListViewItem();
                nwListViewItem.Text = complain.serialNo.ToString();
                nwListViewItem.SubItems.Add(complain.customerName);
                nwListViewItem.SubItems.Add(complain.customerComplain);
                waitingListView.Items.Add(nwListViewItem);
            }

        }
    }
}
