using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessProvider;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoZone.Controllers
{
    [Route("api/tag")]
    public class TagController : Controller
    {
        private readonly DomainModelContext _context;

        public TagController(DomainModelContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        [AllowAnonymous]
        public async Task<List<Tag>> Tags()
        {
            return await _context.Tags.OrderBy(d => d.Name).ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<object> Tag(int? id)
        {
            if (id == null)
                return "Invalid id";
            var tag = await _context.Tags.FirstOrDefaultAsync(d => d.Id == id);
            if (tag == null)
                return "Not found";
            return tag;
        }

    }
}