using Microsoft.AspNetCore.Http;
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
        public IQueryable<UnemploymentModel> Get()
        {
            List<UnemploymentModel> data = _db.GetUnemploymentData();
            DataMessage<UnemploymentModel> dataMessage = new DataMessage<UnemploymentModel>();
            dataMessage.data = data;
            Meta meta = new Meta();
            meta.totalRecords = data.Count();
            dataMessage.meta = meta;
            IQueryable<UnemploymentModel> query = data.AsQueryable();
            return query;
            //return Ok(dataMessage);
        }

        [HttpGet("{location}")]
        [EnableQuery]
        public IQueryable<UnemploymentModel> GetUnemploymentDataByLocation(string location)
        {
            List<UnemploymentModel> data = _db.GetUnemploymentData(location);
            DataMessage<UnemploymentModel> dataMessage = new DataMessage<UnemploymentModel>();
            dataMessage.data = data;
            Meta meta = new Meta();
            meta.totalRecords = data.Count();
            dataMessage.meta = meta;
            IQueryable<UnemploymentModel> query = data.AsQueryable();
            return query;
            //return Ok(dataMessage);
        }

    }
}
