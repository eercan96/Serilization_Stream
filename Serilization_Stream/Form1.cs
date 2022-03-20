using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serilization_Stream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            List<KullaniciSinifi> kullaniciList = new List<KullaniciSinifi>();
            kullaniciList.Add(new KullaniciSinifi { KullaniciAdi = "emre", Sifre = "111" });
            kullaniciList.Add(new KullaniciSinifi { KullaniciAdi = "ercan", Sifre = "123" });
            kullaniciList.Add(new KullaniciSinifi { KullaniciAdi = "ua", Sifre = "1233" });


            bool kullaniciBulunduMu = false;

            foreach (var item in kullaniciList)
            {
                if (item.KullaniciAdi == txtKullaniciAdi.Text && item.Sifre == txtSifre.Text)
                {
                    kullaniciBulunduMu = true;


                    KullaniciTercihleri frmKullaniciTercihleri = new KullaniciTercihleri(item.KullaniciAdi);


                    this.Hide();

                   
                    frmKullaniciTercihleri.Show();
                }
            }

            if (!kullaniciBulunduMu)
            {
                MessageBox.Show("Hatalı kullanıcı adı yada şifre.");
            }

        }
    }
}
