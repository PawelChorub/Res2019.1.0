using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Res2019.MSSQL
{
    public class MsSqlDataAccess : IMsSqlDataAccess
    {
        private static IMsSqlDatabaseSettings connectionString;
        
        public MsSqlDataAccess()
        {
            connectionString = MsSqlManager.CreateMsSqlDatabaseSettings();
        }

        private static SqlConnection sqlConnection = new SqlConnection(MsSqlDatabaseSettings.MsSqlConnectionStringBuildStatic());
        private static SqlCommand sqlCommand;

        public void SaveData(string sqlQuery)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd podczas zapisu do bazy, szczegóły: " + ex.Message);
            }
        }
        SqlDataReader reader;

        public List<string> GetSingleRowDataList(string sqlQuery, string[] column)
        {
            List<string> output = new List<string>();
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < column.Length; i++)
                        {
                            output.Add(reader[column.ElementAt(i)].ToString());
                        }
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd podczas odczytu z bazy, szczegóły: " + ex.Message);
            }
            return output;
        }


        public List<string> GetSingleColumnDataList(string sqlQuery, string modelProperty)
        {
            List<string> outputList = new List<string>();

            try
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        outputList.Add(reader[modelProperty].ToString());
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return outputList;
        }


        //public List<string> GetData(string sqlQuery, string[] column)
        //{
        //    List<string> output = new List<string>();
        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
        //        reader = sqlCommand.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                for (int i = 0; i < column.Length; i++)
        //                {
        //                    output.Add(reader[column.ElementAt(i)].ToString());
        //                }
        //            }
        //        }
        //        sqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Wystąpił nieoczekiwany błąd podczas odczytu z bazy, szczegóły: " + ex.Message);
        //    }
        //    return output;
        //}
        //public T GetData<T> (string sqlQuery, T model)
        //{
        //    var modelPropetry = new List<string>();
        //    var property = model.GetType().GetProperties();
        //    foreach (var item in property)
        //    {
        //        modelPropetry.Add(item.Name.ToLower());
        //    }
        //    var column = modelPropetry.ToArray();

        //    List<string> output = new List<string>();
        //    T modelOut;

        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
        //        reader = sqlCommand.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                for (int i = 0; i < column.Length; i++)
        //                {
        //                    output.Add(reader[column.ElementAt(i)].ToString());
        //                }
        //            }
        //        }
        //        sqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Wystąpił nieoczekiwany błąd podczas odczytu z bazy, szczegóły: " + ex.Message);
        //    }

        //    var receivedData = output.ToArray();

        //    return modelOut;
        //}
        public List<string> GetData(string sqlQuery, object model)
        {
            var modelPropetry = new List<string>();
            var property = model.GetType().GetProperties();
            foreach (var item in property)
            {
                modelPropetry.Add(item.Name.ToLower());
            }
            var column = modelPropetry.ToArray();

            List<string> output = new List<string>();
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < column.Length; i++)
                        {
                            output.Add(reader[column.ElementAt(i)].ToString());
                        }
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd podczas odczytu z bazy, szczegóły: " + ex.Message);
            }
            return output;
        }




    }
}
