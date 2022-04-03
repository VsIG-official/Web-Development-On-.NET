using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using ASP.NET._07_demo3.EDM;

namespace ASP.NET._07_demo3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strConnect = WebConfigurationManager.ConnectionStrings["NORTHWIND"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnect);
                try
                {
                    con.Open();
                    updateListRegions();
                }
                catch
                {
                    Response.Write("Connection to DB is fail");
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private void updateListRegions()
        {
            using (var db = new RegionContext())
            {
                var query1 = from b in db.Regions
                             orderby b.RegionID
                             select b;

                Response.Write("<b><u>List of regions:</u></b>");
                Response.Write("</br>");

                foreach (var item in query1)
                {
                    Response.Write(item.RegionID + " - " + item.RegionDescription);
                    Response.Write("</br>");
                }

                
                var query2 = from r in db.Regions
                             let ts = from t in r.Territories
                                      select (t)
                             where r.RegionID < 100 && ts.Count() > 10
                             orderby r.RegionID
                             select new { 
                                 RegionID = r.RegionID,
                                 RegionDescription = r.RegionDescription,
                                 RegionCountTerritories = ts.Count()
                             };

                               
                //привязать к GridView
                GridView1.DataSource = query2.ToList();
                GridView1.DataBind();
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            int regionID = Int32.Parse(RegionIDTxt.Text);
            var region = new Region { RegionID = regionID, RegionDescription = RegionDescriptionTxt.Text };
            using (var db = new RegionContext())
            {
                db.Regions.Add(region);
                db.SaveChanges();
                updateListRegions();
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            int regionID = Int32.Parse(RegionID2Txt.Text);
            using (var db = new RegionContext())
            {
                //Region region = (from r in db.Regions
                //                 where r.RegionID == regionID
                //                 select r).Single();
                //or
                Region region = db.Regions.Find(regionID);
                if (region != null) { }

                if (region != null)
                {
                    db.Regions.Remove(region);
                    db.SaveChanges();
                }
                updateListRegions();
                //Confections
            }
        }

        protected void CallStoreProcedureButton_Click(object sender, EventArgs e)
        {
            System.Data.Objects.ObjectParameter param = new System.Data.Objects.ObjectParameter("productcount", 0);
            using (var db = new RegionContext())
            {
                db.ProductCountInCategory("Confections", param);
                int i = Int32.Parse(param.Value.ToString());
                ProductCountLbl.Text = i.ToString();
                updateListRegions();
            }

        }

        

    }
}