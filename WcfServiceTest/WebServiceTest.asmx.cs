using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WcfServiceTest.BDD.EF6;

namespace WcfServiceTest
{
    /// <summary>
    /// Summary description for WebServiceTest
    /// </summary>
    [WebService(Namespace = "http://amococadiz.somee.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceTest : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld(string toto)
        {
            return "Hello " + toto + "'s World";
        }

        [WebMethod]
        public string TestSimple(int id)
        {
            return BddAccessTest.TestSimple(id);
        }

        [WebMethod]
        public string TestComplet(int id, string data1, string data2, string data3)
        {
            return BddAccessTest.TestComplet(id, data1, data2, data3);
        }

        [WebMethod]
        public string TestEF6()
        {
            string result = "";
            using (var context = new DbEntities())
            {
                var objetsTest = context.ObjetsTest.ToList();
                foreach (var objetTest in objetsTest)
                {
                    result += objetTest.Id + " / " + objetTest.Data1 + " / " + objetTest.Data2 + " / " + objetTest.Data3 + " ||";
                }
            }
            return result;
        }
    }
}
