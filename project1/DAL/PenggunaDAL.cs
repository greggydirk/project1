using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using project1.Models;
using System.Data.SqlClient;
using System.Text;


namespace project1.DAL
{
    public class PenggunaDAL
    {

        private string GetConnStr()
        {
            return @"Data Source = .\SQLEXPRESS;Initial Catalog = Sample;Integrated Security = True";
        }

        public string GetMD5Hash(string password)
        {
            UnicodeEncoding unicode = new UnicodeEncoding ();
            byte[] datahash = unicode.GetBytes(password);
            MD5 md5 = new MD5CryptoServiceProvider();
            var hasil = md5.ComputeHash(datahash);
            return Convert.ToBase64String(hasil);

        }

        public void Refistrasi(Pengguna pengguna)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Pengguna(Username,Password,Aturan) values (@Username,@password,@Aturan)";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("Username", pengguna.Username);
                cmd.Parameters.AddWithValue("Password", GetMD5Hash(pengguna.Password));
                cmd.Parameters.AddWithValue("Aturan", pengguna.Aturan);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Number.ToString() + " - " + ex.Message);
                }
            }
        }


    }
}