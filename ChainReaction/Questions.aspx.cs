using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Questions : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            Ac1.DataSource = GetAll();
            Ac1.DataBind();
            ViewState.Add("Language", "EN");

            if (Request.QueryString["QuestionID"] != null)
            {
                ViewState.Add("QuestionID", Request.QueryString["QuestionID"]);
                DisplayAnswer(ViewState["QuestionID"].ToString());
                //Ac1.SelectedIndex = 2;
                foreach (GridViewRow gvRow in Ac1.Rows)
                {
                    if (Ac1.DataKeys[gvRow.DataItemIndex].Value.ToString() == ViewState["QuestionID"].ToString())
                    {
                        Ac1.SelectedIndex = gvRow.DataItemIndex;
                        break;
                    }
                }
            }

            //if (GeneralClass.UserName() == "dh" || GeneralClass.UserName() == "editor"
            //    || GeneralClass.UserName() == "jo" || GeneralClass.UserName() == "milo")
            //{
            //    hlQuestionsEdit.Visible = true;
            //}

        }
    }

    protected static DataSet GetAll()
    {
        string strConString;
        SqlConnection conJobs;
        SqlDataAdapter dadItems;
        DataSet dstItems;
        string SelectCmd;
        SelectCmd = "select * from Question order by ListOrder DESC;";
        strConString = ConfigurationManager.ConnectionStrings["BootCamp"].ConnectionString;
        conJobs = new SqlConnection(strConString);
        dstItems = new DataSet();
        dadItems = new SqlDataAdapter(SelectCmd, conJobs);
        dadItems.Fill(dstItems, "NewItems");
        return dstItems;
    }

    protected void rbl_BC_Language_SelectedIndexChanged(object sender, EventArgs e)
    {
        Answer.Text = "";
        Ac1.SelectedIndex = -1;
        phAnswer.Visible = false;

        Ac1.DataSource = GetAll();
        Ac1.DataBind();

      
            
        
    }

    protected string ReadQuestion(object Question, object Question_CN)
    {
        string strReturn = Question.ToString();


        if (ViewState["Language"] != null)
        {
            if (ViewState["Language"].ToString() == "CN")
            {
                strReturn = Question_CN.ToString();
            }
        }

        return strReturn;
    }

    protected string ReadAnswer(object Answer, object Answer_CN)
    {
        string strReturn = Answer.ToString();


        if (ViewState["Language"] != null)
        {
            if (ViewState["Language"].ToString() == "CN")
            {
                strReturn = Answer_CN.ToString();
            }
        }

        return strReturn;
    }

    protected void Questions_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        DisplayAnswer(Ac1.DataKeys[e.NewSelectedIndex].Value.ToString());
    }

    protected void DisplayAnswer(string QuestionID) {
        Answer.Text = "";
        lblReadMore.Visible = true;
        

        if (rbl_BC_Language.SelectedValue == "EN")
        {
            //Answer.Text = ReadField("Answer", QuestionID);
            FAQheader.Text = ReadField("Question", QuestionID);
            Answer.Text = "<br>" + ReadField("Answer", QuestionID);

        }
        else
        {
            Answer.Text = ReadField("Answer_CN", QuestionID);
        }

        phAnswer.Visible = true;
        gvWebLink.DataSource = GetAllWebLink(QuestionID);
        gvWebLink.DataBind();


        /*starts here*/
        string CheckWL = SeeIfReadMore(QuestionID);     //Returns the Website URL for the extra link if there is one, returns null if there isn't one

        if (String.IsNullOrEmpty(CheckWL))              //If there is no website URL, don't display "Read More" 
        {
            lblReadMore.Text = " ";                                     
        }
        else                                            //If there is, check which language and then display "Read More" 
        {
            if (rbl_BC_Language.SelectedValue == "EN")
            {
                ViewState["Language"] = "EN";
                lblReadMore.Text = "Read More";
            }
            else
            {
                ViewState["Language"] = "CN";
                lblReadMore.Text = "了解更多";
            }

        }
        /*and ends here*/

        
    }



    protected string ReadField(string field, string strID)
    {
        SqlConnection con1;
        SqlCommand cmdSelect;
        SqlDataReader dtrDataReader;
        string strReturn = "";
        string strSQL = "select " + field + " from Question where ID=@id";

        con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BootCamp"].ConnectionString);
        con1.Open();
        cmdSelect = new SqlCommand(strSQL, con1);
        cmdSelect.Parameters.AddWithValue("@id", strID);
        dtrDataReader = cmdSelect.ExecuteReader();

        if (dtrDataReader.Read())
        {
            strReturn = dtrDataReader[field].ToString();
        }
        dtrDataReader.Close();
        con1.Close();

        return strReturn;
    }

    protected static DataSet GetAllWebLink(String QuestionID)
    {
        string strConString;
        SqlConnection conJobs;
        SqlDataAdapter dadItems;
        DataSet dstItems;
        string SelectCmd;
        SelectCmd = "select * from QuestionLink where QuestionID=" + QuestionID;
        strConString = ConfigurationManager.ConnectionStrings["BootCamp"].ConnectionString;
        conJobs = new SqlConnection(strConString);

        dstItems = new DataSet();
        dadItems = new SqlDataAdapter(SelectCmd, conJobs);
        dadItems.Fill(dstItems, "NewItems");


        return dstItems;
    }

    /*This function connects to the BootCamp database 
      and reads the WebLinks that accompany the answers (if there are any) 
      and returns the URL as a string if there is a WebLink, and as null otherwise*/
    string WebsiteName;
    protected string SeeIfReadMore(string QuestionID)
    {
        string ConString;
        ConString = ConfigurationManager.ConnectionStrings["BootCamp"].ConnectionString;

        string SelectCmd2;
        SelectCmd2 = "select WebLink from QuestionLink where QuestionID=" + QuestionID;

        SqlConnection CheckWebLinks = new SqlConnection(ConString);
        SqlCommand commanding = new SqlCommand(SelectCmd2, CheckWebLinks);

        CheckWebLinks.Open();

        using (SqlDataReader reader = commanding.ExecuteReader())
        {
            while (reader.Read())
            {
                WebsiteName = reader.GetString(0);
            }
        }
        CheckWebLinks.Close();
        return WebsiteName;
        
    }

    protected DataSet LoadWebLinkList(object id)
    {
        return GetAllWebLink(id.ToString());
    }


    protected string ReadWebLink(object TableID, object WebLink)
    {
        string strReturn = WebLink.ToString();


        return strReturn;
    }





    protected void Ac1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}