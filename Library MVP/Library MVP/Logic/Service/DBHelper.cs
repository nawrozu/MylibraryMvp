using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Library_MVP.Logic.Service
{
   static public class DBHelper
   {
     public static  SqlCommand cmd;
        // This Method to get connection String from Sql server
        private static SqlConnection getConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = Properties.Settings.Default.ServerName;
            builder.InitialCatalog= Properties.Settings.Default.DBName;
            builder.IntegratedSecurity = true;
            //builder.UserID = "admin";
            //builder.Password = "123";

            return new SqlConnection(builder.ConnectionString);
        }
        //This Method to Insert, delete, update in databese
        public static bool excuteData(string SpName,Action methoud)
        {
            using (SqlConnection Con = getConnectionString())
            {
                try
                {
                    cmd = new SqlCommand(SpName, Con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    // to Excute methoud contain parameters
                    methoud.Invoke();

                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    Con.Close();
                    Console.WriteLine(ex.Message);
                    return false;
                }
               finally
                {
                    Con.Close();
                   
                }
            }
           
        }
   }
}
