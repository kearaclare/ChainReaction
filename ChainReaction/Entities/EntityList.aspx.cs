using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Diagnostics;

public partial class Entities_EntityList : Page
{
    //string selectedLanguage = "zh-CN";
    string selectedLanguage = "en-US";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (selectedLanguage == "en-US")
        //{
        //    gvDataGrid.PagerSettings.FirstPageText = "<< First";
        //    gvDataGrid.PagerSettings.PreviousPageText = "< Previous ";
        //    gvDataGrid.PagerSettings.NextPageText = " Next >";
        //    gvDataGrid.PagerSettings.LastPageText = "Last >>";
        //}
        //else
        //{
        //    gvDataGrid.PagerSettings.FirstPageText = "<< diyige";
        //    gvDataGrid.PagerSettings.PreviousPageText = "< shangyige ";
        //    gvDataGrid.PagerSettings.NextPageText = " xiayege >";
        //    gvDataGrid.PagerSettings.LastPageText = "zuihou >>";
        //}

        //if(gvDataGrid.PageIndex == 0)
        //{
            
        //}


        if (!Page.IsPostBack)
        {

            string selectedLanguage = "en-US";
            //string selectedLanguage = "zh-CN";



            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(selectedLanguage);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);

            //LoadEntityTypeList();
            //GetAllEntities();

            LoadEntityTypeList();
            GetAllEntities();
            ViewState["Language"] = CultureInfo.CurrentUICulture.Name;



            //if (CultureInfo.CurrentUICulture.Name == "en-US")
            //{
            //    gvDataGrid.PagerSettings.FirstPageText = "<< First";
            //}
            //else
            //{
            //    gvDataGrid.PagerSettings.FirstPageText = "<< diyige";
            //}

