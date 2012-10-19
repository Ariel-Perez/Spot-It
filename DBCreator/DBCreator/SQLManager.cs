using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlServerCe;
using System.Data;

namespace DBCreator
{
    public class SQLManager
    {
        private static SqlCeConnection cn;

        public static event Action<string, List<string>> Error;
        public static void OnError(string title, List<string> errors)
        {
            if (Error != null)
                Error(title, errors);
        }

        public static bool TryConnectDataBase(string filePath, string password = "")
        {
            CloseConnection();

            try
            {
                string connectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", filePath, password);

                cn = new SqlCeConnection(connectionString);
                if (cn.State == ConnectionState.Closed)
                    cn.Open();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void CloseConnection()
        {
            if (cn!= null && cn.State != ConnectionState.Closed)
                cn.Close();
        }

        public static bool CreateDataBase(string filePath, string password = "")
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            try
            {
                string connectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", filePath, password);
                SqlCeEngine en = new SqlCeEngine(connectionString);
                en.CreateDatabase();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static int Execute(string[] sqlInst, out int errorCount)
        {
            SqlCeCommand cmd;
            int count = 0;
            List<string> errors = new List<string>();
            foreach (string sql in sqlInst)
            {
                if (sql.Length > 0)
                {
                    try
                    {
                        cmd = new SqlCeCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                        count++;
                    }
                    catch (Exception ex)
                    {
                        errors.Add(ex.Message);
                    }
                }
            }
            errorCount = errors.Count;

            if(errorCount > 0)
                OnError("Error executing SQL Statement.", errors);

            return count;
        }
    }
}
