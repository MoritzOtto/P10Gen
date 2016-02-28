using P10Gen.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using P10Gen.Core.Model;
using P10Gen.Core.UtilAdapter;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Phase> Get()
        {
            IEnumerable<Phase> tenPhases = new CreateTenPhases(new CreatePhaseService(new RandomAdapter(),
                        new CreateCombinationService(new RandomAdapter()))).Execute(75m);
            return tenPhases;
        }
    }
}
