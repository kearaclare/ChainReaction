using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
////using ChainReaction;


public partial class Entities_Entity : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["EntityID"] != null) {
                ViewState.Add("EntityID", Request.QueryString["EntityID"]);


                //string strForwardUrl = GeneralClass.ReadOneFieldFromOneField("WebLink", "Entity_WebLink", "EntityID", Request.QueryString["EntityID"], "");
                //Response.Redirect(strForwardUrl);

                imgEntityLogo.ImageUrl = ReadLogoPath(ViewState["EntityID"].ToString());
                lblEntityName.Text = GeneralClass.ReadOneFieldFromOneID("Name", "Entities", ViewState["EntityID"].ToString());
                Page.Title = lblEntityName.Text;

                dlWebLinks.DataSource= GeneralClass.GetAll("Entity_WebLink", "where EntityID=" + ViewState["EntityID"].ToString() + " order by ID;");
                dlWebLinks.DataBind();

                lblOneLiner.Text = GeneralClass.ReadOneFieldFromOneID("OneLiner", "Entities", ViewState["EntityID"].ToString()); 

                
            }

        }
    }


    protected string ReadLogoPath(String EntityID)
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
}