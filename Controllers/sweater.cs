using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kirby.models;

namespace kirby.controllers
{

    [Route("api/[controller]")]
    public class sweaterController : Controller
    {

        private readonly appDbContext _context;

        public sweaterController(appDbContext context)
        {
            _context = context;
        }

        // GET api/sweaters
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_context.sweaters);
        }

        // GET api/blogs/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var sweaters = _context.sweaters
                .Include(sweater=>sweater.formula)
                .Include(sweater=>sweater.size)
                .Include(sweater=>sweater.pattern)
                .Include(sweater=>sweater.swatch)
                .Single(s=>s.sweaterId==id);

            return Json(sweaters);
        }

        [HttpPost]
        public IActionResult Create([FromBody] sweater oSweaterIn)
        {
            if (oSweaterIn == null)
            {
                return BadRequest();
            }
            _context.sweaters.Add(oSweaterIn);
            return CreatedAtRoute("sweater", new { id = oSweaterIn.sweaterId }, oSweaterIn);
        }


    }

}