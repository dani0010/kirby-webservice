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
    public class swatchController : Controller
    {

        private readonly appDbContext _context;

        public swatchController(appDbContext context)
        {
            _context = context;
        }

        // GET api/swatches
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_context.swatches);
        }

        // GET api/swatches/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var swatches = _context.swatches
                .Include(swatch=>swatch.yarn)
                .Include(swatch=>swatch.needle)
                .Single(s=>s.swatchId==id);

            return Json(swatches);
        }

        [HttpPost]
        public IActionResult Create([FromBody] swatch oSwatchIn)
        {
            if (oSwatchIn == null)
            {
                return BadRequest();
            }
            _context.swatches.Add(oSwatchIn);
            return CreatedAtRoute("swatch", new { id = oSwatchIn.swatchId }, oSwatchIn);
        }


    }

}