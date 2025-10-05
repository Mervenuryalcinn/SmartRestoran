using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace projeforms
{
   
        public class DbHelper
        {
            // Bağlantı dizesini merkezi olarak saklama
            private readonly string connectionString;

        public string ConnectionString { get; internal set; }

        // Constructor
        public DbHelper()
        {
            // App.config dosyasından bağlantı dizesini alıyoruz
            connectionString = ConfigurationManager.ConnectionStrings["RestoranSiparisDB"]?.ConnectionString;

            // Bağlantı dizesi boşsa hata fırlatıyoruz
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Bağlantı dizesi doğru şekilde yüklenemedi.");
            }
        }
        // Bağlantı oluşturma ve döndürme
        private SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }

            // ExecuteNonQuery: Veri ekleme, güncelleme veya silme işlemleri için
            public int ExecuteNonQuery(string query, SqlParameter[] parameters)
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        return cmd.ExecuteNonQuery(); // Etkilenen satır sayısını döndürür
                    }
                }
            }
        public void ExecuteNonQuery1(string query, List<SqlParameter> parameters)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }
                    command.ExecuteNonQuery();
                }
            }
        }


        // ExecuteScalar: Tek bir değer döndürmek için (örn. COUNT, MAX)
        public object ExecuteScalar(string query, SqlParameter[] parameters)
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        return cmd.ExecuteScalar(); // Tek bir değer döner
                    }
                }
            }

            // ExecuteReader: Veri okuma işlemleri için
            public DataTable ExecuteReader(string query, SqlParameter[] parameters)
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt; // DataTable döner
                        }
                    }
                }
            }
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddRange(parameters);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        internal string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        internal void ExecuteNonQuery(string insertDetailQuery, List<SqlParameter> detailParameters)
        {
            throw new NotImplementedException();
        }

        internal int ExecuteScalar(string insertOrderQuery, List<SqlParameter> orderParameters)
        {
            throw new NotImplementedException();
        }
    }
    }

