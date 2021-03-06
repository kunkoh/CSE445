﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie myCookies = Request.Cookies["myKeyie"];
        if(myCookies!=null)
            Session["Username"] = myCookies["Username"];
        if ((string)Session["Username"] == "HaoYan" || (string)Session["Username"] == "ShihuanShao" || (string)Session["Username"] == "JieGuo" || (string)Session["Username"] == "YunlongJiang")
        { }
        else
            Response.Redirect("/GUI/LoginSenior.aspx");
        id.Text = (string)Session["Username"];
    }
    protected void TestRequiredService1(object sender, EventArgs e)
    {
        Top10WordsService.ServiceClient client = new Top10WordsService.ServiceClient();
        if (rs1str.Text == "http://")
        {
            rs1result.Text = "Empty input is not allowed!";
            return;
        }
        try
        {
            string[] result = client.Top10Words(rs1str.Text);
            string output = "";
            for (int i = 0; i < result.Length; i++)
            {
                output = output + (i + 1).ToString() + ": " + result[i] + " ";
            }
            rs1result.Text = output;
        }
        catch (Exception ec)
        {
            rs1result.Text = ec.Message.ToString();
        }
    }
    protected void TestRequiredService2(object sender, EventArgs e)
    {
        WordFilterService.ServiceClient client = new WordFilterService.ServiceClient();
        if (rs2str.Text == "")
        {
            rs2result.Text = "Empty input is not allowed!";
            return;
        }
        try
        {
            string result = client.WordFilter(rs2str.Text);
            rs2result.Text = result;
        }
        catch (Exception ec)
        {
            rs2result.Text = ec.Message.ToString();
        }
    }
    protected void TestElectiveService1(object sender, EventArgs e)
    {
        AllCombinationService.ServiceClient client = new AllCombinationService.ServiceClient();
        if (es1str.Text == "")
        {
            es1result.Text = "Empty input is not allowed!";
            return;
        }
        try
        {
            string[] result = client.AllCombination(es1str.Text);
            string output = "";
            for (int i = 0; i < result.Length; i++)
            {
                output = output + (i + 1).ToString() + ": " + result[i] + "\n";
            }
            es1result.Text = output;
        }
        catch (Exception ec)
        {
            es1result.Text = ec.Message.ToString();
        }
    }
    protected void TestElectiveService2(object sender, EventArgs e)
    {
        PalindromeService.ServiceClient client = new PalindromeService.ServiceClient();
        if (es2str.Text == "")
        {
            es2result.Text = "Empty input is not allowed!";
            return;
        }
        try
        {
            int result = client.Palindrome(es2str.Text);
            es2result.Text = result.ToString();
        }
        catch (Exception ec)
        {
            es2result.Text = ec.Message.ToString();
        }
    }
    protected void TestElectiveService3(object sender, EventArgs e)
    {
        DeleteCharService.ServiceClient client = new DeleteCharService.ServiceClient();
        if (es3str1.Text == "" || es3str2.Text == "")
        {
            es3result.Text = "Empty input is not allowed!";
            return;
        }
        try
        {
            string result = client.DeleteChar(es3str1.Text, es3str2.Text);
            es3result.Text = result;
        }
        catch (Exception ec)
        {
            es3result.Text = ec.Message.ToString();
        }
    }
    protected void TestElectiveService4(object sender, EventArgs e)
    {
        MergeSortingService.ServiceClient client = new MergeSortingService.ServiceClient();
        if (es4str.Text == "")
        {
            es4result.Text = "Empty input is not allowed!";
            return;
        }
        try
        {
            string result = client.MergeSorting(es4str.Text);
            es4result.Text = result;
        }
        catch (Exception ec)
        {
            es4result.Text = ec.Message.ToString();
        }
    }
    protected void Button7_Click1(object sender, EventArgs e)
    {
        HttpCookie myCookies = Request.Cookies["myKeyie"];
        if (myCookies != null)
        {
            myCookies.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookies);
        }
    }
    protected void logoutBtn_Click(object sender, EventArgs e)
    {
        Session.Clear();
        HttpCookie myCookies = Request.Cookies["myKeyie"];
        if (myCookies != null)
        {
            myCookies.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookies);
        }
        FormsAuthentication.SignOut();
        Response.Redirect("/GUI/default.aspx");
    }
    protected void returnBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("/GUI/default.aspx");
    }
}