            //ViewState.Add("Language", CultureInfo.CurrentUICulture.Name);
        }
        //else
        //{

        //    if (CultureInfo.CurrentUICulture.Name != ViewState["Language"].ToString())
        //    {
        //        LoadEntityTypeList();
        //        GetAllEntities();
        //        ViewState["Language"] = CultureInfo.CurrentUICulture.Name;
        //    }
        //}
    }


    protected void LoadEntityTypeList()
    {
        string strName = "";
        string strAll = "";
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strName = "Name";
            strAll = "All Type";
        }
        else
        {
            strName = "Name_CN";
            strAll = "所有类型";
        }

        rblEntityPosition.DataSource = GeneralClass.GetAll("Entity_Position", " where id > 0 order by ListOrder desc;");
        rblEntityPosition.DataValueField = "id";
        rblEntityPosition.DataTextField = strName;
        rblEntityPosition.DataBind();
        //rblBlockchainType.Items.Insert(0, new ListItem(strAll, "0"));
    }

    protected void gvDataGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDataGrid.PageIndex = e.NewPageIndex;
        GetAllEntities();


    }


    protected void GetAllEntities()
    {
        gvDataGrid.DataSource = GeneralClass.GetAll("Entities", "where id>0" + " order by id desc");
        gvDataGrid.DataBind();
    }

    public static string ReadEntityBasic(object DateFounded)
    {
        string strReturn = "";

        if (!string.IsNullOrEmpty(DateFounded.ToString()))
        {
            //if (!string.IsNullOrEmpty(strReturn))
            //{
            strReturn += "<br/>";
            //}
            strReturn += "Founded: ";
            DateTime dt = DateTime.Parse(DateFounded.ToString());
            strReturn += dt.ToString("yyyy-MM-dd") + "";
        }

        return strReturn;
    }

    public static string ReadOneLiner(object OneLiner)
    {
        string strReturn = "";

        if (!string.IsNullOrEmpty(OneLiner.ToString()))
        {
            strReturn += OneLiner.ToString() + "";
        }

        return strReturn;
    }

    //public static string ReadOneLiner(object OneLiner, object OneLiner_CN)
    //{
    //    string strReturn = OneLiner.ToString();

    //    if (CultureInfo.CurrentUICulture.Name == "en-US")
    //    {
    //        strReturn = OneLiner.ToString();
    //    }
    //    else
    //    {
    //        strReturn = OneLiner_CN.ToString();
    //    }

    //    return strReturn;
    //}

    public static DataSet LoadEntityTypeList(object id)
    {
        return GeneralClass.GetAll("View_Entity_Type_Name_By_EntityID", "where EntityID=" + id.ToString() + ";");
    }

    protected string Read_BC_UseCase(object Level1_ID, object Level2_ID, object Level3_ID)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            if (Level1_ID.ToString() != "0")
            {
                strReturn += GeneralClass.ReadOneFieldFromOneID("Name", "UseCase_BC_Level1", Level1_ID.ToString());
            }
            if (Level2_ID.ToString() != "0")
            {
                strReturn += " >> " + GeneralClass.ReadOneFieldFromOneID("Name", "UseCase_BC_Level2", Level2_ID.ToString());
            }
            if (Level3_ID.ToString() != "0")
            {
                strReturn += " >> " + GeneralClass.ReadOneFieldFromOneID("Name", "UseCase_BC_Level3", Level3_ID.ToString());
            }
        }
        else
        {
            if (Level1_ID.ToString() != "0")
            {
                strReturn += GeneralClass.ReadOneFieldFromOneID("Name_CN", "UseCase_BC_Level1", Level1_ID.ToString());
            }
            if (Level2_ID.ToString() != "0")
            {
                strReturn += " >> " + GeneralClass.ReadOneFieldFromOneID("Name_CN", "UseCase_BC_Level2", Level2_ID.ToString());
            }
            if (Level3_ID.ToString() != "0")
            {
                strReturn += " >> " + GeneralClass.ReadOneFieldFromOneID("Name_CN", "UseCase_BC_Level3", Level3_ID.ToString());
            }
        }

        return strReturn;
    }






    protected DataSet Load_BC_UseCase_List(object id)
    {
        return GeneralClass.GetAll("Entity_UseCase_BC", "where EntityID=" + id.ToString() + " order by ID;");

        //string strReturn = Read_BC_UseCase.ToString();

        //if (CultureInfo.CurrentUICulture.Name == "en-US")
        //{
        //    strReturn = Description.ToString();
        //}
        //else
        //{
        //    strReturn = Description_CN.ToString();
        //}

        //return strReturn;
    }



    protected string ReadNameHeader(object id)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = "Name";
        }
        else
        {
            strReturn = "名称";
        }
        return strReturn;
    }

    protected string ReadDescriptionHeader(object id)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = "Description";
        }
        else
        {
            strReturn = "简介";
        }
        return strReturn;
    }

    protected string ReadUseCaseHeader(object id)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = "Blockchain Use Case";
        }
        else
        {
            strReturn = "区块链应用场景";
        }
        return strReturn;
    }



    protected string ReadLogoPath(object EntityID)
    {
        string strReturn = "";
        //string TableID = GeneralClass.ReadOneFieldFromOneID("Id", "Entity_Logo", EntityID.ToString());
        string FileExtension = GeneralClass.ReadOneFieldFromOneField("FileExtension", "Entity_Logo", "EntityID", EntityID.ToString(), "");
        string LogoType = GeneralClass.ReadOneFieldFromOneField("LogoType", "Entity_Logo", "EntityID", EntityID.ToString(), "");

        if (!string.IsNullOrEmpty(FileExtension))
        {
            strReturn = "~/Entities/Logo/" + EntityID.ToString() + "/" + LogoType + "/" + "FullSize" + FileExtension;
            //Enable localhost view logo image from remote web server
            strReturn = GeneralClass.LocalhostLogoPath(strReturn);
        }
        return strReturn;
    }

    protected Unit SetLogoWidth(object EntityID)
    {
        string Width = GeneralClass.ReadOneFieldFromOneField("Width", "Entity_Logo", "EntityID", EntityID.ToString(), "");
        string Height = GeneralClass.ReadOneFieldFromOneField("Height", "Entity_Logo", "EntityID", EntityID.ToString(), "");
        int destWidth = 0;

        if (!string.IsNullOrEmpty(Width))
        {
            int sourceWidth = Convert.ToInt32(Width);
            int sourceHeight = Convert.ToInt32(Height);

            if (sourceWidth > 25)
            {
                destWidth = 25;
            }
            else
            {
                destWidth = sourceWidth;
            }
        }

        return new Unit(destWidth);
        //return new Unit(120);
    }


    public static string ReadWebLink(object TableID)
    {
        string strReturn = "";

        strReturn += "" + GeneralClass.ReadOneFieldFromOneID("WebLink", "Entity_WebLink", TableID.ToString());

        //Clean the http address so it will open in browser
        strReturn = GeneralClass.CleanHttpString(strReturn);

        return strReturn;
    }

    public static string ReadWebLinkType(object TableID)
    {
        string strReturn = "";
        string strID = GeneralClass.ReadOneFieldFromOneID("TagID", "Entity_WebLink", TableID.ToString());
        strReturn += "" + GeneralClass.ReadOneFieldFromOneID("Name", "Entity_WebLink_Tag", strID);

        return strReturn + ":";
    }





    public static DataSet LoadWebLinkList(object id)
    {
        return GeneralClass.GetAll("Entity_WebLink", "where EntityID=" + id.ToString() + " order by ID;");
    }




    protected void btnSearchEntity_Click(object sender, EventArgs e)
    {
        //string strEntityID = DoSearch(txtSearchEntity.Text);
        //Response.Redirect("~/Listing/Entity/Entity.aspx?id=" + strEntityID);

        lblSearchResult.Text = "";

        DataSet dstItems;
        if (!string.IsNullOrEmpty(txtSearchEntity.Text))
        {
            dstItems = GeneralClass.GetAllFromQuery(FormatSearchString(txtSearchEntity.Text));
            if (dstItems.Tables[0].Rows.Count > 0)
            {
                gvDataGrid.DataSource = dstItems;
                gvDataGrid.DataBind();
            }
            else
            {
                gvDataGrid.Dispose();
                gvDataGrid.DataBind();
                //lblSearchResult.Text = "No search results...";
            }


        }

        //if (gvDataGrid.Rows.Count <1) {

        //    GetAllEntities();
        //    lblSearchResult.Text = "No search results...";
        //}
    }




    protected string FormatSearchString(string strTerm)
    {
        string strSQL;
        string strSQLSelect;
        string strSQLFrom;
        string strSQLWhere;

        strSQLSelect = "select * ";
        strSQLFrom = " from Entities ";

        strSQLWhere = " where ";

        strSQLWhere += " (name like '%" + strTerm.Trim() + "%') ";
        strSQLWhere += " or (name_cn like '%" + strTerm.Trim() + "%') ";

        strSQL = strSQLSelect + strSQLFrom + strSQLWhere;

        return strSQL;
    }
    /*
        //This function displays "Page x/xx" in the footer of gridview
        protected void gvDataGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                LiteralControl control = new LiteralControl();
                control.Text = "&nbsp&nbsp&nbsp" + "Page " + (gvDataGrid.PageIndex + 1) + " of " + gvDataGrid.PageCount;
                Table table = e.Row.Cells[0].Controls[0] as Table;
                TableCell newCell = new TableCell();
                newCell.Controls.Add(control);
                table.Rows[0].Cells.Add(newCell);



            }



        }
        */

    protected void gvDataGrid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //This function implements custom paging
    protected void GvDataGrid_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FirstButton")
        {
            
            gvDataGrid.PageIndex = 0;
            GetAllEntities();
        }
        if (e.CommandName == "LastButton")
        {          
            gvDataGrid.PageIndex = gvDataGrid.PageCount;
            GetAllEntities();
        }
        if (e.CommandName == "NextButton")
        {
            
            int i = gvDataGrid.PageIndex + 1;
            if(i <= gvDataGrid.PageCount)

            {
                gvDataGrid.PageIndex = i;
            }
            GetAllEntities();

        }
        if (e.CommandName == "PreviousButton")
        {

            int i = gvDataGrid.PageCount;
             if(gvDataGrid.PageIndex > 0)
            {
                gvDataGrid.PageIndex = gvDataGrid.PageIndex - 1;
            }
            GetAllEntities();
        }

    }

    protected void GvDataGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
        }
    }

    protected void GvDataGrid_OnDataBound(object sender, EventArgs e)
    {
        SetPaging();
    }

    public void SetPaging()
    {
        GridViewRow PagerRow = gvDataGrid.BottomPagerRow;
        LinkButton first = (LinkButton)PagerRow.FindControl("lbFirst");
        LinkButton previous = (LinkButton)PagerRow.FindControl("lbPrevious");
        LinkButton next = (LinkButton)PagerRow.FindControl("lbNext");
        LinkButton last = (LinkButton)PagerRow.FindControl("lbLast");

        int lastpage = gvDataGrid.PageCount;
        int currentpage = gvDataGrid.PageIndex + 1;
        Label DisplayCurrentIndex = (Label)PagerRow.FindControl("PageCounter");

        if (selectedLanguage == "en-US")
        {
            first.Text = "<< First";
            previous.Text = "< Previous &nbsp&nbsp";
            next.Text = " Next >";
            last.Text = "Last >>";
            DisplayCurrentIndex.Text = "Page " + currentpage + "/" + lastpage;
        }
        else
        {
            first.Text = "<< Shouye";
            previous.Text = "< qianyiye &nbsp&nbsp";
            next.Text = " xiayiye >";
            last.Text = "weiye >>";
            DisplayCurrentIndex.Text = "ye " + currentpage + "/" + lastpage;
        }

        if(currentpage == 1)
        {
            first.ForeColor = System.Drawing.Color.Gray;
            first.Enabled = false;
            previous.ForeColor = System.Drawing.Color.Gray;
            previous.Enabled = false;
        }

        if (currentpage == lastpage)
        {
            last.ForeColor = System.Drawing.Color.Gray;
            last.Enabled = false;
            next.ForeColor = System.Drawing.Color.Gray;
            next.Enabled = false;
        }


    }
}

