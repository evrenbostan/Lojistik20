using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Lojistik20
{
    class Dinamik
    {
        public static string lisansSunucu = "185.122.201.4";
        public static string lisansDatabase = "DINAMIK";
        public static string lisansDbOwnerUser = "SA";
        public static string lisansDbPassword = "Evren2779+";
        
        public static SqlConnection con = new SqlConnection("Server=" + lisansSunucu + ";Database=" + lisansDatabase + ";User Id=" + lisansDbOwnerUser + ";Password=" + lisansDbPassword + ";");

        public static string hata;

        public static DataTable dt = new DataTable();

        public static bool VersiyonKontrol(string musteriID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_MUSTERI_VERSIYON", con);
                cmd.Parameters.AddWithValue("@MUSTERI_ID", musteriID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YeniVersiyonDosyasiEkle()
        {
            try
            {
                string dosyaAdi = "";
                string dosyaTipi = "";
                decimal dosyaBoyutu = 0;
                string dosyaYolu = "";
                byte[] dosyaIcerik = null;

                OpenFileDialog FileDialog = new OpenFileDialog();
                FileDialog.ShowDialog();

                if (!String.IsNullOrEmpty(FileDialog.FileName))
                {
                    FileInfo ff = new FileInfo(FileDialog.FileName);
                    dosyaAdi = ff.Name;
                    dosyaTipi = ff.Extension;
                    dosyaBoyutu = ff.Length;
                    dosyaYolu = FileDialog.FileName;
                    dosyaIcerik = File.ReadAllBytes(dosyaYolu);
                }
                else
                {
                    hata = "Hatasız";
                    return false;
                }

                SqlCommand cmd = new SqlCommand("SP_INSERT_YENI_VERSIYON_DOSYASI", con);
                cmd.Parameters.AddWithValue("@PROGRAM_VERSIYON", "Basic");
                cmd.Parameters.AddWithValue("@DOSYA_ADI", dosyaAdi);
                cmd.Parameters.AddWithValue("@DOSYA_TIPI", dosyaTipi);
                cmd.Parameters.AddWithValue("@DOSYA_BOYUTU", dosyaBoyutu);
                cmd.Parameters.AddWithValue("@DOSYA_ICERIK", dosyaIcerik);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
