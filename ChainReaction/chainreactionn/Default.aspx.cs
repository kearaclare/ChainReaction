using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!Page.IsPostBack)
        {
            Latest_Glossary();
            LoadPeople();
            Latest_Entities();
            Latest_UseCases();
            LoadQuestions();

            ViewState.Add("Language", CultureInfo.CurrentUICulture.Name);
        }
        else
        {
            if (CultureInfo.CurrentUICulture.Name != ViewState["Language"].ToString())
            {
                Latest_Glossary();
                LoadPeople();
                Latest_Entities();
                Latest_UseCases();
                LoadQuestions();
                ViewState["Language"] = CultureInfo.CurrentUICulture.Name;
            }
        }


        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            btnUnderstandBlockchain.Text = "Understand Blockchain in 3 Minutes";
            lblBanner.Text = "Dedicated to empower everyone with Blockchain knowledge";
            lblQuestions.Text = "Top Blockchain Questions";
            lblLastestStartups.Text = "Disruptors of The Week";
            lblGlossary.Text = "Top Blockchain Vocabulary";
            lblPeople.Text = "Blockchain People";
            lblLatestUseCase.Text = "Latest Blockchain Use Cases";
        }
        else
        {
            btnUnderstandBlockchain.Text = "三点钟无眠没必要<br/>三分钟搞懂区块链";
            lblBanner.Text = "致力于帮助世界上每个人迅速学习了解区块链";
            lblQuestions.Text = "常见区块链问题";
            lblLastestStartups.Text = "最新创业公司排行";
            lblGlossary.Text = "最新区块链专业术语";
            lblPeople.Text = "最新区块链人物";
            lblLatestUseCase.Text = "最新区块链应用场景";
        }
    }

    protected void Latest_Glossary()
    {
        lvGlossary.DataSource = GeneralClass.GetAll("View_Top_Glossary", "");
        lvGlossary.DataBind();
    }
    
    //protected DataSet GetAllGlossary()
    //{
    //    string strConString;
    //    SqlConnection conJobs;
    //    SqlDataAdapter dadItems;
    //    DataSet dstItems;
    //    string SelectCmd;
    //    SelectCmd = "select top 20 * from " + "View_Glossary" + " " + "order by ListOrder desc;";
    //    strConString = ConfigurationManager.ConnectionStrings["BootCamp"].ConnectionString;
    //    conJobs = new SqlConnection(strConString);
    //    dstItems = new DataSet();
    //    dadItems = new SqlDataAdapter(SelectCmd, conJobs);
    //    dadItems.Fill(dstItems, "NewItems");

    //    return dstItems;
    //}



    protected void Latest_Entities()
    {
        dlLastestStartups.DataSource = GeneralClass.GetAll("View_Top12_Lastest_Entities", "");
        dlLastestStartups.DataBind();
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

    protected string ReadEntityName(object EntityID)
    {
        string strReturn = GeneralClass.ReadOneFieldFromOneField("Name", "Entities", "ID", EntityID.ToString(), "");
        string strOneLiner = GeneralClass.ReadOneFieldFromOneField("OneLiner", "Entities", "ID", EntityID.ToString(), "");
        if (!string.IsNullOrEmpty(strOneLiner))
        {
            strReturn = strReturn + " - " + strOneLiner;
        }
        return strReturn;
    }


    protected string ReadLogoPath2(object EntityID, object FileExtension, object LogoType)
    {
        string strReturn = "";

        if (!string.IsNullOrEmpty(FileExtension.ToString()))
        {
            strReturn = "~/Entities/Logo/" + EntityID.ToString() + "/" + LogoType.ToString() + "/" + "FullSize" + FileExtension.ToString();
            //Enable localhost view logo image from remote web server
            strReturn = GeneralClass.LocalhostLogoPath(strReturn);
        }
        return strReturn;
    }



    protected string ReadEntityName2(object EntityID, object Name, object Name_CN, object OneLiner, object OneLiner_CN)
    {
        string strReturn = "";
        strReturn = Name.ToString();
        string strOneLiner = OneLiner.ToString();
        if (!string.IsNullOrEmpty(strOneLiner))
        {
            strReturn = strReturn + " - " + strOneLiner;
        }
        return strReturn;
    }


    protected void btnUnderstandBlockchain_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Blockchain/Understand");
    }


    protected void Latest_UseCases()
    {
        dlUseCasesLatest.DataSource = GeneralClass.GetAll("View_Lastest_UseCases", "");
        dlUseCasesLatest.DataBind();
    }

    protected string ReadUseCases(object Name, object Name_CN, object ID, object Level1_ID, object Level2_ID)
    {
        string strReturn;

        if (CultureInfo.CurrentUICulture.Name == "en-US"){
            strReturn = GeneralClass.ReadOneFieldFromOneField("Name", "UseCase_BC_Level1", "ID", Level1_ID.ToString(), "");
            strReturn = strReturn + " >> " + GeneralClass.ReadOneFieldFromOneField("Name", "UseCase_BC_Level2", "ID", Level2_ID.ToString(), "");
            strReturn = strReturn + " >> " + Name.ToString();
        }
        else{
            strReturn = GeneralClass.ReadOneFieldFromOneField("Name_CN", "UseCase_BC_Level1", "ID", Level1_ID.ToString(), "");
            strReturn = strReturn + " >> " + GeneralClass.ReadOneFieldFromOneField("Name_CN", "UseCase_BC_Level2", "ID", Level2_ID.ToString(), "");
            strReturn = strReturn + " >> " + Name_CN.ToString();
        }
        return strReturn;
    }




    protected void LoadPeople()
    {
        //dlPeople.DataSource = PeopleClass.GetAll("People", "where id>1 order by id desc;");
        //dlPeople.DataBind();
    }


    protected string ReadImagePath(object PeopleID)
    {
        string strReturn = "";
        ////string TableID = PeopleClass.ReadOneFieldFromOneID("Id", "People_Logo", PeopleID.ToString());
        //string FileExtension = PeopleClass.ReadOneFieldFromOneField("FileExtension", "People_Logo", "PeopleID", PeopleID.ToString(), "");
        //string LogoType = PeopleClass.ReadOneFieldFromOneField("LogoType", "People_Logo", "PeopleID", PeopleID.ToString(), "");

        //if (!string.IsNullOrEmpty(FileExtension))
        //{
        //    strReturn = "~/People/Logo/" + PeopleID.ToString() + "/" + LogoType + "/" + "FullSize" + FileExtension;
        //    //Enable localhost view logo image from remote web server
        //    strReturn = GeneralClass.LocalhostLogoPath(strReturn);
        //}
        return strReturn;
    }

    protected Unit SetImageWidth(object PeopleID)
    {
        //string Width = PeopleClass.ReadOneFieldFromOneField("Width", "People_Logo", "PeopleID", PeopleID.ToString(), "");
        //string Height = PeopleClass.ReadOneFieldFromOneField("Height", "People_Logo", "PeopleID", PeopleID.ToString(), "");
        //int destWidth = 0;

        //if (!string.IsNullOrEmpty(Width))
        //{
        //    int sourceWidth = Convert.ToInt32(Width);
        //    int sourceHeight = Convert.ToInt32(Height);

        //    if (sourceWidth > 50)
        //    {
        //        destWidth = 50;
        //    }
        //    else
        //    {
        //        destWidth = sourceWidth;
        //    }
        //}

        //return new Unit(destWidth);
        return new Unit(120);
    }

    protected string ReadFullName(object FirstName, object LastName, object AkaName, object FirstName_CN, object LastName_CN, object AkaName_CN)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn += "<b>" + FirstName.ToString() + " " + LastName.ToString() + "</b>";

            if (!string.IsNullOrEmpty(AkaName.ToString()))
            {
                strReturn = strReturn + " (<b>" + AkaName.ToString() + "</b>)";
            }
        }
        else
        {
            strReturn += "<b>" + LastName_CN.ToString() + "" + FirstName_CN.ToString() + "</b>";

            if (!string.IsNullOrEmpty(AkaName_CN.ToString()))
            {
                strReturn = strReturn + " (<b>" + AkaName_CN.ToString() + "</b>)";
            }
        }
        return strReturn + "";
    }

    protected string ReadUrlPath(object EntityID)
    {
        string strReturn = "~/Entities/Entity.aspx?EntityID=" + EntityID.ToString();

        //strReturn = GeneralClass.ReadOneFieldFromOneField("WebLink", "Entity_WebLink", "EntityID", EntityID.ToString(), "");

        return strReturn;
    }

    protected void LoadQuestions() {
        dlQuestions.DataSource = GetAllQuestions();
        dlQuestions.DataBind();
    }

    protected DataSet GetAllQuestions()
    {
        string strConString;
        SqlConnection conJobs;
        SqlDataAdapter dadItems;
        DataSet dstItems;
        string SelectCmd;
        SelectCmd = "select top 6 * from " + "Question" + " " + "order by ListOrder desc;";
        strConString = ConfigurationManager.ConnectionStrings["BootCamp"].ConnectionString;
        conJobs = new SqlConnection(strConString);
        dstItems = new DataSet();
        dadItems = new SqlDataAdapter(SelectCmd, conJobs);
        dadItems.Fill(dstItems, "NewItems");

        return dstItems;
    }

    protected string ReadQuestions(object Question, object Question_CN)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = Question.ToString();
        }
        else
        {
            strReturn = Question_CN.ToString();
        }

        return strReturn;
    }

    protected string ReadGlossary(object Name, object Name_CN)
    {
        string strReturn = "";

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


    protected void btnSearchGlossary_Click(object sender, EventArgs e)
    {
        string strGlossaryID = DoSearch(txtSearchGlossary.Text);
        Response.Redirect("~/Listing/Glossary/Glossary.aspx?id=" + strGlossaryID);
    }

    protected string DoSearch(string strTerm)
    {

        string strReturn="";

        if (string.IsNullOrEmpty(strTerm))
        {
            strReturn = "0";
        }
        else {
            strReturn = GeneralClass.ReadOneFieldFromQuery("id", FormatSearchString(strTerm));
            if (string.IsNullOrEmpty(strReturn))
            {
                strReturn = "0";
            }
        }
        return strReturn;
    }


    protected string FormatSearchString(string strTerm)
    {
        string strSQL;
        string strSQLSelect;
        string strSQLFrom;
        string strSQLWhere;

        strSQLSelect = "select id ";
        strSQLFrom = " from Glossary ";

        strSQLWhere = " where ";

        strSQLWhere += " (name like '%" + strTerm.Trim() + "%') ";
        strSQLWhere += " or (name_cn like '%" + strTerm.Trim() + "%') ";

        strSQL = strSQLSelect + strSQLFrom + strSQLWhere;

        return strSQL;
    }
}