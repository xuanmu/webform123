using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm123.AjaxApi
{
    /// <summary>
    /// DemoData 的摘要说明
    /// </summary>
    public class DemoData : IHttpHandler
    {

        class demodata
        {
            //public string iso1 = "";
            //public string name = "";
            //public string name2 = "";
            //public string iso2 = "";
            //public string numcode = "";
            public string id;
            public string[] cell;
        }

        class responsejson
        {
            public int page = 1;
            public int total = 200;
            public List<demodata> rows = new List<demodata>();
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/Json";

            if (context.Request.QueryString["action"] != null && context.Request.QueryString["action"] == "demo1")
            {
                //从1开始
                int pageindex = Convert.ToInt32(context.Request.Params["page"]);
                int pagersize = Convert.ToInt32(context.Request.Params["rp"]);
                System.Web.Script.Serialization.JavaScriptSerializer jsser = new System.Web.Script.Serialization.JavaScriptSerializer();

                responsejson returnjson = new responsejson();
                for (int i = 1; i <= 99951; i++)
                {
                    if (i > (pageindex - 1) * pagersize && i <= pageindex * pagersize)
                    {
                        demodata d = new demodata()
                        {
                            //iso1=(100000+i).ToString(),
                            //name = "name" + i.ToString(),
                            //name2 = "name2" + i.ToString(),
                            //iso2 = "iso2" + i.ToString(),
                            //numcode = "numcode" + i.ToString()
                            id = (100000 + i).ToString(),
                            cell = new String[] { (100000 + i).ToString(), "name" + i.ToString(), "name2" + i.ToString(), "iso2" + i.ToString(), "numcode" + i.ToString() },
                        };
                        returnjson.rows.Add(d);
                    }
                }
                returnjson.total = 99951;
                returnjson.page = pageindex;
                string s = jsser.Serialize(returnjson);
                context.Response.Write(s);
                context.Response.End();
            }
            else
            { 
                
            }

            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}