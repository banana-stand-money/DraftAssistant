using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DraftAssistant.Core;
using DraftAssistant.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DraftAssistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionImportController : ControllerBase {


        [HttpGet]
        public IEnumerable<HitterProjection> GetHitters()
        {
            return DepthChartsParser.ParseHitterCsv(@"C:\ProjectionData\DepthChartsProjectionsHitters.csv");

        }
       
    }
}