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
    public class yarnController : Controller
    {

        private readonly appDbContext _context;

        public yarnController(appDbContext context)
        {
            _context = context;
        }

        // GET api/yarns
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_context.yarns);
        }

        // GET api/blogs/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var yarns = _context.yarns
                .Single(s=>s.yarnId==id);

            return Json(yarns);
        }

        [HttpPost]
        public IActionResult Create([FromBody] yarn oYarnIn)
        {
            if (oYarnIn == null)
            {
                return BadRequest();
            }
            _context.yarns.Add(oYarnIn);
            _context.SaveChanges();
            
            return Created($"/api/yarn/{oYarnIn.yarnId}",oYarnIn);
//            return _context.CreatedAtRoute("yarn", new { id = oYarnIn.yarnId }, oYarnIn);
        }


    }

}