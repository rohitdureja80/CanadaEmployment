﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Text.Json;
using System.Linq;

using CanadaEmployment.Data;
using CanadaEmployment.Model;


namespace CanadaEmployment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnemploymentController : ODataController
    {
        private readonly ILogger<UnemploymentController> _logger;
        private readonly IDataAccess _db;

        public UnemploymentController(ILogger<UnemploymentController> logger, IDataAccess db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            _logger.LogInformation("*********** Unemployment Controller Initiated **************");
            List<UnemploymentModel> data = _db.GetUnemploymentData();
            return Ok(data);
        }
    }
}
