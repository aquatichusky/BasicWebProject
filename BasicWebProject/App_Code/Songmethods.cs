using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWebProject.App_Code
{
    using System.Data;
    public class Songmethods
    {
        private DataSet ds = new DataSet("playlist");
        public string filename;

        public Songmethods()
        {

        }

        public DataSet GetAllSongs(string Filename)
        {
            filename = filename;
            DataTable dtSong = new DataTable("song");

            DataColumn dcId = new DataColumn("id");
            DataColumn dcTitel = new DataColumn("titel");
            DataColumn dcArtist = new DataColumn("artist");

            dtSong.Columns.Add(dcTitel);
            dtSong.Columns.Add(dcArtist);
            dtSong.Columns.Add(dcId);

            ds.Tables.Add(dtSong);

            ds.ReadXml(HttpContext.Current.Server.MapPath(Filename));
            return ds;
        }

        public void CreateSong(DataRow datarow,string file)
        {
            ds.Tables["song"].Rows.Add(datarow);
            ds.WriteXml(HttpContext.Current.Server.MapPath(file));
        }

        public void DeleteSong(string id , string filename)
        {
            DataRow[] drarray = ds.Tables["song"].Select("id = '" + id + "'");
            if (drarray != null && drarray.Length > 0)
            {
                drarray[0].Delete();
                ds.WriteXml(HttpContext.Current.Server.MapPath(filename));
            }
        }

        public DataRow GetEmptyDataRow()
        {
            DataRow dr = ds.Tables["song"].NewRow();
            return dr;
        }

        public void SavaRow (DataRow dr)
        {
            ds.Tables["song"].Rows.Add(dr);
            ds.WriteXml(HttpContext.Current.Server.MapPath(filename));
        }
        /*public DataSet GetALLSongs(string filename)
        {
            DataSet ds = new DataSet("playlist");

            DataTable dt = new DataTable("song");

            DataColumn dcId = new DataColumn("id");
            DataColumn dcTitel = new DataColumn("titel");
            DataColumn dcArtist = new DataColumn("artist");

            dt.Columns.Add(dcTitel);
            dt.Columns.Add(dcArtist);
            dt.Columns.Add(dcId);

            ds.Tables.Add(dt);

            ds.ReadXml(HttpContext.Current.Server.MapPath(filename));
            return ds;
        }*/
    }
}