using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

using System.Xml;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data.SqlClient;


namespace proje1
{
    public partial class Form1 : Form
    {


        SqlConnection baglantim = new SqlConnection("Server=PCYAZ\\SQLEXPRESS,1433;Database=Verim_1;uid=sa;pwd=admin-*741852963");
        SqlConnection baglantim2 = new SqlConnection("Server=PCYAZ\\SQLEXPRESS,1433;Database=Verim_1;uid=sa;pwd=admin-*741852963");
        SqlConnection baglantim3 = new SqlConnection("Server=PCYAZ\\SQLEXPRESS,1433;Database=Verim_1;uid=sa;pwd=admin-*741852963");
        SqlConnection baglantim4 = new SqlConnection("Server=PCYAZ\\SQLEXPRESS,1433;Database=Verim_1;uid=sa;pwd=admin-*741852963");
        SqlConnection baglantim5 = new SqlConnection("Server=PCYAZ\\SQLEXPRESS,1433;Database=Verim_1;uid=sa;pwd=admin-*741852963");
        SqlConnection baglantim6 = new SqlConnection("Server=PCYAZ\\SQLEXPRESS,1433;Database=Verim_1;uid=sa;pwd=admin-*741852963");

        public string html;
        public Uri url;
        private SqlDataAdapter adaptor;
        private SqlCommand komut;
        private SqlCommand kontrolsagla;

        //stokkodunu değişkene atadım
       // string stokkodudegis;
        


        public Form1()
        {
            InitializeComponent();
        }
        int sayi;


        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                tablo.Columns.Add(dataGridView1.Columns[i].HeaderText);
            }

