using System;
using System.Data;
using Microsoft.Data.SqlClient;
namespace Banka
{
    public class VeritabaniServices
    {
        string cstr = null;
        string sorgu = null;

        SqlConnection cn = null;
        

        public void KullaniciSil(Kullanici kullanici)
        {
            try{
                cn = new SqlConnection(cstr);
                cn.Open();
                SqlCommand cmdSil = new SqlCommand(sorgu,cn);

                cmdSil.Parameters.AddWithValue("@Id" , kullanici.KullaniciNo);

                int silindiMi = cmdSil.ExecuteNonQuery();

                if (silindiMi == 1)
                {
                    Console.WriteLine("silme başarılı");
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
        public void KullaniciEkle()
        {
            try
            {
                cn = new SqlConnection(cstr);
                cn.Open();
                SqlCommand cmdEkle = new SqlCommand(sorgu,cn);

                cmdEkle.Parameters.AddWithValue("@name" , "Uğur");//uğur yerine bu methoda parametre gonderip kullanıcıdan alınacak
                cmdEkle.Parameters.AddWithValue("@Id" , "1");
                cmdEkle.Parameters.AddWithValue("@sifre" , "5656aslan");

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
                SqlCommand cmdListele = new SqlCommand(sorgu);
                cmdListele.Connection = cn;

                SqlDataAdapter da = new SqlDataAdapter(cmdListele);
                DataTable dt = new DataTable();

                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["Ad"]);
                }

                //cmbKAtegoriler.DataSource = dt;
                //cmbKAtegoriler.DisplayMember = "CatogrıyName";
                //cmbKAtegoriler.ValueMember = "CategorıId";
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

    }
}