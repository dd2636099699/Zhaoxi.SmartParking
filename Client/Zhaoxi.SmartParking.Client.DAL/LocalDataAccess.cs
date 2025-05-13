using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.DAL
{
    public class LocalDataAccess : ILocalDataAccess
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
            catch
            {
                return false;
            }
        }



        public List<string[]> GetLocalFileInfo()
        {
            if (this.Connection())
            {
                try
                {
                    string sql = "select file_name,file_md5 from file_version";
                    adapter = new SQLiteDataAdapter(sql, conn);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable.AsEnumerable().Select(d => new string[] { d.Field<string>("file_name"), d.Field<string>("file_md5") }).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    this.Dispose();
                }
            }

            return null;
        }

        public List<string> GetIcons()
        {
            if (this.Connection())
            {
                try
                {
                    string sql = "select icon from icons";
                    adapter = new SQLiteDataAdapter(sql, conn);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable.AsEnumerable().Select(d => d.Field<string>("icon")).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    this.Dispose();
                }
            }
            return null;
        }


        public int GetClientType()
        {
            if (this.Connection())
            {
                try
                {
                    string sql = "select client_type from settings";
                    comm = new SQLiteCommand(sql, conn);
                    var query = comm.ExecuteScalar();

                    return query == null ? 0 : int.Parse(query.ToString());
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    this.Dispose();
                }
            }
            return 0;
        }

        public string GetRoads()
        {
            if (this.Connection())
            {
                try
                {
                    string sql = "select * from road_info";
                    adapter = new SQLiteDataAdapter(sql, conn);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);


                    return Newtonsoft.Json.JsonConvert.SerializeObject((from q in dataTable.AsEnumerable()
                                                                        select new
                                                                        {
                                                                            RoadId = q.Field<Int64>("_id"),
                                                                            RoadName = q.Field<string>("road_name"),
                                                                            RoadType = q.Field<Int64>("road_type")
                                                                        }).ToList());
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    this.Dispose();
                }
            }
            return "[]";
        }

        public string GetDevices(int roadId)
        {
            if (this.Connection())
            {
                try
                {
                    string sql = "select * from device_info where road_id = " + roadId;
                    adapter = new SQLiteDataAdapter(sql, conn);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);


                    return Newtonsoft.Json.JsonConvert.SerializeObject((from q in dataTable.AsEnumerable()
                                                                        select new
                                                                        {
                                                                            DeviceName = q.Field<string>("device_name"),
                                                                            IP = q.Field<string>("ip"),
                                                                            Port = q.Field<Int64>("port")
                                                                        }).ToList());
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    this.Dispose();
                }
            }
            return "[]";
        }
    }
}
