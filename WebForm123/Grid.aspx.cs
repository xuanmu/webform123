using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Text;

namespace WebForm123
{
    public partial class Grid : System.Web.UI.Page
    {
        public DataTable MyTable
        {
            get
            {
                return ViewState["mytable"] as DataTable;
            }
            set
            {
                ViewState["mytable"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                bindGrid();
            }
        }


        private void bindGrid()
        {
            DataTable dt = new DataTable();
            if (MyTable == null)
            {
                dt.Columns.Add("col1", typeof(String));
                dt.Columns.Add("col2", typeof(String));
                dt.Columns.Add("col3", typeof(String));
                dt.Rows.Add("111", "222", "333");
                dt.Rows.Add("112", "222", "333");
                dt.Rows.Add("113", "222", "333");
                dt.AcceptChanges();
                MyTable = dt;
            }
            this.GridView1.DataSource = MyTable;
            this.GridView1.DataMember = dt.TableName;
            this.GridView1.DataKeyNames = new String[] { "col1" };
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SingleClick")
            { 
                //启动编辑，把某个单元格设置为编辑
            }
            else if (e.CommandName == "New")
            {
                MyTable.RejectChanges();
                MyTable.Rows.InsertAt(MyTable.NewRow(), Convert.ToInt32(e.CommandArgument)+1);
                GridView1.EditIndex = Convert.ToInt32(e.CommandArgument) + 1;
                bindGrid();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //this.GridView1.SetEditRow(e.NewEditIndex);
            GridView1.EditIndex = e.NewEditIndex;  //GridView编辑项索引等于单击行的索引
            bindGrid();
        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //首先判断是否是数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标停留时更改背景色
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='Aqua'");
                //当鼠标移开时还原背景色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //新增
            if (MyTable.Rows[e.RowIndex].RowState==DataRowState.Added)
            {
                var lastrow = MyTable.Rows[e.RowIndex];
                TextBox txt1 = GridView1.Rows[e.RowIndex].FindControl("colEdit1") as TextBox;
                if (txt1 != null)
                {
                    lastrow["col1"] = txt1.Text.Trim();
                }
                TextBox txt2 = GridView1.Rows[e.RowIndex].FindControl("colEdit2") as TextBox;
                if (txt2 != null)
                {
                    lastrow["col2"] = txt2.Text.Trim();
                }
                TextBox txt3 = GridView1.Rows[e.RowIndex].FindControl("colEdit3") as TextBox;
                if (txt3 != null)
                {
                    lastrow["col3"] = txt3.Text.Trim();
                }
                MyTable.AcceptChanges();
                GridView1.EditIndex = -1;
            }
            else if (MyTable.Rows[e.RowIndex].RowState == DataRowState.Modified || MyTable.Rows[e.RowIndex].RowState ==  DataRowState.Unchanged)
            {
                //编辑
                //查询出当前行记录
                StringBuilder sb = new StringBuilder(" 1=1 ");
                foreach (DictionaryEntry item in e.Keys)
                {
                    sb.Append(" and " + item.Key + "='" + item.Value + "' ");
                }
                DataRow[] rows = MyTable.Select(sb.ToString());
                TextBox txt1 = GridView1.Rows[e.RowIndex].FindControl("colEdit1") as TextBox;
                if (txt1 != null)
                {
                    rows[0]["col1"] = txt1.Text.Trim();
                }
                TextBox txt2 = GridView1.Rows[e.RowIndex].FindControl("colEdit2") as TextBox;
                if (txt2 != null)
                {
                    rows[0]["col2"] = txt2.Text.Trim();
                }
                
                var txt3 = GridView1.Rows[e.RowIndex].FindControl("colEdit3") as System.Web.UI.HtmlControls.HtmlSelect;
               
                if (txt3 != null)
                {
                    rows[0]["col3"] = txt3.Value.Trim(); 
                }
                MyTable.AcceptChanges();
                GridView1.EditIndex = -1;
            }
            bindGrid();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
           
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            MyTable.RejectChanges();
            GridView1.EditIndex = -1;
            bindGrid();
        }
    }
}