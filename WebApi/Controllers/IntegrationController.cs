using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain;
using WebApi.Domain.DTO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrationController : ControllerBase
    {
        private readonly IDbConnection _connection;
        private readonly IOptionsMonitor<ConnectionStrings> _connectionStrings;

        public IntegrationController(IOptionsMonitor<ConnectionStrings> options, IDbConnection connection)
        {
            _connectionStrings = options;
            _connection = connection;
        }

        [HttpGet("database/current-time")]
        public async Task<IActionResult> GetCurrentTimeDatabase()
        {
            try
            {
                // Get current time from database
                var response = await _connection.QueryAsync<dynamic>("SELECT CURRENT_TIMESTAMP FROM DUAL");

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet("database/connection-string")]
        public async Task<IActionResult> GetConnectionString()
        {
            try
            {
                return Ok(_connectionStrings.CurrentValue.VPNDatabase);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}