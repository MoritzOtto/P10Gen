using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P10Gen.Core.Model;
using P10Gen.Core.Services;
using P10Gen.Core.UtilAdapter;

namespace WebApplication1.Controllers
{
    public class PhaseController : Controller
    {
        // GET api/phase
        public IEnumerable<string> Get()
        {
            IEnumerable<Phase> tenPhases = new CreateTenPhases(new CreatePhaseService(new RandomAdapter(),
                        new CreateCombinationService(new RandomAdapter()))).Execute(75m);
            return tenPhases.Select(x => x.ToString());
        }
    }
}