            // fATURADTTableAdapter.Fill();
            // TODO: This line of code loads data into the 'verimDataSet.FATURADT' table. You can move, or remove it, as needed.
            //  this.fATURADTTableAdapter.Fill(this.verimDataSet.FATURADT);
           

        }
        //*[@id="lineTableTd"][2]
        //*[@id='lineTable']/tbody/tr[2]

       

        //*[@id='lineTable']/tbody/tr[2]/td[4]
        private void button1_Click(object sender, EventArgs e)
        {
            verial("file:///D:/Adem/Diske%20Atılacaklar%20%20%20ADEM/safabilişim/SAFA%20BİLİŞİM/HTML/KAE2019000000116.html");




            //for (int i = 3; i <= 6; i++)
            //{
            //    verial("file:///C:/Users/Pc/Desktop/KAE2019000000085.html", "//*[@id='despatchTable']/tbody/tr[" + i + "]/td[2]", listBox1);
            //   // button4.PerformClick();
            //}
             //   verial("file:///C:/Users/Pc/Desktop/KAE2019000000085.html","//*[@id='lineTableTr'][2]/td[4][last()]", listBox1);


        }



        public void verial(String Url)
        {
            
            try
            {
                url = new Uri(Url);
            }
            catch (UriFormatException)
            {
                if (MessageBox.Show("hatali url", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                { }


            }
            catch (ArgumentException)
            {
                if (MessageBox.Show("hatali url", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)

                { }



            }

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            try
            {
                html = client.DownloadString(url);

            }
            catch (WebException)
            {
                if (MessageBox.Show("hatali url", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)

                { }

            }












        //    / html / body / table[1] / tbody / tr[1] / td[1] / table / tbody / tr[1] / td

//
        //    / html / body / table[1] / tbody / tr[1] / td[1] / table / tbody / tr[1] / td



            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            try
            {
               // stokkodudegis = doc.DocumentNode.SelectSingleNode("/html/body/table[1]/tbody/tr[1]/td[1]/table/tbody/tr[1]").InnerText;
                foreach (var item in this.Controls)
                {




                        if (item is TextBox)
                        {

                            TextBox txt = (TextBox)item;

                            //hesap adı çekiliyor
                            if (txt.Tag == "/html/body/table[1]/tbody/tr[1]/td[1]/table/tbody/tr[1]")
                            {
                                txt.Text = doc.DocumentNode.SelectSingleNode("/html/body/table[1]/tbody/tr[1]/td[1]/table/tbody/tr[1]").InnerText;
                            }

                            //fatura bilgileri çekiliyor

                            else if (txt.Tag == "//*[@id='despatchTable']/tbody/tr[3]/td[2]")
                            {
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*[@id='despatchTable']/tbody/tr[3]/td[2]").InnerText;
                            }
                            else if (txt.Tag == "//*[@id='despatchTable']/tbody/tr[4]/td[2]")
                            {
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*[@id='despatchTable']/tbody/tr[4]/td[2]").InnerText;
                            }
                            else if (txt.Tag == "//*[@id='despatchTable']/tbody/tr[5]/td[2]")
                            {
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*[@id='despatchTable']/tbody/tr[5]/td[2]").InnerText;

                            }
                            else if (txt.Tag == "//*[@id='despatchTable']/tbody/tr[6]/td[2]")
                            {
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*[@id='despatchTable']/tbody/tr[6]/td[2]").InnerText;
                            }













                            //stok bilgisi mal hizmet kodu çekiliyor
                            else if (txt.Tag == "//*/tr[2][@id='lineTableTr']/td[2]")
                            {
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*/tr[2][@id='lineTableTr']/td[2]").InnerText.Replace(" ", "").Replace("&nbsp;", "");

                            }
                            else if (txt.Tag == "//*/tr[2][@id='lineTableTr']/td[3]")
                            {
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*/tr[2][@id='lineTableTr']/td[3]").InnerText.Replace(" ", "").Replace("&nbsp;", "");
                            }
                            else if (txt.Tag == "//*[@id='lineTable']/tbody/tr[2]/td[4]")
                            {
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*[@id='lineTable']/tbody/tr[2]/td[4]").InnerText.Replace("&nbsp;", "").Replace("Adet", "");
                            }

                            else if (txt.Tag == "//*[@id='lineTable']/tbody/tr[2]/td[4][1]")
                            {
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*[@id='lineTable']/tbody/tr[2]/td[4][1]").InnerText.Replace("&nbsp;", "").Replace("1", "").TrimStart();
                            }

                            else if (txt.Tag == "//*[@id='lineTable']/tbody/tr[2]/td[5]")
                            {
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*[@id='lineTable']/tbody/tr[2]/td[5]").InnerText.Replace("&nbsp;", "").Replace("USD", "").Replace(",", ".");
                            }
                            else if (txt.Tag == "//*[@id='lineTable']/tbody/tr[2]/td[7]")
                            {
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*[@id='lineTable']/tbody/tr[2]/td[7]").InnerText.Replace("&nbsp;", "").Replace("%", "").Replace(",00", "").TrimStart();
                            }
                            else if (txt.Tag == "//*[@id='lineTable']/tbody/tr[2]/td[8]")
                            {
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*[@id='lineTable']/tbody/tr[2]/td[8]").InnerText.Replace("&nbsp;", "").Replace("USD", "").Replace(",", ".").TrimStart();
                            }
                            else if (txt.Tag == "//*[@id='lineTable']/tbody/tr[2]/td[9]")
                            {
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*[@id='lineTable']/tbody/tr[2]/td[9]").InnerText.Replace("&nbsp;", "").Replace("USD", "").Replace(",", ".").TrimStart();
                            }


                            else if (txt.Tag == "//*[@id='notesTableTd']/text()[8]")
                            {
                                //kurbilgisi
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*[@id='notesTableTd']/text()[8]").InnerText.Replace("&nbsp;", "").TrimStart();
                            }

                            else if (txt.Tag == "//*[@id='notesTableTd']/text()[8][1]")
                            {
                                //kur
                                txt.Text = doc.DocumentNode.SelectSingleNode("//*[@id='notesTableTd']/text()[8][1]").InnerText.Replace("&nbsp;", "").Replace("Kur Bilgisi: USD Kuru: ", "").TrimStart().Replace(",", ".");
                            }







                        }
                  
                    
                }

           //     cikansonuc.Items.Add(doc.DocumentNode.SelectSingleNode(XPath).InnerText.Replace(" ", "").Replace("&nbsp;", ""));

                //   string input = doc.DocumentNode.SelectSingleNode(XPath).InnerText;


                // string[] match = Regex.Split(input, @"0\([0-9]{3}\)-[0-9]{3}-[0-9]{2}-[0-9]{2}");

                //     for (int i = 0; i < match.Count(); i++)
                //  {
                //         string key = match[i];
                //       cikansonuc.Items.Add(key);
                //  }



            }
            catch (NullReferenceException)
            {
                if (MessageBox.Show("hatali xpath", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)

                { }

            }

            //-----------------------------------------------------------------------------

            //Mal Hizmet tutarı ve gerisi çekiliyor                                 //*[@id="lineTableBudgetTd"]           //*[@id="budgetContainerTr"]


            HtmlAgilityPack.HtmlDocument docum = new HtmlAgilityPack.HtmlDocument();
            docum.LoadHtml(html);
            try
            {
                foreach (var item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox txt = (TextBox)item;
                        if (txt.Tag == "//*[@id='budgetContainerTr']/tbody/tr[1]/td[last()]")
                        {
                            txt.Text = docum.DocumentNode.SelectSingleNode("//*[@id='budgetContainerTable']/tbody/tr[1]/td[last()]").InnerText.Replace(" ", "").Replace("USD", "");
                        }
                        else if (txt.Tag == "//*[@id='budgetContainerTable']/tbody/tr[2]/td[last()]")
                        {
                            txt.Text = docum.DocumentNode.SelectSingleNode("//*[@id='budgetContainerTable']/tbody/tr[2]/td[last()]").InnerText.Replace(" ", "").Replace("USD", "");
                        }
                        else if (txt.Tag == "//*[@id='budgetContainerTable']/tbody/tr[3]/td[last()]")
                        {
                            txt.Text = docum.DocumentNode.SelectSingleNode("//*[@id='budgetContainerTable']/tbody/tr[3]/td[last()]").InnerText.Replace(" ", "").Replace("USD", "");

                        }
                        else if (txt.Tag == "//*[@id='budgetContainerTable']/tbody/tr[4]/td[last()]")
                        {
                            txt.Text = docum.DocumentNode.SelectSingleNode("//*[@id='budgetContainerTable']/tbody/tr[4]/td[last()]").InnerText.Replace(" ", "").Replace("USD", "");
                        }
                        else if (txt.Tag == "//*[@id='budgetContainerTable']/tbody/tr[5]/td[last()]")
                        {

                            txt.Text = docum.DocumentNode.SelectSingleNode("//*[@id='budgetContainerTable']/tbody/tr[5]/td[last()]").InnerText.Replace(" ", "").Replace("USD", "");
                        }
                        else if (txt.Tag == "//*[@id='budgetContainerTable']/tbody/tr[6]/td[last()]")
                        {
                            txt.Text = docum.DocumentNode.SelectSingleNode("//*[@id='budgetContainerTable']/tbody/tr[6]/td[last()]").InnerText.Replace(" ", "").Replace("TL", "");
                        }
                        else if (txt.Tag == "//*[@id='budgetContainerTable']/tbody/tr[7]/td[last()]")
                        {
                            txt.Text = docum.DocumentNode.SelectSingleNode("//*[@id='budgetContainerTable']/tbody/tr[7]/td[last()]").InnerText.Replace(" ", "").Replace("TL", "");
                        }
                        else if (txt.Tag == "//*[@id='budgetContainerTable']/tbody/tr[8]/td[last()]")
                        {
                            txt.Text = docum.DocumentNode.SelectSingleNode("//*[@id='budgetContainerTable']/tbody/tr[8]/td[last()]").InnerText.Replace(" ", "").Replace("TL", "");
                        }
                        else if (txt.Tag == "//*[@id='budgetContainerTable']/tbody/tr[9]/td[last()]")
                        {
                            txt.Text = docum.DocumentNode.SelectSingleNode("//*[@id='budgetContainerTable']/tbody/tr[9]/td[last()]").InnerText.Replace(" ", "").Replace("TL", "");
                        }

                        //*[@id="budgetContainerTr"]
                        //*[@id="budgetContainerTable"]/tbody/tr[7]
                        //*[@id="budgetContainerTr"]
                        //*[@id="lineTableBudgetTd"]


                    }
                }


            }
            catch (Exception err)
            {
                if (MessageBox.Show("hatali xpath", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)

                { }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
      



                try

                {




                    baglantim.Open();

                    string CariID = "";
                    string HKodu = "";
                    // string HAdi;

                    #region Cari Bilgisi Alınıyor
                    SqlCommand CariBilgi = new SqlCommand("", baglantim);
                    // CariBilgi.CommandType = CommandType.StoredProcedure;
                    CariBilgi = new SqlCommand("SELECT HESAPADI FROM CARIKART where HESAPADI like 'KARE BİLGİSAYAR SANAYİ VE TİCARET A.Ş.%'", baglantim);
                    SqlDataReader al = CariBilgi.ExecuteReader();
                    if (al.HasRows == false)
                    {
                        SqlConnection baglantim = new SqlConnection("Server=PCYAZ\\SQLEXPRESS,1433;Database=Verim_1;uid=sa;pwd=admin-*741852963");
                        baglantim.Open();


                        string st = "INSERT INTO CARIKART (HESAPKODU,HESAPADI,IslemKodu,DurumKodu) VALUES ('000007','KARE BİLGİSAYAR SANAYİ VE TİCARET A.Ş.','CRK_AliciSatici','Aktif')";
                        SqlCommand CariBilgim = new SqlCommand(st, baglantim);
                        CariBilgim.ExecuteNonQuery();
                        baglantim.Close();

                    }
                    #endregion
                    al.Close();


                    // Fatura Sorgulanıyor




                    SqlCommand Comm = new SqlCommand("__FaturaInsert", baglantim); //Burada SQL'de oluşturduğumuz procedureun adını yazıyoruz

                    Comm.CommandType = CommandType.StoredProcedure;

                    System.Data.SqlClient.SqlCommandBuilder cb;
                    // System.Data.OleDb.OleDbCommandBuilder cb;
                    // cb = new OleDbCommandBuilder(adaptor);
                    cb = new SqlCommandBuilder(adaptor);
                    komut = new SqlCommand("SELECT CariKart_ID,HESAPKODU FROM CARIKART where HESAPADI like '%KARE BİLGİSAYAR SANAYİ%'", baglantim);
                    SqlDataReader bilgigetir = komut.ExecuteReader();

                    while (bilgigetir.Read())
                    {
                        if (bilgigetir.GetString(1) != "")
                        {
                            CariID = bilgigetir["CariKart_ID"].ToString();
                            HKodu = bilgigetir["HESAPKODU"].ToString();
                            // HAdi = bilgigetir["HESAPADI"].ToString() ;

                            break;
                        }

                    }
                    bilgigetir.Close();

                    Comm.Parameters.AddWithValue("@SevkAdres_FID", DBNull.Value);
                    Comm.Parameters.AddWithValue("@PerFatura_FID", DBNull.Value);
                    Comm.Parameters.AddWithValue("@Plasiyer_FID", DBNull.Value);
                    Comm.Parameters.AddWithValue("@CariKart_FID", CariID);
                    Comm.Parameters.AddWithValue("@FATURANO", fatno.Text);
                    Comm.Parameters.AddWithValue("@ISLEMTIPI", "Alis Faturasi");
                    Comm.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(fattarih.Text));
                    Comm.Parameters.AddWithValue("@DONEM", "Ocak");
                    Comm.Parameters.AddWithValue("@HESAPKODU", HKodu);
                    Comm.Parameters.AddWithValue("@BELGESERI", DBNull.Value);
                    Comm.Parameters.AddWithValue("@BELGENO", fatno.Text);
                    Comm.Parameters.AddWithValue("@OZELKOD", DBNull.Value);
                    Comm.Parameters.AddWithValue("@KDV", Convert.ToDecimal(kdv.Text));
                    Comm.Parameters.AddWithValue("@ACIKLAMA", kurbilgisi.Text);
                    Comm.Parameters.AddWithValue("@MASRAF", 0);
                    Comm.Parameters.AddWithValue("@INDIRIM", 0);
                    Comm.Parameters.AddWithValue("@TOPLAM", Convert.ToDecimal(malhiztoplamTL.Text));
                    Comm.Parameters.AddWithValue("@NETBORC", DBNull.Value);
                    Comm.Parameters.AddWithValue("@NETALACAK", Convert.ToDecimal(odenecektutar.Text));
                    Comm.Parameters.AddWithValue("@PARABIRIMI", "$");
                    Comm.Parameters.AddWithValue("@ISLEMKURU", DBNull.Value);
                    Comm.Parameters.AddWithValue("@CARIKURU", DBNull.Value);
                    Comm.Parameters.AddWithValue("@TLBORC", DBNull.Value);
                    Comm.Parameters.AddWithValue("@TLALACAK", Convert.ToDecimal(odenecektutar.Text));
                    Comm.Parameters.AddWithValue("@DOVIZBORC", DBNull.Value);
                    Comm.Parameters.AddWithValue("@DOVIZALACAK", DBNull.Value);
                    Comm.Parameters.AddWithValue("@KDVDAHIL", DBNull.Value);
                    Comm.Parameters.AddWithValue("@CARIDOVIZI", "TL");
                    Comm.Parameters.AddWithValue("@KAPATMA", DBNull.Value);
                    Comm.Parameters.AddWithValue("@VADESI", DBNull.Value);
                    Comm.Parameters.AddWithValue("@KAPATMANO", DBNull.Value);
                    Comm.Parameters.AddWithValue("@SAAT", fatsaati.Text);
                    Comm.Parameters.AddWithValue("@YAZDIRMA", DBNull.Value);
                    Comm.Parameters.AddWithValue("@SEVKTARIHI", DBNull.Value);
                    Comm.Parameters.AddWithValue("@SATICI", DBNull.Value);
                    Comm.Parameters.AddWithValue("@ACIKLAMA2", DBNull.Value);
                    Comm.Parameters.AddWithValue("@ACIKLAMA3", DBNull.Value);
                    Comm.Parameters.AddWithValue("@ACIKLAMA4 ", DBNull.Value);
                    Comm.Parameters.AddWithValue("@FATURAMALIYETI", 0);
                    Comm.Parameters.AddWithValue("@ARATOPLAM", Convert.ToDecimal(malhiztoplamTL.Text));
                    Comm.Parameters.AddWithValue("@OTV", 0);
                    Comm.Parameters.AddWithValue("@TEVKIFAT_KDVSI", 0);
                    Comm.Parameters.AddWithValue("@TEVKIFAT", DBNull.Value);
                    Comm.Parameters.AddWithValue("@HESAPADI", hesapadi.Text);
                    Comm.Parameters.AddWithValue("@Depolar_FID", 1);
                    Comm.Parameters.AddWithValue("@SATICIPRIMI", DBNull.Value);
                    Comm.Parameters.AddWithValue("@SECIM", DBNull.Value);
                    Comm.Parameters.AddWithValue("@ISLEMKODU", "FT_Alis");
                    Comm.Parameters.AddWithValue("@DONEMNO", "2019_01");
                    Comm.Parameters.AddWithValue("@STOPAJORANI", DBNull.Value);
                    Comm.Parameters.AddWithValue("@STOPAJ", DBNull.Value);
                    Comm.Parameters.AddWithValue("@SAYFA", DBNull.Value);
                    Comm.Parameters.AddWithValue("@ONAY", DBNull.Value);
                    Comm.Parameters.AddWithValue("@KAPANMATRH", DBNull.Value);
                    Comm.Parameters.AddWithValue("@KdvDurumKodu", "KDV_Dahil");
                    Comm.Parameters.AddWithValue("@OzelKod_FID", DBNull.Value);
                    Comm.Parameters.AddWithValue("@ToplamMiktar", DBNull.Value);
                    Comm.Parameters.AddWithValue("@ToplamReferansMiktar", DBNull.Value);
                    Comm.Parameters.AddWithValue("@GC_Tipi", 1);
                    Comm.Parameters.AddWithValue("@FaturaAdres_FID", DBNull.Value);
                    Comm.Parameters.AddWithValue("@Upt_Flg", 1);
                    Comm.Parameters.AddWithValue("@Iptal", DBNull.Value);
                    Comm.Parameters.AddWithValue("@BakiyeBorc", DBNull.Value);
                    Comm.Parameters.AddWithValue("@BakiyeAlacak", DBNull.Value);
                    Comm.Parameters.AddWithValue("@Rota", DBNull.Value);
                    Comm.Parameters.AddWithValue("@Muhasebe", DBNull.Value);
                    Comm.Parameters.AddWithValue("@Sube_FID", DBNull.Value);
                    Comm.Parameters.AddWithValue("@DigerGider", DBNull.Value);
                    Comm.Parameters.AddWithValue("@FaizTarihi", DBNull.Value);
                    Comm.Parameters.AddWithValue("@VadeUygula", DBNull.Value);
                    Comm.Parameters.AddWithValue("@KDVeksiTEVKIFAT", DBNull.Value);
                    Comm.Parameters.AddWithValue("@Tevk_Payi", DBNull.Value);
                    Comm.Parameters.AddWithValue("@Tevk_Paydasi", DBNull.Value);
                    Comm.Parameters.AddWithValue("@VFDekontisl_FID", DBNull.Value);
                    Comm.Parameters.AddWithValue("@UUID", DBNull.Value);
                    Comm.Parameters.AddWithValue("@EFaturaNO", DBNull.Value);
                    Comm.Parameters.AddWithValue("@EFaturaDurumu", DBNull.Value);
                    Comm.Parameters.AddWithValue("@EFaturaAltDurumu", DBNull.Value);
                    Comm.Parameters.AddWithValue("@EFaturaGIBCode", DBNull.Value);
                    Comm.Parameters.AddWithValue("@VadeFarki", DBNull.Value);
                    Comm.Parameters.AddWithValue("@DipIsktOrani", DBNull.Value);
                    Comm.Parameters.AddWithValue("@KargoGideri", DBNull.Value);
                    Comm.Parameters.AddWithValue("@KomisyonOrani", DBNull.Value);
                    Comm.Parameters.AddWithValue("@KomisyonGideri", DBNull.Value);
                    Comm.Parameters.AddWithValue("@TevkifatKodu", DBNull.Value);
                    Comm.Parameters.AddWithValue("@EkVergiler", DBNull.Value);
                    Comm.Parameters.AddWithValue("@Borc ", DBNull.Value);
                    Comm.Parameters.AddWithValue("@Alacak ", 1);
                    Comm.Parameters.AddWithValue("@EFaturaTipi", DBNull.Value);
                    Comm.Parameters.AddWithValue("@EFaturaTuru", DBNull.Value);
                    Comm.Parameters.AddWithValue("@EFaturaSenaryo ", DBNull.Value);
                    Comm.Parameters.AddWithValue("@EFaturaDurumKodu", DBNull.Value);
                    Comm.Parameters.AddWithValue("@YeniIrsaliyeNO ", DBNull.Value);
                    Comm.Parameters.AddWithValue("@EarsivEmailiGonderildi", DBNull.Value);
                    Comm.Parameters.AddWithValue("@FaturaLog_FID ", DBNull.Value);


                    object Fatura_ID = Comm.ExecuteScalar();
                    MessageBox.Show("Başarıyla Kaydedildi");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    baglantim.Close();
                }

            //  }
            //  baglantim.Close();
            FatraDTKAydet();
            

        }




        
      




        //public void gelenveriler()
        //{
        //    stokkodudegis = "//*/tr[2][@id='lineTableTr']/td[2]".Replace("", "").Replace("&nbsp;", "").ToString();
        //}










        private void button4_Click(object sender, EventArgs e)
        {
            
            stokekle();








        }

        public void stokekle()
        {
            HtmlAgilityPack.HtmlDocument stokdoc = new HtmlAgilityPack.HtmlDocument();
            stokdoc.LoadHtml(html);
            try
            {
              //  stokkodudegis = "//*/tr[2][@id='lineTableTr']/td[2]".Replace("", "").Replace("&nbsp;", "").ToString();
               //stokkodudegis = stokdoc.DocumentNode.SelectSingleNode("//*/tr[2][@id='lineTableTr']/td[2]".Replace(" ", "").Replace("&nbsp;", ""));
                

            }
            catch (Exception)
            {

                throw;
            }






            if (/*stokkodudegis*/stokkodu.Text=="")
            {
                MessageBox.Show("Stok bulunmamaktadır.Lütfen stok ekleyiniz");
            }

            else 
            {








                SqlCommand cmdk = new SqlCommand();
                baglantim2.Open();
                komut = new SqlCommand("select * from STOKKART,FATURA where STOKKODU = '" +/*stokkodudegis*/stokkodu.Text + "'", baglantim2);
                object FaturaSayisi = komut.ExecuteScalar();
                SqlDataReader stokgetir = komut.ExecuteReader();
                if (stokgetir.HasRows)
                {
                  //  while (stokgetir.Read())
                  //  {
                      //  MessageBox.Show("Stok Bulunmaktadır Stok Koduyla arayınız.");
                        //  FatraDTKAydet();
                        //    MessageBox.Show("faturadetay olarak eklendi");
                        griddoldur();
                  //  }
                    stokgetir.Close();
                   // baglantim2.Close();
                }
               

                else 
                {
                  //  baglantim2.Close();
              
                   baglantim6.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglantim6;
                    var temp = "insert into STOKKART(BirimTanim_FID,STOKADI,BIRIMA,KDV,ALISFIYATI,GIREN,CIKAN,DOVIZTURU,KDVDURUMU,STOKKODU,TEVKIFAT,SERINOTAKIP,KDVDURUMU2,IslemKodu,VarsayilanBirim) values (2,'" + stokadı.Text + "','" + (miktarturu.Text != "" ? miktarturu.Text : "Adet") + "','" + (kdvoranı.Text != "" ? kdvoranı.Text : "1") + "','" + (birimfiyat.Text != "" ? birimfiyat.Text : "1") + "','" + (miktar.Text != "" ? miktar.Text : "1") + "','"+0+"','"+"$"+"','"+ "Kdv_H" + "','" +/*stokkodudegis*/ stokkodu.Text + "','"+0+"','"+0+"','"+ "Kdv_H" + "','"+ "ST_TicariMal" + "','"+"Adet"+"')";
                    cmd.CommandText = temp;
                    cmd.ExecuteNonQuery();
                  //  cmd.Clone();

                  // stokgetir.Close();



                    //   gridelisteyigetir();





                    //   FatraDTKAydet();




                  //  baglantim6.Close();

                    MessageBox.Show("eklendi");
                    griddoldur();

                   // stokkodu.Clear();
                   // stokadı.Clear();
                  //  miktar.Clear();
                  //  birimfiyat.Clear();
                 //   kdvoranı.Clear();
                 //   kdvTL.Clear();
                 //   toplam.Clear();

                }

                baglantim6.Close();
                baglantim2.Close();
              //  baglantim2.Close();

            }
            
        }
        DataTable tablo = new DataTable();

        public void griddoldur()
        {
     //       SqlCommand cmdk = new SqlCommand();
     //       baglantim2.Open();
     //       komut = new SqlCommand("select * from STOKKART,FATURA where STOKKODU = '" + stokkodu.Text + "'and FATURANO= '" + fatno.Text + "'", baglantim2);
    //        object FaturaSayisi = komut.ExecuteScalar();
     //       SqlDataReader stokgetir = komut.ExecuteReader();
      //      if (stokgetir.HasRows)
        //    {
              //  while (stokgetir.Read())
             //   {
                 //   MessageBox.Show("Stok Bulunmaktadır Stok Koduyla arayınız.");


                    baglantim5.Open();
                    komut = new SqlCommand("select * from STOKKART,FATURA where STOKKODU = '" +/*stokkodudegis*/ stokkodu.Text + "'", baglantim5);
                    SqlDataReader stokgetirsk = komut.ExecuteReader();

                    //  komut = new SqlCommand("select * from FATURA", baglantim);
                    // SqlDataReader faturagetir = komut.ExecuteReader();

                    if (stokgetirsk != null)
                    {
                        while (stokgetirsk.Read())
                        {


                            DataRow dr = tablo.NewRow();
                    dr["Fatura_FID"] = stokgetirsk["Fatura_ID"];
                    dr["StokKart_FID"] = stokgetirsk["StokKart_ID"];
                    dr["CariKart_FID"] = stokgetirsk["CariKart_FID"];
                    dr["Depolar_FID"] = "1";
                           
                            
                            dr["KODU"] = stokgetirsk["STOKKODU"];
                            dr["ACIKLAMA"] = stokgetirsk["STOKADI"];
                            dr["GIRENMIKTAR"] = stokgetirsk["GIREN"];
                            //dr["TOPLAM"] = stokgetir["TOPLAM"];
                            tablo.Rows.Add(dr);




                        }
                        stokgetirsk.Close();
                        baglantim5.Close();

                        //  }

                    }

                    dataGridView1.DataSource = tablo;










              //  }
            //    stokgetir.Close();
              //   baglantim2.Close();
          //  }

        }












        private void FatraDTKAydet()
        {
            

            baglantim.Close();
            baglantim4.Open();
            komut = new SqlCommand("select * from STOKKART,FATURA where STOKKODU = '" +/*stokkodudegis*/ stokkodu.Text + "'and FATURANO= '" + fatno.Text + "'", baglantim4);
            SqlDataReader stokgetir = komut.ExecuteReader();
            baglantim.Open();
            var komut2 = new SqlCommand("select * from STOKKART,FATURA where STOKKODU = '" +/*stokkodudegis*/ stokkodu.Text + "'and FATURANO= '" + fatno.Text + "'", baglantim);
            if (stokgetir.HasRows)
            {
                while (stokgetir.Read())
                {
                    //dövizbirimfiyat hesabını yapıyoruz

                    double a =Convert.ToDouble(birimfiyat.Text);
                    double b =Convert.ToDouble(kurusd.Text);
                    double dovizbirimfiyat = (a * b);
                    dvzbirimfiyat.Text = dovizbirimfiyat.ToString();
                    dvzbirimfiyat.Visible = false;
                    //
                    

                    komut2.CommandText = "insert into FATURADT(Fatura_FID,StokKart_FID,CariKart_FID,Depolar_FID,ISLEMTARIHI,DONEM,TURU,CARIKODU,ACIKLAMA,GIRENMIKTAR,MIKTARI,REFBIRIMI,REFCARP,BIRIMI,BIRIMFIYAT,PARABIRIMI,TOPLAM,KDV,KDVTL,DVZBIRIMFIYAT,BIRIMMALIYET,TOPLAMMALIYET,IRSALIYETARIHI,KODU,DVZBIRIMMALIYETI,DVZTOPLAMMALIYET,CARIADI,STOKDOVIZI,ISLEMKODU) values('" + stokgetir["Fatura_ID"] + "','" + stokgetir["StokKart_ID"] + "','" + stokgetir["CariKart_FID"] + "','"+stokgetir["Depolar_FID"]+"','" + stokgetir["TARIH"] + "','"+stokgetir["DONEM"]+"','Stok','"+stokgetir["HESAPKODU"]+"','" + stokgetir["STOKADI"] + "','"+Convert.ToDecimal( miktar.Text)+"','"+Convert.ToDecimal(miktar.Text)+"','"+miktarturu.Text+ "','" + Convert.ToDecimal(miktar.Text) + "','" + miktarturu.Text+"','"+Convert.ToDecimal( birimfiyat.Text)+"','"+stokgetir["PARABIRIMI"]+"','"+Convert.ToDecimal(toplam.Text)+"','"+Convert.ToDecimal( kdvoranı.Text)+"','"+Convert.ToDecimal( kdvTL.Text)+"','"+Convert.ToDecimal(dvzbirimfiyat.Text)+"','"+Convert.ToDecimal(birimfiyat.Text)+"','"+Convert.ToDecimal(toplam.Text)+"','"+ Convert.ToDateTime(stokgetir["TARIH"])+"','"+/*stokkodudegis*/stokkodu.Text+"','"+Convert.ToDecimal(dvzbirimfiyat.Text)+"','"+Convert.ToDecimal(dvzbirimfiyat.Text)+"','"+hesapadi.Text+"','"+stokgetir["CARIDOVIZI"]+"','"+ stokgetir["ISLEMKODU"]+"')";

                    komut2.ExecuteNonQuery();
                    
                 
                    
                }

                stokgetir.Close();
                baglantim4.Close();
                baglantim.Close();
            }





            //cmdk.CommandText = "insert into FATURADT(Fatura_FID,StokKart_FID) values('" + faturaID + "','" + StokID + "')";
            ////  cmd.CommandText=""
            //cmdk.ExecuteNonQuery();


            MessageBox.Show("eklendiiiii");



           


        }
       
       
       
        






        private void button5_Click(object sender, EventArgs e)
        {
            //listeyigetir();


            // baglantim.Open();
            //  kontrolsagla = new SqlCommand("select STOKKODU from STOKKART", baglantim);
            //  SqlDataReader kotrolet = kontrolsagla.ExecuteReader();
            int stokid = 0;

            if (stokid != 0)
            {



                MessageBox.Show("Stok bulunamadı lütfen stok ekleyiniz!");

            }




            baglantim.Open();
            komut = new SqlCommand("select * from STOKKART,FATURA where STOKKODU = '" +/*stokkodudegis*/ stokkodu.Text + "'and FATURANO= '" + fatno.Text + "'", baglantim);
            SqlDataReader stokgetir = komut.ExecuteReader();

            //  komut = new SqlCommand("select * from FATURA", baglantim);
            // SqlDataReader faturagetir = komut.ExecuteReader();

            if (stokgetir != null)
            {
                while (stokgetir.Read())
                {
                    //komut = new SqlCommand("select * from STOKKART", baglantim);
                    //SqlDataReader stokgetiri = komut.ExecuteReader();
                    //dataGridView1.DataSource = stokgetir;


                    stokid = Convert.ToInt32(stokgetir["StokKart_ID"]); // Stoğu Gride ekleyen bir fonksiyon yazılacak
                    DataTable tablo = new DataTable();
                    //sorgu.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    dataGridView1.Rows[0].Cells[4].Value = stokgetir["StokKart_ID"];
                    dataGridView1.Rows[0].Cells[47].Value = stokgetir["STOKKODU"];
                    dataGridView1.Rows[0].Cells[18].Value = stokgetir["STOKADI"];
                    dataGridView1.Rows[0].Cells[19].Value = 1;
                    dataGridView1.Rows[0].Cells[21].Value = stokgetir["GIREN"];
                    dataGridView1.Rows[0].Cells[24].Value = "Adet";
                    dataGridView1.Rows[0].Cells[27].Value = stokgetir["TOPLAM"];
                    dataGridView1.Rows[0].Cells[28].Value = "USD";
                    dataGridView1.Rows[0].Cells[68].Value = "KARE BİLGİSAYAR";
                    dataGridView1.Rows[0].Cells[2].Value = stokgetir["Fatura_ID"];
                    dataGridView1.Rows[0].Cells[5].Value = stokgetir["CariKart_FID"];




                }
                stokgetir.Close();
                baglantim.Close();
            }



            //stokekle();}




            //    stokekle();
            //   listeyigetir();



            // stokekle();
            /* FaturaDT    || Stok Kart
                * Stokkart_FID => Stokkart_id 
                * Kodu            Stokkodu
                * ACIKLAMA         Stok Adı
                * Giren Miktari    HTML'DEN Mİktar
                * Miktarı          Giren miktar
                * Birimi           HTMLden alınacak
                * Birim Fİyat      HTMLDEN alınacak
                * PAraBirimi = TL & USD
                * Toplam           HTML üzerinden satır toplamı
                * Cari Adı         Kare Bilgisayar
                * Carifid
                * 
                *
                */






            //DataRow workRow = verimDataSet.FATURADT.NewFATURADTRow();
            //workRow[47] = stokkodu.Text;
            //workRow[18] = stokadı.Text;
            //workRow[19] = miktar.Text;
            //workRow[21] = miktar.Text;
            //workRow[24] = "Adet";
            //workRow[25] = birimfiyat.Text;
            //workRow[26] = "$";
            //workRow[27] = toplam.Text;


            //verimDataSet.FATURADT.Rows.Add(workRow);




            //listele();
            // MessageBox.Show("Ürününüz Eklendi");





        }
    }
}
