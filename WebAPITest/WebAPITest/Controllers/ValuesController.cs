﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // getting service through attribute [FromServices]
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get([FromServices] SimpleService service)
        {
            return new string[] { "value1", "value2" };
        }

        // getting service from HttpContext
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var smpleService = HttpContext.RequestServices.GetService(typeof(SimpleService));
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
