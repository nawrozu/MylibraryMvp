using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Library_MVP.Logic.Service
{
    static  class CategoryService
    {
        // this methoud to add insert parameter to stored prosdure
        private static void CategoryParameterInsert(int id , string name,SqlCommand cmd)
        {
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value=id;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
        }
        // this methoud to add delete parameter to stored prosdure
        private static void CategoryParameterDelete(int id,SqlCommand cmd)
        {
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
           
        }
        // this methoud to add Update parameter to stored prosdure
        private static void CategoryParameterUPDATE(int id, string name, SqlCommand cmd)
        {
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
        }
        public static bool CategoryInsert(int id, string name)
         {
            return DBHelper.excuteData("CategoryInsert", () => CategoryParameterInsert(id, name, DBHelper.cmd));
            
         }
        public static bool CategoryDelete(int id)
        {
           return  DBHelper.excuteData("CategoryDelete", () => CategoryParameterDelete(id, DBHelper.cmd));

           
        }
        public static bool CategoryUpdate(int id, string name)
        {
           return  DBHelper.excuteData("CategoryUpdate", () => CategoryParameterUPDATE(id, name, DBHelper.cmd));
            
        }
    }
}
