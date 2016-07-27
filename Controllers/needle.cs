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
    public class needleController : Controller
    {

        private readonly appDbContext _context;

        public needleController(appDbContext context)
        {
            _context = context;
        }

        // GET api/needles
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_context.needles);
        }

        // GET api/blogs/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var needles = _context.needles
                .Single(s=>s.needleId==id);

            return Json(needles);
        }

        [HttpPost]
        public IActionResult Create([FromBody] needle oNeedleIn)
        {
            if (oNeedleIn == null)
            {
                return BadRequest();
            }
            _context.needles.Add(oNeedleIn);
            return CreatedAtRoute("needle", new { id = oNeedleIn.needleId }, oNeedleIn);
        }


    }

}