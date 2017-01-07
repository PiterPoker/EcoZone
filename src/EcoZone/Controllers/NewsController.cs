using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessProvider;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoZone.Controllers
{
    [Route("api/news")]
    public class NewsController : Controller
    {
        private readonly DomainModelContext _context;

        public NewsController(DomainModelContext context)
        {
            _context = context;
        }

        [Route("")]
        [HttpGet]
        public async Task<List<Unit>> Get()
        {
            return await _context.Units.ToListAsync();
        }
    }
}