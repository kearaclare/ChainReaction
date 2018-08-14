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
using System.Data;
using System.IO;
using System.Threading;
using System.Diagnostics;

public partial class Blockchains_Blockchains : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadBlockchainTypeList();
            rblBlockchainType.SelectedValue = "0";
            LoadBlockchainList(rblBlockchainType.SelectedValue);
            ViewState.Add("Language", CultureInfo.CurrentUICulture.Name);
        }
        else
        {

            if (CultureInfo.CurrentUICulture.Name != ViewState["Language"].ToString()){
                LoadBlockchainTypeList();
                LoadBlockchainList(rblBlockchainType.SelectedValue);
                ViewState["Language"] = CultureInfo.CurrentUICulture.Name;
            }
        }

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            lblTitle.Text = "Global Blockchain Listing";
        }
        else
        {
            lblTitle.Text = "全球区块链列表";
        }

        //if (GeneralClass.UserName() == "dh" || GeneralClass.UserName() == "editor" || GeneralClass.UserName() == "mubin")
        //{
        //    hlEdit.Visible = true;
        //}
    }


    protected void rblBlockchainType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadBlockchainList(rblBlockchainType.SelectedValue);
    }

    protected void LoadBlockchainList(string ChainType) {
        if (ChainType != "0")
        {
            Blockchains_GV.DataSource = GeneralClass.GetAll("Blockchains", " where id > 0 and ChainType=" + ChainType + " order by ListOrder desc;");
        }
        else {
            Blockchains_GV.DataSource = GeneralClass.GetAll("Blockchains", " where id > 0 order by ListOrder desc;");
        }
        Blockchains_GV.DataBind();
    }

    protected void LoadBlockchainTypeList()
    {
        string strName = "";
        string strAll = "";
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strName = "Name";
            strAll = "All";
        }
        else
        {
            strName = "Name_CN";
            strAll = "所有类型";
        }

        rblBlockchainType.DataSource = GeneralClass.GetAll("Blockchain_Type", " where id > 0 order by ListOrder desc;");
        rblBlockchainType.DataValueField = "id";
        rblBlockchainType.DataTextField = strName;
        rblBlockchainType.DataBind();
        rblBlockchainType.Items.Insert(0, new ListItem(strAll, "0"));
    }

    
    protected string ReadField(object Field_EN, object Field_CN)
    {
        string strReturn = Field_EN.ToString();

        //if (ViewState["Language"] != null)
        //{
        //    if (ViewState["Language"].ToString() == "CN")
        //    {
        //        strReturn = Field_CN.ToString();
        //    }
        //}

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
        return strReturn;
    }


    protected string ReadHash(object HashType)
    {
        return GeneralClass.ReadOneFieldFromOneID("Name", "Blockchain_HashType", HashType.ToString());
    }

    protected string ReadPosType(object ConsensusType, object PosType)
    {
        string strReturn;

        strReturn = GeneralClass.ReadOneFieldFromOneID("Name", "Blockchain_ConsensusType", ConsensusType.ToString());
        if (PosType.ToString() != "0")
        {
            strReturn += " - " + GeneralClass.ReadOneFieldFromOneID("Name", "Blockchain_PosType", PosType.ToString());
        }
        return strReturn;
    }


    protected string ReadPosTypeHeader(object id)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = "Consensus Type";
        }
        else
        {
            strReturn = "共识算法";
        }
        return strReturn;
    }

    protected string ReadHashTypeHeader(object id)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = "Hash";
        }
        else
        {
            strReturn = "哈希算法";
        }
        return strReturn;
    }

    protected string ReadProgramLangHeader(object id)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = "Programming Lang";
        }
        else
        {
            strReturn = "编程语言";
        }
        return strReturn;
    }

    protected string ReadTPSHeader(object id)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = "TPS";
        }
        else
        {
            strReturn = "交易次数/秒";
        }
        return strReturn;
    }

    protected string ReadBlockTime(object BlockTime)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = BlockTime.ToString();
        }
        else
        {
            strReturn = BlockTime.ToString().ToLower().Replace("seconds", "秒");
            strReturn = strReturn.ToLower().Replace("minutes", "分");
            strReturn = strReturn.Replace(" ", "");
        }
        return strReturn;
    }

    public static string ReadBlockInfo(object Genesis, object BlockSize, object BlockTime)
    {
        string strReturn = "";
        string strBlockTime;
        string strGenesis;
        string strBlockSize;

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strBlockTime = "Block Time";
            strGenesis = "Genesis";
            strBlockSize = "Block Size";
            if (!string.IsNullOrEmpty(BlockTime.ToString()))
            {
                strReturn = BlockTime.ToString();
                strReturn = "<small>" + strBlockTime + ":</small> " + strReturn;
            }
        }
        else
        {
            strBlockTime = "区块生成速度";
            strGenesis = "头区块生成时间";
            strBlockSize = "区块大小";
            if (!string.IsNullOrEmpty(BlockTime.ToString()))
            {
                strReturn = BlockTime.ToString().ToLower().Replace("seconds", "秒");
                strReturn = strReturn.ToLower().Replace("minutes", "分");
                strReturn = strReturn.Replace(" ", "");
                strReturn = "<small>" + strBlockTime + ":</small> " + strReturn;
            }
        }

        if (!string.IsNullOrEmpty(BlockSize.ToString()))
        {
            if (string.IsNullOrEmpty(strReturn))
            {
                strReturn = "<small>" + strBlockSize + ":</small> " + BlockSize.ToString();
            }
            else
            {
                strReturn += "<br/><small>" + strBlockSize + ":</small> " + BlockSize.ToString();
            }
        }


        if (!string.IsNullOrEmpty(Genesis.ToString()))
        {
            DateTime dt = DateTime.Parse(Genesis.ToString());
            if (dt.ToString("HH").Trim() == "00" & dt.ToString("mm").Trim() == "00" & dt.ToString("ss").Trim() == "00")
            {
                strReturn += "<br/><small>" + strGenesis + ": " + dt.ToString("yyyy-MM-dd") + "</small>";
            }
            else
            {
                strReturn += "<br/><small>" + strGenesis + ": " + dt.ToString("yyyy-MM-dd HH:mm:ss") + "</small>";
            }
        }
        return strReturn;
    }

    protected string ReadBlockTimeHeader(object id)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = "Block Info";
        }
        else
        {
            strReturn = "区块信息";
        }
        return strReturn;
    }
    

    protected string ReadWebsiteHeader(object id)
    {
        string strReturn = "";

        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            strReturn = "Website";
        }
        else
        {
            strReturn = "官方网站";
        }
        return strReturn;
    }


}