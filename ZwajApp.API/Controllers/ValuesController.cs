using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZwajApp.API.Controllers;
using ZwajApp.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ZwajApp.API.Data;
using ZwajApp.API;
using ZwajApp.API.Migrations;



namespace ZwajApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

            public ValuesController(DataContext context)
            {
            _context = context;
                
            }

        // Get http://localhost:5000/api/values
        // GET api/values
        [HttpGet]
        public  async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
          var value = await _context.Values.FirstOrDefaultAsync(x=>x.id==id);
          return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
