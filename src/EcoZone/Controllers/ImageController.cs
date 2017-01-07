using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataAccessProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoZone.Controllers
{
    [Authorize]
    [Route("api/image")]
    public class ImageController : Controller
    {
        private readonly DomainModelContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ImageController(DomainModelContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("uploadProfileImage")]
        public async Task<string> UploadProfileImage(IFormFile file)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName.Equals(User.Identity.Name));
            var path = _hostingEnvironment.WebRootPath + Path.DirectorySeparatorChar + "data" +
                       Path.DirectorySeparatorChar + "profile_photos";
            if ((user == null) || (file.Length <= 0)) return "������";
            try
            {
                RemoveExsitingImages(user.Id, path);
                var fileExtention = file.ContentType.Substring(file.ContentType.LastIndexOf('/') + 1);
                if (!fileExtention.Equals("jpeg") && !fileExtention.Equals("jpg") && !fileExtention.Equals("png"))
                    return "������������ ������ �����";
                var filename = user.Id + '.' + fileExtention;
                using (var fileStream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                user.PhotoType = filename;
                _context.ChangeTracker.DetectChanges();
                await _context.SaveChangesAsync();
                return "���������";
            }
            catch (Exception)
            {
                return "������";
            }
        }

        private void RemoveExsitingImages(string name, string path)
        {
            var exsistingFiles = Directory.GetFiles(path, name + ".*");
            foreach (var exsistingFile in exsistingFiles)
                System.IO.File.Delete(exsistingFile);
        }
    }
}