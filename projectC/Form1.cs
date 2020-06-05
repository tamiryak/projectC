using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) txtPass.Focus();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) txtPass.Focus();
        }

        private void Loginbtn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Please Enter your username.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }
            try
            {
                Database1DataSetTableAdapters.UsersTableAdapter user = new Database1DataSetTableAdapters.UsersTableAdapter();
                Database1DataSet.UsersDataTable dt = user.GetDataByUserNameAndPassword(txtUserName.Text, txtPass.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("You have been succesfully logged in.");

                    if (dt.Rows[0][2].ToString() == "1")
                    {
                        Form2 f = new Form2();
                        f.ShowDialog();
                    }
                    else if (dt.Rows[0][2].ToString() == "2")
                    {
                        Form3 f = new Form3();
                        f.ShowDialog();
                    }
                    else if (dt.Rows[0][2].ToString() == "3")
                    {
                        Form4 f = new Form4();
                        f.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show("Your username or password is incorrect");
                }

            }
            catch
            {
                MessageBox.Show("Message");
            }

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
