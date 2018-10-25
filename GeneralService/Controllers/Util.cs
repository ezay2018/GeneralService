using GeneralService.Models.JSONModel;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace GeneralService.Controllers
{
    internal class Util
    {
        internal static RootObject Extract(string response)
        {
            JavaScriptSerializer oJS = new JavaScriptSerializer();
            RootObject oRootObject = new RootObject();
            oRootObject = oJS.Deserialize<RootObject>(response);

            return oRootObject;
        }
    }
}