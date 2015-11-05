using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace skyamanager.Models
{
    public class SKYAModel
    {
        public SKYAModel()
        { }

        const string csinfo = "Server=tcp:g3fpfv3vl2.database.windows.net,1433;Database=SKYA;User ID=skya@g3fpfv3vl2;Password=Password9;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
        public string PushSKYA(System.Xml.XmlDocument info)
        {
            using (SqlConnection conn = new SqlConnection(csinfo))
            {
                SqlCommand addSite = new SqlCommand(@"dbo.AddLog", conn);
                addSite.CommandType = CommandType.StoredProcedure;
                //addSite.Parameters.Add(new SqlParameter("@logvar",SqlDbType.NVarChar,8000,"logvar"));
                addSite.Parameters.AddWithValue("@logvar", info);
                addSite.Connection.Open();
                addSite.ExecuteNonQuery();
                addSite.Connection.Close();
                return "done";
            }
        }

        public string AddSKYA(System.Xml.XmlDocument info)
        {
            using (SqlConnection conn = new SqlConnection(csinfo))
            {
                SqlCommand addSite = new SqlCommand(@"dbo.AddLog", conn);
                addSite.CommandType = CommandType.StoredProcedure;
                addSite.Parameters.Add(new SqlParameter("@logvar",SqlDbType.VarChar));
                addSite.Parameters[0].Value = info.DocumentElement.OuterXml;
                addSite.Connection.Open();
                addSite.ExecuteNonQuery();
                addSite.Connection.Close();
                return "done";
            }
        }

    }
}