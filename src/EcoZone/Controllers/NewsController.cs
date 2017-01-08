using System.Collections.Generic;
using DataAccessProvider;
using Microsoft.AspNetCore.Mvc;

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
        public List<object> Get()
        {
            var list = new List<object>();
            list.Add(new
            {
                Title = "News 1",
                Description = "Description"
            });
            list.Add(new
            {
                Title = "News 2",
                Description = "Description"
            });
            list.Add(new
            {
                Title = "News 3",
                Description = "Description"
            });
            return list;
        }
    }
}