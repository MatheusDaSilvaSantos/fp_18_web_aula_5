using fp_web_aula_1_core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fp_18_web_aula_1_api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    //[EnableCors("Default")]
    [Authorize]
    public class TimesController : Controller
    {
        private CopaContext _context;

        public TimesController(CopaContext context)
        {
            _context = context;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Time>))]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            return Ok(_context.Times.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200, Type = typeof(Time))]
        public IActionResult Get(int id)
        {
            //var time = _context.Times.Single(a => a.Id == id);
            //var time = _context.Times.First(a => a.Id == id);
            var time = _context.Times.FirstOrDefault(a => a.Id == id);
            if (time == null)
                return NotFound();

            return Ok(time);

        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Time))]
        public IActionResult Post([FromBody] Time time)
        {
            if (ModelState.IsValid)
            {
                _context.Times.Add(time);
                _context.SaveChanges();

                return Created($"api/times/{time.Id}", time);
                //return Created($"api/times/{time.Id}", time);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Time time)
        {
            if (ModelState.IsValid)
            {
                time.Id = id;
                _context.Times.Attach(time).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _context.SaveChanges();

                return Ok(time);
                //return Created($"api/times/{time.Id}", time);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var time = _context.Times.FirstOrDefault(a => a.Id == id);
            if (time == null)
                return NotFound();

            _context.Times.Remove(time);
            _context.SaveChanges();

            return NoContent();
        }




    }
}
