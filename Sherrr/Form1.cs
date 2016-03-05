using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

using System.IO;


namespace Sherrr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            desObj = Rijndael.Create();

        }
        SymmetricAlgorithm desObj;
        string cypherData;
        byte[] chipherbytes;
        byte[] plainbytes;
        byte[] plainbytes2;
        byte[] plainKey;

        private void button1_Click(object sender, EventArgs e)
        {
            cypherData = textBox1.Text;
            plainbytes = Encoding.ASCII.GetBytes(cypherData);
            plainKey = Encoding.ASCII.GetBytes("0123456789abcdef");
            desObj.Key = plainKey;
            //
            desObj.Mode = CipherMode.CBC;
            desObj.Padding = PaddingMode.PKCS7;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, desObj.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(plainbytes, 0, plainbytes.Length);
            cs.Close();
            chipherbytes = ms.ToArray();
            ms.Close();
            textBox2.Text = Encoding.ASCII.GetString(chipherbytes);
        }
    }
}
