using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Serilization_Stream
{
    public partial class KullaniciTercihleri : Form
    {


        private void KullaniciTercihleri_Load(object sender, EventArgs e)
        {
            kullaniciTercihleriniGetir();
        }
        public string KullaniciAdi { get; set; }
        public KullaniciTercihleri(string kullaniciAdi)
        {
            KullaniciAdi = kullaniciAdi;
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtPencereGenislik.Text != "" && txtPencereYukseklik.Text != "" && txtPencereUst.Text != "" && txtPencereSol.Text != "")
            {

                SerializeKullaniciTercihleri(Convert.ToInt32(txtPencereGenislik.Text), Convert.ToInt32(txtPencereYukseklik.Text), Convert.ToInt32(txtPencereUst.Text), Convert.ToInt32(txtPencereSol.Text));
                MessageBox.Show("Değişiklikler kaydedilmiştir.");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurunuz.");
            }
        }

        private void kullaniciTercihleriniGetir()
        {

            KullaniciTercihleriSinifi kullaniciTercihleri = DeserializeKullaniciTercihleri();


            this.Width = kullaniciTercihleri.windowWidth;
            this.Height = kullaniciTercihleri.windowHeight;
            this.Top = kullaniciTercihleri.windowTop;
            this.Left = kullaniciTercihleri.windowLeft;

            txtPencereGenislik.Text = kullaniciTercihleri.windowWidth.ToString();
            txtPencereYukseklik.Text = kullaniciTercihleri.windowHeight.ToString();
            txtPencereUst.Text = kullaniciTercihleri.windowTop.ToString();
            txtPencereSol.Text = kullaniciTercihleri.windowLeft.ToString();
        }

        private void SerializeKullaniciTercihleri(int pencereGenislik, int pencereYukseklik, int PencereUst, int pencereSol)
        {

            KullaniciTercihleriSinifi kullaniciTercihleri = new KullaniciTercihleriSinifi(pencereGenislik, pencereYukseklik, PencereUst, pencereSol);





            Stream stream = new FileStream(KullaniciAdi + "_KullaniciTercihleri.dat", FileMode.Create, FileAccess.Write, FileShare.Write);

            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, kullaniciTercihleri);
            stream.Close();
        }

        private KullaniciTercihleriSinifi DeserializeKullaniciTercihleri()
        {

            Stream stream;
            try
            {
                stream = new FileStream(KullaniciAdi + "_KullaniciTercihleri.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception)
            {

                SerializeKullaniciTercihleri(300, 300, 0, 0);
                stream = new FileStream(KullaniciAdi + "_KullaniciTercihleri.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
            }


            BinaryFormatter formatter = new BinaryFormatter();
            KullaniciTercihleriSinifi kullaniciTercihleri = (KullaniciTercihleriSinifi)formatter.Deserialize(stream);
            stream.Close();
            return kullaniciTercihleri;
        }



    }
}
