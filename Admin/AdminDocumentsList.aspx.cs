﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adoptation_Portal.WebPages.Admin
{
    public partial class AdminDocumentsList : System.Web.UI.Page
    {
        readyclass obj = new readyclass();
        string str;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fill();
            }

        }

        private void fill()
        {
            str = "select * from tblDocumentType";
            obj.BindGrid(grdDocumentTypes, str);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int id = obj.autoid("tblDocumentType", "ID");

            string sql = "insert into tblDocumentType (ID,DocumentType) ";
            sql = sql + "Values(" + id + ", '" + txtDocumentType.Text.Trim() + "')";
            Database.executeQuery(sql);

            txtDocumentType.Text = "";

            fill();
        }

        protected void grdDocumentTypes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string release;
            release = grdDocumentTypes.DataKeys[e.RowIndex].Values[0].ToString();

            string sql = "delete from tblDocumentType where ID = " + release + "";
            Database.executeQuery(sql);

            fill();
        }

        protected void grdDocumentTypes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[1].Controls[0];

                db.OnClientClick = "return confirm('Are you certain you want to delete this?');";
            }
        }
    }
}