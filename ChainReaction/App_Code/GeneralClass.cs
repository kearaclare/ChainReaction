using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;

/// <summary>
/// Summary description for GeneralClass
/// </summary>
public class GeneralClass
{
    public GeneralClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string LocalhostLogoPath(string strLogoPath)
    {
        string strReturn = strLogoPath;
        //Block out when upload to server
        strReturn = strReturn.Replace("~", "http://150.109.56.96:8080");

        return strReturn;
    }


    public static DataSet GetAll(string strTable, string strTail)
    {

        DataSet dstItems;

        SR_FTH_CORE.FTH_COREClient client = new SR_FTH_CORE.FTH_COREClient();

        dstItems = client.GetAll(strTable, strTail);

        client.Close();

        return dstItems;
    }


    public static DataSet GetAllFromQuery(string strSQL)
    {

        DataSet dstItems;

        SR_FTH_CORE.FTH_COREClient client = new SR_FTH_CORE.FTH_COREClient();

        dstItems = client.GetAllFromQuery(strSQL);

        client.Close();

        return dstItems;
    }

    public static string ReadOneFieldFromOneID(string strFieldName, string strTable, string strID)
    {

        string strReturn;

        SR_FTH_CORE.FTH_COREClient client = new SR_FTH_CORE.FTH_COREClient();

        strReturn = client.ReadOneFieldFromOneID(strFieldName, strTable, strID);

        client.Close();

        return strReturn;
    }

    public static string ReadOneFieldFromOneField(string strFieldName, string strTable, string strIdFieldName, string strID, string strTail)
    {

        string strReturn;

        SR_FTH_CORE.FTH_COREClient client = new SR_FTH_CORE.FTH_COREClient();

        strReturn = client.ReadOneFieldFromOneField(strFieldName, strTable, strIdFieldName, strID, strTail);

        client.Close();

        return strReturn;
    }


    public static string CleanHttpString(string strHttpString)
    {
        string strReturn = strHttpString;

        strReturn = strReturn.Replace("https", "");
        strReturn = strReturn.Replace("http", "");
        strReturn = strReturn.Replace(":", "");
        strReturn = strReturn.Replace("//", "");

        strReturn = strReturn + "#*#";
        strReturn = strReturn.Replace("/#*#", "");
        strReturn = strReturn.Replace("#*#", "");

        return strReturn;
    }

    public static string Truncate(string value, int maxLength)
    {
        if (!string.IsNullOrEmpty(value) && value.Length > maxLength)
        {
            return value.Substring(0, maxLength) + "...";
        }

        return value;
    }
    public static string ReadOneFieldFromQuery(string strFieldName, string strQuery)
    {

        string strReturn;

        SR_FTH_CORE.FTH_COREClient client = new SR_FTH_CORE.FTH_COREClient();

        strReturn = client.ReadOneFieldFromQuery(strFieldName, strQuery);

        client.Close();

        return strReturn;
    }
}