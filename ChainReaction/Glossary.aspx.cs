using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Glossary : Page
{
    string selectedLanguage = "en-US";
    //string selectedLanguage = "zh-CN";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //string selectedLanguage = "en-US";
            //string selectedLanguage = "zh-CN";

            if (selectedLanguage == "zh-CN")
            {
                StylingGlossaryTop_CHN.Attributes["class"] = "StyleGlossaryTextCHN";
                


            }

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(selectedLanguage);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);

            LoadGlossaryTypeList();
            rblGlossaryType.SelectedValue = "0";
            ViewState.Add("GlossaryType", rblGlossaryType.SelectedValue);
            PopulateGrid(rblGlossaryType.SelectedValue);

            //ViewState.Add("Language", CultureInfo.CurrentUICulture.Name);

            if (Request.QueryString["id"] != null)
            {
                ViewState.Add("id", Request.QueryString["id"]);
                if (ViewState["id"].ToString() == "0")
                {
                    lblHeader.Text = "Search Found No Results";
                    lblDescription.Text = "";
                    phSearchResults.Visible = true;
                }
                else
                {
                    GetGlossaryById(ViewState["id"].ToString());
                    phSearchResults.Visible = true;
                }
            }



        }
        //else
        //{

        //    if (CultureInfo.CurrentUICulture.Name != ViewState["Language"].ToString())
        //    {
        //        //gvGlossary.DataSource = GetAll();
        //        //gvGlossary.DataBind();
        //        LoadGlossaryTypeList();
        //        rblGlossaryType.SelectedValue = ViewState["GlossaryType"].ToString();
        //        PopulateGrid(rblGlossaryType.SelectedValue);
        //        if (phSearchResults.Visible) {
        //            GetGlossaryById(ViewState["id"].ToString());
        //        }
        //        ViewState["Language"] = CultureInfo.CurrentUICulture.Name;
        //    }
        //}

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            //lblTitle.ForeColor = System.Drawing.Color.FromArgb(0x00, 0x77, 0xbb);
            lblTitle.Font.Bold = true;
            lblTitle.Text = "Blockchain Glossary";
        }
        else
        {
            lblTitle.Text = "中英文对照区块链词汇表";
        }
    }


    protected void GetGlossaryById(string GlossaryID)
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            lblHeader.Text = GeneralClass.ReadOneFieldFromOneField("Name", "Glossary", "ID", GlossaryID, "");
            lblDescription.Text = GeneralClass.ReadOneFieldFromOneField("Description", "Glossary", "ID", GlossaryID, "");
        }
        else
        {
            lblHeader.Text = GeneralClass.ReadOneFieldFromOneField("Name_CN", "Glossary", "ID", GlossaryID, "");
            lblDescription.Text = GeneralClass.ReadOneFieldFromOneField("Description_CN", "Glossary", "ID", GlossaryID, "");
        }

    }

    protected void GetGlossaryBySearchTerm(string strTerm)
    {
        //lblHeader.Text = GeneralClass.ReadOneFieldFromOneField("Name", "Glossary", "ID", GlossaryID, "");
        //lblDescription.Text = GeneralClass.ReadOneFieldFromOneField("Description", "Glossary", "ID", GlossaryID, "");
    }

    protected void ResetSearchParam()
    {
        lblHeader.Text = "";
        lblDescription.Text = "";
        phSearchResults.Visible = false;
    }

    protected void PopulateGrid(string strType)
    {
        string TailValue;
        string TableName;

        if (strType == "0")
        {
            TableName = "View_Glossary";
            TailValue = "where id>0";
        }
        else
        {
            TableName = "View_Glossary";
            TailValue = "where Type=" + strType;
        }

        gvGlossary.DataSource = GeneralClass.GetAll(TableName, TailValue + " order by ListOrder desc;");
        gvGlossary.DataBind();
        //TailValue = TailValue + " order by ListOrder desc;";
        //Label1.Text = "select * from " + TableName + " " + TailValue;
    }

    protected string ReadName(object Name, object Name_CN)
    {
        string strReturn = Name.ToString();

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = Name.ToString();
        }
        else
        {
            strReturn = Name_CN.ToString();
        }

        return strReturn;
    }

    protected string ReadType(object TypeName, object TypeName_CN)
    {
        string strReturn = TypeName.ToString();

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = TypeName.ToString();
        }
        else
        {
            strReturn = TypeName_CN.ToString();
        }

        return strReturn;
    }

    protected string ReadDescription(object Description, object Description_CN)
    {
        string strReturn = Description.ToString();

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = Description.ToString();
        }
        else
        {
            strReturn = Description_CN.ToString();
        }

        return strReturn;
    }


    //protected void rbl_BC_Language_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (rbl_BC_Language.SelectedValue == "EN")
    //    {
    //        ViewState["Language"] = "EN";
    //    }
    //    else
    //    {
    //        ViewState["Language"] = "CN";
    //    }
    //    Label1.Text = GlossaryType.SelectedValue;

    //    gvGlossary.DataSource = GetAll();
    //    gvGlossary.DataBind();
    //}

    protected void TestMail(object sender, EventArgs e)
    {
        //MessageClass.SendMail("Hello", "josephhensersky@gmail.com", "Hello from the team!", false);
    }


    protected void LoadGlossaryTypeList()
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

        //rblGlossaryType.DataSource = GetAllGlossaryType();
        rblGlossaryType.DataSource = GeneralClass.GetAll("Glossary_Type", " where id>0 order by ListOrder desc;");
        rblGlossaryType.DataValueField = "id";
        rblGlossaryType.DataTextField = strName;
        rblGlossaryType.DataBind();
        rblGlossaryType.Items.Insert(0, new ListItem(strAll, "0"));
    }

    protected void rblGlossaryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["GlossaryType"] = rblGlossaryType.SelectedValue;
        PopulateGrid(rblGlossaryType.SelectedValue);
        ResetSearchParam();
    }




    protected string ReadTypeHeader(object id)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = "Glossary Type";
        }
        else
        {
            strReturn = "词汇类型";
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
            strReturn = "解释";
        }
        return strReturn;
    }
/*This code allows you to style the Glossary table in Chinese without effecting what it looks like in English*/
    protected void gvGlossary_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (selectedLanguage == "zh-CN")
        {
            StylingGlossaryTop_CHN.Attributes["class"] = "StyleGlossaryTextCHN"; 

            gvGlossary.Columns[0].ItemStyle.CssClass = "AddChineseFontC1";
            gvGlossary.Columns[1].ItemStyle.CssClass = "AddChineseFont";
            gvGlossary.Columns[2].ItemStyle.CssClass = "AddChineseFontC1";

        }
        //write your code here to control the look of the font!
        //gvGlossary.Columns[0].ItemStyle.CssClass = "AddChineseFont";
        //gvGlossary.Columns[1].ItemStyle.CssClass = "AddChineseFont";
        //gvGlossary.Columns[2].ItemStyle.CssClass = "AddChineseFont";
    }

    //protected string ReadDescriptionHeader(object id)
    //{
    //    string strReturn = "";

    //    if (CultureInfo.CurrentUICulture.Name == "en-US")
    //    {
    //        strReturn = "Description";
    //    }
    //    else
    //    {
    //        strReturn = "解释";
    //    }
    //    return strReturn;
    //}


}