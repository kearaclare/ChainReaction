using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Blockchain_BlockchainList : System.Web.UI.Page
{
    string ConnectionString = @"Data Source=DESKTOP-B519073\SQLEXPRESS;Initial Catalog=BootCamp;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        //string CurrentBlockchain = Request.QueryString["Name"];
        //LoadBlockchainName();
        //LoadConsensusType();
        //LoadHashType();
        //LoadProgrammingLang();
        //LoadTransactionsPerSec();
        //LoadBlockTime();

        //    if (!)
        //    {
        //        if (Request.QueryString["EntityID"] != null)
        //        {
        //            ViewState.Add("EntityID", Request.QueryString["EntityID"]);
        //        }

    }



    //protected void LoadBlockchainName()
    //{
    //    using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
    //    {
    //        string RequestedID= Request.QueryString["Name"];
    //        sqlCon.Open();
    //        SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Name from Blockchains where ID=4", sqlCon);
    //        DataTable dtbl = new DataTable();
    //        sqlDa.Fill(dtbl);
    //        gvBCName.DataSource = dtbl;
    //        sqlCon.Close();
    //        this.gvBCName.DataBind();
    //    }

    //}

    //protected void LoadConsensusType()
    //{
    //    using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
    //    {
    //        sqlCon.Open();
    //        SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT ConsensusType from Blockchains where ID=4", sqlCon);
    //        DataTable dtbl = new DataTable();
    //        sqlDa.Fill(dtbl);
    //        gvBC_CT.DataSource = dtbl;
    //        sqlCon.Close();
    //       this.gvBC_CT.DataBind();
    //    }
    //}

    //protected void LoadHashType()
    //{
    //    using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
    //    {
    //        sqlCon.Open();
    //        SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT HashType from Blockchains where ID=4", sqlCon);
    //        DataTable dtbl = new DataTable();
    //        sqlDa.Fill(dtbl);
    //        gvBC_HT.DataSource = dtbl;
    //        sqlCon.Close();
    //        this.gvBC_HT.DataBind();
    //    }
    //}

    //protected void LoadProgrammingLang()
    //{
    //    using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
    //    {
    //        sqlCon.Open();
    //        SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Prog_Lang from Blockchains where ID=4", sqlCon);
    //        DataTable dtbl = new DataTable();
    //        sqlDa.Fill(dtbl);
    //        gvBC_PL.DataSource = dtbl;
    //        sqlCon.Close();
    //        this.gvBC_PL.DataBind();
    //    }
    //}

    //protected void LoadTransactionsPerSec()
    //{
    //    using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
    //    {
    //        sqlCon.Open();
    //        SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Transactions_per_Second from Blockchains where ID=4", sqlCon);
    //        DataTable dtbl = new DataTable();
    //        sqlDa.Fill(dtbl);
    //        gvBC_TPS.DataSource = dtbl;
    //        sqlCon.Close();
    //        this.gvBC_TPS.DataBind();
    //    }

    //}

    //protected void LoadBlockTime()
    //{
    //    using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
    //    {
    //        sqlCon.Open();
    //        SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Block_Time from Blockchains where ID=4", sqlCon);
    //        DataTable dtbl = new DataTable();
    //        sqlDa.Fill(dtbl);
    //        gvBC_BT.DataSource = dtbl;
    //        sqlCon.Close();
    //        this.gvBC_BT.DataBind();
    //    }
    //}

    //protected void gvBCName_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if(e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        //Label BlockChainName = (Label)e.Row.FindControl("BCName");
    //        //BlockChainName.Text = Request.QueryString["Name"];



    //    }

    //}





}