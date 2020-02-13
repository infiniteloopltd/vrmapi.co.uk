using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Net;

public partial class ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var username = ConfigurationSettings.AppSettings["REGCHECK_USERNAME"];
        var secretKey = ConfigurationSettings.AppSettings["SECRET_KEY"];
        var reg = Request.QueryString["reg"];
        var recaptcha = Request.QueryString["recaptcha"];
        var strUrl = "https://www.google.com/recaptcha/api/siteverify?";
        var postdata = "secret=" + secretKey;
        postdata += "&response=" + recaptcha;
        var wc = new WebClient();
        var verify = wc.DownloadString(strUrl + postdata);
        var jVerify = JObject.Parse(verify);
        if (jVerify["success"].ToString() != "True") return;
        var client = new regcheck.BespokeAPISoapClient();
        var car = client.CheckUKMinimal(reg, username);
        Response.ContentType = "application/json";
        Response.Write(car.vehicleJson);
    }
}