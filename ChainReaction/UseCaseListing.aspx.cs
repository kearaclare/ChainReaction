using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Blockchain_UseCaseListing : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lb_xxxUseCase_BC_Level1xxx.BorderStyle = BorderStyle.None;
            lb_xxxUseCase_BC_Level2xxx.BorderStyle = BorderStyle.None;
            lb_xxxUseCase_BC_Level3xxx.BorderStyle = BorderStyle.None;
        

            //'if (GeneralClass.UserName() == "dh" || GeneralClass.UserName() == "mubin"){
            //'    hlEdit.Visible = true;
            //'}

            LoadUseCase_BC_Level1();

            ViewState.Add("Language", CultureInfo.CurrentUICulture.Name);
            //ViewState.Add("PageTitle", Page.Title);

            if (Request.QueryString["Level3_ID"] != null)
            {
                ViewState.Add("Level3_ID", Request.QueryString["Level3_ID"]);
                SetSelectValueLevel3(ViewState["Level3_ID"].ToString());
                LoadOnlyLevel3(ViewState["Level3_ID"].ToString());
                Timer1.Enabled = false;
                //lb_xxxUseCase_BC_Level2xxx.Visible = true;
                //lb_xxxUseCase_BC_Level3xxx.Visible = true;
                lb_xxxUseCase_BC_Level2xxx.BorderStyle = BorderStyle.NotSet;
                lb_xxxUseCase_BC_Level3xxx.BorderStyle = BorderStyle.NotSet;
            }
            else {
                //phStart.Visible = true;
                //SetStartText();
                Timer1.Enabled = false;

                //Set selected level 1  13=Financial
                lb_xxxUseCase_BC_Level2xxx.Items.Clear();
                lb_xxxUseCase_BC_Level3xxx.Items.Clear();
                LoadUseCase_BC_Level2("13");
                ResetLogoGrid();
                LoadOnlyLevel2("13");
                //lb_xxxUseCase_BC_Level2xxx.Visible = true;
                lb_xxxUseCase_BC_Level2xxx.BorderStyle = BorderStyle.NotSet;
                lb_xxxUseCase_BC_Level3xxx.BorderStyle = BorderStyle.NotSet;
                lb_xxxUseCase_BC_Level1xxx.SelectedValue = "13";
            }
        }
        else
        {
            if (CultureInfo.CurrentUICulture.Name != ViewState["Language"].ToString())
            {
                SetSelectedValue(lb_xxxUseCase_BC_Level1xxx.SelectedValue, lb_xxxUseCase_BC_Level2xxx.SelectedValue, 
                        lb_xxxUseCase_BC_Level3xxx.SelectedValue, lb_xxxUseCase_BC_Level1xxx.SelectedIndex, 
                            lb_xxxUseCase_BC_Level2xxx.SelectedIndex, lb_xxxUseCase_BC_Level3xxx.SelectedIndex);
                SetStartText();
                ViewState["Language"] = CultureInfo.CurrentUICulture.Name;
            }

            //Page.Title = ViewState["PageTitle"].ToString();
        }
    }

    protected void SetStartText() {
        if (CultureInfo.CurrentUICulture.Name == "en-US"){
            lblStartHere.Text = "Start Here";
        }
        else{
            lblStartHere.Text = "这里开始";
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Timer1.Enabled = false;
        phStart.Visible = false;
    }

    protected void SetSelectValueLevel3(string Level3_ID) {
        string Level2_ID = GeneralClass.ReadOneFieldFromOneID("Level2_ID", "UseCase_BC_Level3", Level3_ID);
        string Level1_ID = GeneralClass.ReadOneFieldFromOneID("Level1_ID", "UseCase_BC_Level3", Level3_ID);

        lb_xxxUseCase_BC_Level1xxx.SelectedValue = Level1_ID;
        LoadUseCase_BC_Level2(Level1_ID);
        lb_xxxUseCase_BC_Level2xxx.SelectedValue = Level2_ID;
        LoadUseCase_BC_Level3(Level2_ID);
        lb_xxxUseCase_BC_Level3xxx.SelectedValue = Level3_ID;
    }

    protected void SetSelectedValue(string Level1_ID, string Level2_ID, string Level3_ID, int Level1_Index, int Level2_Index, int Level3_Index)
    {
        //if (lb_xxxUseCase_BC_Level1xxx.SelectedIndex > -1)
        //{
        LoadUseCase_BC_Level1();
        if (!string.IsNullOrEmpty(Level1_ID))
        {
            lb_xxxUseCase_BC_Level1xxx.SelectedValue = Level1_ID;
            if (Level1_ID != "0"){
                LoadUseCase_BC_Level2(Level1_ID);
            }
        }
        //}
        if (Level2_Index > -1)
        {
            if (!string.IsNullOrEmpty(Level2_ID) && Level2_ID != "0") {
                lb_xxxUseCase_BC_Level2xxx.SelectedValue = Level2_ID;
                LoadUseCase_BC_Level3(Level2_ID);
            }
        }
        if (Level3_Index > -1)
        {
            if (!string.IsNullOrEmpty(Level3_ID) && Level3_ID != "0"){
                lb_xxxUseCase_BC_Level3xxx.SelectedValue = Level3_ID;
            }
        }

        //Load Data
        if (Level3_Index > -1){

            ResetLogoGrid();
            LoadOnlyLevel3(lb_xxxUseCase_BC_Level3xxx.SelectedValue);

        }
        else if (Level2_Index > -1){

            ResetLogoGrid();
            LoadLevel_3_Entities(lb_xxxUseCase_BC_Level2xxx.SelectedValue);
            LoadLevel_3_Entities_No_Level3(lb_xxxUseCase_BC_Level2xxx.SelectedValue);
            if (dlShowEntitiesNoLevel3.Items.Count > 0){
                phLevel2NoLevel3.Visible = true;
            }

        }
        else if (Level1_Index > -1){

            if (Level1_ID != "0") {
                ResetLogoGrid();
                LoadOnlyLevel2(lb_xxxUseCase_BC_Level1xxx.SelectedValue);
            }
            else {
                ResetLogoGrid();
                LoadUseCase_BC();
            }
        }

    }


    protected void lb_xxxUseCase_BC_Level1xxx_SelectedIndexChanged(object sender, EventArgs e)
    {

        //UseCase_BC_Level2_ResetParam();

        if (lb_xxxUseCase_BC_Level1xxx.SelectedValue != "0"){
            lb_xxxUseCase_BC_Level2xxx.Items.Clear();
            lb_xxxUseCase_BC_Level3xxx.Items.Clear();
            LoadUseCase_BC_Level2(lb_xxxUseCase_BC_Level1xxx.SelectedValue);
            ResetLogoGrid();
            LoadOnlyLevel2(lb_xxxUseCase_BC_Level1xxx.SelectedValue);
            //lb_xxxUseCase_BC_Level2xxx.Visible = true;
            lb_xxxUseCase_BC_Level2xxx.BorderStyle = BorderStyle.NotSet;
            lb_xxxUseCase_BC_Level3xxx.BorderStyle = BorderStyle.NotSet;
        }
        else {
            lb_xxxUseCase_BC_Level2xxx.Items.Clear();
            lb_xxxUseCase_BC_Level3xxx.Items.Clear();
            ResetLogoGrid();
            LoadUseCase_BC();
            lb_xxxUseCase_BC_Level2xxx.BorderStyle = BorderStyle.None;
            lb_xxxUseCase_BC_Level3xxx.BorderStyle = BorderStyle.None;
        }

        phStart.Visible = false;
        Timer1.Enabled = false;
        //btnUseCase_BC_Level2.Enabled = true;
    }

    protected void lb_xxxUseCase_BC_Level2xxx_SelectedIndexChanged(object sender, EventArgs e)
    {
        //UseCase_BC_Level3_ResetParam();
        lb_xxxUseCase_BC_Level3xxx.Items.Clear();
        //lb_xxxUseCase_BC_Level3xxx.Visible = true;
        LoadUseCase_BC_Level3(lb_xxxUseCase_BC_Level2xxx.SelectedValue);
        //btnUseCase_BC_Level3.Enabled = true;

        ResetLogoGrid();
        LoadLevel_3_Entities(lb_xxxUseCase_BC_Level2xxx.SelectedValue);
        LoadLevel_3_Entities_No_Level3(lb_xxxUseCase_BC_Level2xxx.SelectedValue);
        if (dlShowEntitiesNoLevel3.Items.Count > 0) {
            phLevel2NoLevel3.Visible = true;
        }
    }

    protected void lb_xxxUseCase_BC_Level3xxx_SelectedIndexChanged(object sender, EventArgs e)
    {
        ResetLogoGrid();
        LoadOnlyLevel3(lb_xxxUseCase_BC_Level3xxx.SelectedValue);
    }





    protected void ResetLogoGrid()
    {
        dlUseCases.Dispose();
        dlUseCases.DataBind();
        //phAllUseCases.Visible = false;
        dlUseCasesLevel2.Dispose();
        dlUseCasesLevel2.DataBind();
        dlUseCasesLevel2.Visible = false;
        dlShowEntities.Dispose();
        dlShowEntities.DataBind();
        phLevel2NoLevel3.Visible = false;
        dlShowEntitiesNoLevel3.Dispose();
        dlShowEntitiesNoLevel3.DataBind();
        dlOnlyLevel3.Dispose();
        dlOnlyLevel3.DataBind();
    }


    //Load Listboxes
    protected void LoadUseCase_BC_Level1()
    {
        string strText;
        lb_xxxUseCase_BC_Level1xxx.DataSource = GeneralClass.GetAll("UseCase_BC_Level1", " where id>0 order by ListOrder desc");
        lb_xxxUseCase_BC_Level1xxx.DataValueField = "id";
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            lb_xxxUseCase_BC_Level1xxx.DataTextField = "Name";
            strText = "All";
        }
        else
        {
            lb_xxxUseCase_BC_Level1xxx.DataTextField = "Name_CN";
            strText = "全部";
        }
        lb_xxxUseCase_BC_Level1xxx.DataBind();

        lb_xxxUseCase_BC_Level1xxx.Items.Insert(0, new ListItem(strText, "0"));
    }

    protected void LoadUseCase_BC_Level2(string Level1_ID)
    {
        lb_xxxUseCase_BC_Level2xxx.DataSource = GeneralClass.GetAll("UseCase_BC_Level2", " where Level1_ID=" + Level1_ID + " order by ListOrder asc");
        lb_xxxUseCase_BC_Level2xxx.DataValueField = "id";
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            lb_xxxUseCase_BC_Level2xxx.DataTextField = "Name";
        }
        else
        {
            lb_xxxUseCase_BC_Level2xxx.DataTextField = "Name_CN";
        }
        lb_xxxUseCase_BC_Level2xxx.DataBind();
    }

    protected void LoadUseCase_BC_Level3(string Level2_ID)
    {
        lb_xxxUseCase_BC_Level3xxx.DataSource = GeneralClass.GetAll("UseCase_BC_Level3", " where Level2_ID=" + Level2_ID);
        lb_xxxUseCase_BC_Level3xxx.DataValueField = "id";
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            lb_xxxUseCase_BC_Level3xxx.DataTextField = "Name";
        }
        else
        {
            lb_xxxUseCase_BC_Level3xxx.DataTextField = "Name_CN";
        }
        lb_xxxUseCase_BC_Level3xxx.DataBind();
    }


    


    //Load Datalists
    protected void LoadUseCase_BC()
    {
        //dlUseCases.DataSource = GeneralClass.GetAll("UseCase_BC_Level1", " where id> 0 order by ListOrder desc, id asc");
        dlUseCases.DataSource = GetAllLevel1Data();
        dlUseCases.DataBind();
        //WUC_All_UseCases1.LoadUseCasesGrid();
        //phAllUseCases.Visible=true;
    }

    public DataSet GetAllLevel1Data()
    {
        // if it is in my cache already (notice search criteria is the cache key)
        string cacheKey = "Level1_All";
        if (Cache[cacheKey] != null)
        {
            //Label1.Text = "Cached....";
            return (DataSet)(Cache[cacheKey]);
        }
        else
        {
            DataSet result = GeneralClass.GetAll("UseCase_BC_Level1", " where id> 0 order by ListOrder desc, id asc");
            Cache[cacheKey] = result;  // There are more params needed here...
            //Label1.Text = "Not Cached....";
            return result;
        }
    }

    //public DataTable GetCustomers(bool BypassCache)
    //{
    //    string cacheKey = "CustomersDataTable";
    //    object cacheItem = Cache[cacheKey] as DataTable;
    //    if ((BypassCache) || (cacheItem == null))
    //    {
    //        cacheItem = GetCustomersFromDataSource();
    //        Cache.Insert(cacheKey, cacheItem, null,
    //        DateTime.Now.AddSeconds(GetCacheSecondsFromConfig(cacheKey),
    //        TimeSpan.Zero);
    //    }
    //    return (DataTable)cacheItem;
    //}



    protected void LoadOnlyLevel2(string Level1_ID)
    {
        //dlUseCasesLevel2.DataSource = GeneralClass.GetAll("UseCase_BC_Level2", "where Level1_ID=" + Level1_ID + " order by ListOrder asc;");
        dlUseCasesLevel2.DataSource = CacheGetAllLevel2DataList(Level1_ID);
        dlUseCasesLevel2.DataBind();
        dlUseCasesLevel2.Visible = true;
    }

    public DataSet CacheGetAllLevel2DataList(string Level1_ID)
    {
        // if it is in my cache already (notice search criteria is the cache key)
        string cacheKey = "Level2_" + Level1_ID;
        if (Cache[cacheKey] != null)
        {
            //Label1.Text = "Cached....";
            return (DataSet)Cache[cacheKey];
        }
        else
        {
            //Label1.Text = "Not Cached....";
            DataSet result = GeneralClass.GetAll("UseCase_BC_Level2", "where Level1_ID=" + Level1_ID + " order by ListOrder asc;");
            Cache[cacheKey] = result;  // There are more params needed here...
            return result;
        }
    }

    protected void LoadOnlyLevel3(string Level3_ID)
    {
        dlOnlyLevel3.DataSource = GeneralClass.GetAll("View_Entity_BC_All_Info", "where Level3_ID=" + Level3_ID + ";");
        dlOnlyLevel3.DataBind();
    }

    protected DataSet LoadLevel2EntityList(object id)
    {
        string cacheKey = "Entity_Level2_" + id.ToString();

        Cache.Remove(cacheKey);

        if (Cache[cacheKey] != null)
        {
            //Label1.Text = "Cached....";
            return (DataSet)Cache[cacheKey];
        }
        else
        {
            //Label1.Text = "Not Cached....";
            DataSet result = GeneralClass.GetAll("View_Entity_BC_All_Info", "where Level2_ID=" + id.ToString() + " order by ListOrder asc;");
            Cache[cacheKey] = result;  // There are more params needed here...
            return result;
        }
        //return GeneralClass.GetAll("Entity_UseCase_BC", "where Level2_ID=" + id.ToString() + " order by ListOrder asc;");
    }

    protected DataSet LoadUseCase_BC_Level2(object Level1_ID)
    {
        return GeneralClass.GetAll("UseCase_BC_Level2", "where Level1_ID=" + Level1_ID.ToString() + " order by ListOrder asc;");
    }

    protected DataSet LoadLevel3EntityList(object id)
    {
        return GeneralClass.GetAll("View_Entity_BC_All_Info", "where Level3_ID=" + id.ToString() + ";");
    }


    //Work to show logo, event fired from level2 selectindex changed event
    protected void LoadLevel_3_Entities(string Level2_ID)
    {
        dlShowEntities.DataSource = GeneralClass.GetAll("UseCase_BC_Level3", " where Level2_ID=" + Level2_ID);
        dlShowEntities.DataBind();
    }

    protected void LoadLevel_3_Entities_No_Level3(string Level2_ID)
    {
        dlShowEntitiesNoLevel3.DataSource = GeneralClass.GetAll("View_Entity_BC_All_Info", " where Level2_ID=" + Level2_ID + " and Level3_ID=0;");
        dlShowEntitiesNoLevel3.DataBind();
    }


    protected DataSet LoadWebLinkList(object id)
    {
        return GeneralClass.GetAll("Entity_WebLink", "where EntityID=" + id.ToString() + " order by ID;");
    }






    //Read Field of Datalist

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

    protected string ReadUrlPath(object EntityID)
    {
        string strReturn = "~/Entities/Entity.aspx?EntityID=" + EntityID.ToString();

        //strReturn = GeneralClass.ReadOneFieldFromOneField("WebLink", "Entity_WebLink", "EntityID", EntityID.ToString(), "");

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

    protected string ReadEntityNameOnly(object EntityID)
    {
        string strReturn = GeneralClass.ReadOneFieldFromOneField("Name", "Entities", "ID", EntityID.ToString(), "");
        return strReturn;
    }

    protected string ReadEntityOneLinerOnly(object EntityID)
    {
        string strReturn;

        if (CultureInfo.CurrentUICulture.Name == "en-US"){
            strReturn = GeneralClass.ReadOneFieldFromOneField("OneLiner", "Entities", "ID", EntityID.ToString(), "");
        }
        else{
            strReturn = GeneralClass.ReadOneFieldFromOneField("OneLiner_CN", "Entities", "ID", EntityID.ToString(), "");
        }
        return strReturn;
    }

    protected string ReadWebLink(object TableID)
    {
        string strReturn = "";

        strReturn += "" + GeneralClass.ReadOneFieldFromOneID("WebLink", "Entity_WebLink", TableID.ToString());

        //Clean the http address so it will open in browser
        strReturn = GeneralClass.CleanHttpString(strReturn);

        return strReturn;
    }

    protected string ReadWebLinkType(object TableID)
    {
        string strReturn = "";
        string strID = GeneralClass.ReadOneFieldFromOneID("TagID", "Entity_WebLink", TableID.ToString());
        strReturn += "" + GeneralClass.ReadOneFieldFromOneID("Name", "Entity_WebLink_Tag", strID);

        return strReturn + ":";
    }

    protected string ReadLevelName(object Field_EN, object Field_CN)
    {
        string strReturn = Field_EN.ToString();

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {

        }
        else
        {
            if (!string.IsNullOrEmpty(Field_CN.ToString()))
            {
                strReturn = Field_CN.ToString();
            }
        }
        return "&nbsp;&nbsp;&nbsp;" + strReturn + "&nbsp;&nbsp;&nbsp;";
    }

    protected string ReadLegendWidth()
    {
        string strReturn;

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = "15em";
        }
        else
        {
            strReturn = "10em";
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
        if (!string.IsNullOrEmpty(strOneLiner)){
            strReturn = strReturn + " - " + strOneLiner;
        }
        return strReturn;
    }
}