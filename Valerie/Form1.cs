using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Valerie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if(txtEncryption == null)
            {
                lblMsg.Text = "Required Field *";
            }
            else
            {
                txtEncryption.Text = Encrypt(txtEncryption.Text);
                this.AcceptButton = btnDecrypt;
            }
        }

        //Encrypt function takes the string from the TextBox, turns it into byte array and adds 85 to each byte.
        //Function returns a string of the encrypted text.
        private string Encrypt (string text)
        {
            byte[] toBytes = Encoding.ASCII.GetBytes(text); 
            string s = "";
            foreach (byte b in toBytes)
            {
                int tmp = Convert.ToInt32(b);
                tmp += 85;
                s += tmp + " ";
            }
            return s;
        }

        //Decrypt does the opposite of Encrypt and returns the decrypted message.
        private string Decrypt (string text)
        {
            string message = "";
            string[] chars = text.Split(' ');
            for (int i = 0; i < chars.Length - 1; i++)
            {
                int tmp = Int32.Parse(chars[i]);
                tmp -= 85;
                message += ((char)tmp).ToString();
            }
            return message;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtEncryption == null)
            {
                lblMsg.Text = "Required Field *";
            }
            else
            {
                txtEncryption.Text = Decrypt(txtEncryption.Text);
                this.AcceptButton = btnEncrypt;
            }
        }
    }
}
