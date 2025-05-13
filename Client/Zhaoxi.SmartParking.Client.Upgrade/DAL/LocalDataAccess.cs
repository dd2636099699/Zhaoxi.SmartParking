using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.Upgrade.DAL
{
    public class LocalDataAccess
    {
        SQLiteConnection conn = null;
        SQLiteCommand comm = null;
        SQLiteDataAdapter adapter = null;
        SQLiteTransaction trans = null;

        private void Dispose()
        {
            if (trans != null)
            {
                trans.Rollback();
                trans.Dispose();
                trans = null;
            }
            if (adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if (comm != null)
            {
                comm.Dispose();
                comm = null;
            }
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        private bool Connection()
        {
            try
            {
                if (conn == null)
                    conn = new SQLiteConnection("data source=data.db");

                conn.Open();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateFileInfo(string fileName, string fileMd5)
        {
            try
            {
                if (!this.Connection()) throw new Exception("创建本地缓存连接出现异常");

                string sql = $"update file_version set file_md5 = '{fileMd5}' where file_name='{fileName}'";
                comm = new SQLiteCommand(sql, conn);
                int count = comm.ExecuteNonQuery();
                if (count == 0)
                {
                    comm.CommandText = $"insert into file_version(file_name,file_md5) values('{fileName}','{fileMd5}')";
                    count = comm.ExecuteNonQuery();
                    if (count == 0)
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                this.Dispose();
            }
        }
    }
}
