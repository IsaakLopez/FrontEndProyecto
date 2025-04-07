using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DevExtremeMvcAppprueba2.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;

namespace DevExtremeMvcAppprueba2.Controllers {
    public class SampleDataController : ApiController {

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions) {
            return Request.CreateResponse(DataSourceLoader.Load(SampleData.Orders, loadOptions));
        }

    }
}