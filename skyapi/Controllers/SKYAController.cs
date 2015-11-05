using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using skyamanager.Models;
using System.Xml;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace skyamanager.Controllers
{
     [EnableCors(origins: "http://skya.cfapps.io", headers: "*", methods: "*")]

    public class SKYAController : ApiController
    {
        //// GET api/skya
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/skya/5
        [HttpGet]
        public string Get(string value)
        {
            try
            {
                XmlDocument doc = JsonConvert.DeserializeXmlNode(value,"root");
                SKYAModel sm = new SKYAModel();
                return sm.AddSKYA(doc);
            }
            catch (Exception ex)
            {
                return "Fail";
            }
            return "Fail";
        }

        // POST api/skya
        [HttpPost]
        public string Post([FromBody]string value)
        {
            try
            {
                XmlDocument doc = JsonConvert.DeserializeXmlNode(value);
                SKYAModel sm = new SKYAModel();
                return sm.PushSKYA(doc);
            }
            catch (Exception ex)
            {
                return "Fail";
            }
            return "Fail";
        }

        // PUT api/skya/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/skya/5
        public void Delete(int id)
        {
        }
    }
}
