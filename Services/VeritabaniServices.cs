using System;
using System.ComponentModel.Design;
using System.Data;
using System.Xml;
using Microsoft.Data.SqlClient;
namespace Banka
{
    public class VeritabaniServices
    {
        string cstr =
        @"Data Source=.\SQLEXPRESS;
        Initial Catalog=BankaDb;
        Integrated Security=True;
        TrustServerCertificate=True";
        SqlConnection cn = null;

        public void KullaniciSil(Kullanici kullanici)
        {
            try{
                cn = new SqlConnection(cstr);
                cn.Open();
                SqlCommand cmdSil = new SqlCommand("DELETE FROM kullanicilar WHERE k_ID = @Id",cn);

                cmdSil.Parameters.AddWithValue("@Id" , kullanici.KullaniciNo);

                int silindiMi = cmdSil.ExecuteNonQuery();

                if (silindiMi > 0)
                {
                    Console.WriteLine("Silme başarılı.");
                }
                else
                {
                    Console.WriteLine("Silinecek kullanıcı bulunamadı.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(cn!=null)
                cn.Close();
            }
        }
        public void KullaniciEkle(Kullanici kullanici)
        {
            try
            {
                cn = new SqlConnection(cstr);
                cn.Open();
                SqlCommand cmdEkle = new SqlCommand("INSERT INTO kullanicilar (k_ad,k_soyad,sifre,bakiye,olusturmaTarihi,kilitliMi)VALUES (@ad,@soyad,@sifre,@bakiye,@olusturmaTarih,@kilitliMi)",cn);

                cmdEkle.Parameters.AddWithValue("@ad", kullanici.Ad);
                cmdEkle.Parameters.AddWithValue("@soyad", kullanici.Soyad);
                cmdEkle.Parameters.AddWithValue("@sifre", kullanici.Sifre);
                cmdEkle.Parameters.AddWithValue("@bakiye", kullanici.Bakiye);
                cmdEkle.Parameters.AddWithValue("@olusturmaTarih", DateTime.Now);
                cmdEkle.Parameters.AddWithValue("@kilitliMi", kullanici.KilitliMi);

                int eklendiMi = cmdEkle.ExecuteNonQuery();

                if(eklendiMi == 1)
                {
                    Console.WriteLine("Ekleme başarılı");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(cn!=null)
                cn.Close();
            }
        }
        public void KullaniciListele()
        {
            try
            {
                cn = new SqlConnection(cstr);
                cn.Open();
                SqlCommand cmdListele = new SqlCommand("SELECT * from kullanicilar");
                cmdListele.Connection = cn;

                SqlDataAdapter da = new SqlDataAdapter(cmdListele);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("Kayıt bulunamadı.");
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine($"No      : {row["k_ID"]}");
                    Console.WriteLine($"Ad      : {row["Ad"]}");
                    Console.WriteLine($"Soyad   : {row["Soyad"]}");
                    Console.WriteLine($"Bakiye  : {row["Bakiye"]}");
                    Console.WriteLine($"Rol     : {row["Rol"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(cn!=null)
                cn.Close();
            }
        }
        public Kullanici? GirisYap(int kullaniciNo,string sifre)
        {
            try
            {
            using SqlConnection cn = new SqlConnection(cstr);
            cn.Open();
            using SqlCommand cmdGirisYap = new SqlCommand("SELECT * FROM kullanicilar WHERE k_Id = @id AND sifre = @sifre",cn);

            cmdGirisYap.Parameters.AddWithValue("@id",kullaniciNo);
            cmdGirisYap.Parameters.AddWithValue("@sifre",sifre);

            using SqlDataReader dr = cmdGirisYap.ExecuteReader();

               if (!dr.Read())
                {
                    Console.WriteLine("Kullanıcı bulunamadı.");
                    return null;
                }


                Kullanici kullanici = new Kullanici(
                dr["k_ad"].ToString(),
                dr["k_soyad"].ToString(),
                (int)dr["k_ID"],
                dr["sifre"].ToString(),
                (decimal)dr["bakiye"],
                KullaniciRolu.Musteri
                );

            return kullanici;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
        public void ParaYatir(int kullaniciNo,decimal bakiye)
        {
            try
            {
                using SqlConnection cn = new SqlConnection(cstr);
                cn.Open();
                using SqlCommand cmdParaYatir = new SqlCommand("UPDATE kullanicilar SET bakiye = @bakiye WHERE k_ID = @id",cn);

                cmdParaYatir.Parameters.AddWithValue("@id",kullaniciNo);
                cmdParaYatir.Parameters.AddWithValue("@bakiye",bakiye);
                int guncellendiMi = cmdParaYatir.ExecuteNonQuery();

                if (guncellendiMi == 1)
                {
                    Console.WriteLine("Bakiye güncellendi.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ParaCek(int kullaniciNo,decimal bakiye)
        {
            try
            {
                using SqlConnection cn = new SqlConnection(cstr);
                cn.Open();
                using SqlCommand cmdParaCek = new SqlCommand("UPDATE kullanicilar SET bakiye = @bakiye WHERE k_ID = @id",cn);

                cmdParaCek.Parameters.AddWithValue("@id",kullaniciNo);
                cmdParaCek.Parameters.AddWithValue("@bakiye",bakiye);
                int guncellendiMi = cmdParaCek.ExecuteNonQuery();

                if (guncellendiMi == 1)
                {
                    Console.WriteLine("Bakiye güncellendi.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void HesapKilitle(int kullaniciNo)
        {
            try
            {
                using SqlConnection cn = new SqlConnection(cstr);
                cn.Open();
                using SqlCommand cmdHesapKilitle = new SqlCommand("UPDATE kullanicilar SET kilitliMi = 1 WHERE k_ID = @id",cn);

                cmdHesapKilitle.Parameters.AddWithValue("@id",kullaniciNo);
                cmdHesapKilitle.ExecuteNonQuery();
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void HesapKilitAc(int kullaniciNo)
        {
            try
            {
                using SqlConnection cn = new SqlConnection(cstr);
                cn.Open();
                using SqlCommand cmdHesapKilitAc = new SqlCommand("UPDATE kullanicilar SET kilitliMi = 0 WHERE k_ID = @id",cn);

                cmdHesapKilitAc.Parameters.AddWithValue("@id",kullaniciNo);
                cmdHesapKilitAc.ExecuteNonQuery();
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Havale(int gonderenId, int aliciId, decimal tutar)
        {
            using SqlConnection cn = new SqlConnection(cstr);
            cn.Open();

            SqlTransaction transaction = cn.BeginTransaction();

            try
            {
                using SqlCommand cmdGonderen = new SqlCommand(
                    "UPDATE kullanicilar SET bakiye = bakiye - @tutar WHERE k_ID=@id",
                    cn,
                    transaction);

                cmdGonderen.Parameters.AddWithValue("@id", gonderenId);
                cmdGonderen.Parameters.AddWithValue("@tutar", tutar);

                cmdGonderen.ExecuteNonQuery();


                using SqlCommand cmdAlici = new SqlCommand(
                    "UPDATE kullanicilar SET bakiye = bakiye + @tutar WHERE k_ID=@id",
                    cn,
                    transaction);

                cmdAlici.Parameters.AddWithValue("@id", aliciId);
                cmdAlici.Parameters.AddWithValue("@tutar", tutar);

                cmdAlici.ExecuteNonQuery();

                transaction.Commit();

                Console.WriteLine("Havale başarılı.");
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }
        public void IslemGecmisi(int kullanicinNo,IslemTipi tip , DateTime tarih,decimal tutar , string aciklama)
        {
            try
            {
                using SqlConnection cn = new SqlConnection(cstr);
                cn.Open();
                using SqlCommand cmdIslem = new SqlCommand("INSERT INTO islemler (islem_tip,tarih,tutar,aciklama) VALUES (@tip,@tarih,@tutar,@aciklama)",cn);
                
                cmdIslem.Parameters.AddWithValue("@id",kullanicinNo);
                cmdIslem.Parameters.AddWithValue("@tip",(int)tip);
                cmdIslem.Parameters.AddWithValue("@tarih",tarih);
                cmdIslem.Parameters.AddWithValue("@tutar",tutar);
                cmdIslem.Parameters.AddWithValue("@aciklama",aciklama);

                int eklendiMi = cmdIslem.ExecuteNonQuery();
                if (eklendiMi == 1)
                {
                    Console.WriteLine("işlem kaydedildi.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}