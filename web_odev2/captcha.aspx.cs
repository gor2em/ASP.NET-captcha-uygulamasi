using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;//bitmap için
using System.Drawing.Imaging;//
using System.IO;//memoryStream için

namespace web_odev2
{
    public partial class captcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                resimOlustur();
            }
        }
        public void resimOlustur()
        {
            string kod = "";
            kod = rastgeleUret();

            //üretilen kod session nesnesine aktarılıyor
            Session.Add("kod", kod);

            //rasatgele üretlien metni resme dönüştür
            //boş bir resim dosyası oluştur
            Bitmap bmp = new Bitmap(100, 21);


            //graphics sınıfı resmin kontrolünü alır
            Graphics g = Graphics.FromImage(bmp);

            //drawstring 20 ye 0 koordinatına kodu yazdırıyor
            g.DrawString(kod, new Font("Calibri", 15), new SolidBrush(Color.Blue), 20,0);


            //3 adet random çizgi yaratıldı
            Random rnd = new Random();
            g.DrawLine(Pens.Gray, rnd.Next(0, 100), rnd.Next(0, 30), rnd.Next(0, 100), rnd.Next(0, 30));
            g.DrawLine(Pens.DarkRed, rnd.Next(0, 100), rnd.Next(0, 30), rnd.Next(0, 100), rnd.Next(0, 30));
            g.DrawLine(Pens.DarkGreen, rnd.Next(0, 100), rnd.Next(0, 30), rnd.Next(0, 100), rnd.Next(0, 30));


            //resmi binary olarak alıp sayfaya yazdırmak için memoryStream kullanıldı
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);

            var base64Data = Convert.ToBase64String(ms.ToArray());
            resimKod.ImageUrl = "data:image/png;base64," + base64Data;

            g.Dispose();
            bmp.Dispose();
            ms.Close();
            ms.Dispose();
        }

        public string rastgeleUret()
        {
            string deger = "";
            string dizi = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVWYXYZabcçdefgğhıijklmnoöprsştuvwxyz0123456789";
            Random rnd = new Random();

            for (int i = 0; i <= 3; i++)
            {
                deger += dizi[rnd.Next(0, 72)];
            }
            return deger;
        }

        protected void btnYenile_Click(object sender, EventArgs e)
        {
            resimOlustur();
        }

        protected void btnKontrol_Click(object sender, EventArgs e)
        {
            lblMesaj.Visible = true;
            if(txtKontrol.Text == Session["kod"].ToString())
            {
                
                lblMesaj.Text = "giriş başarılı... "+txtKontrol.Text; lblMesaj.ForeColor = Color.Green;
            }
            else if (txtKontrol.Text=="")
            {
               
                lblMesaj.Text = "boş değer"; lblMesaj.ForeColor = Color.DarkGray;
            }
            else
            {
                lblMesaj.Text = "hatalı giriş!"; lblMesaj.ForeColor = Color.Red;
                resimOlustur();
            }
        }
    }
}