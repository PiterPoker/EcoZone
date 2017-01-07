using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessProvider;
using Domain.Model;
using EcoZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EcoZone.Controllers
{
    [Authorize]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly DomainModelContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager, DomainModelContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet("")]
        public async Task<List<UsersViewModel>> Users(string searchString, int skip, int take)
        {
            List<ApplicationUser> dbUsers;
            if (string.IsNullOrEmpty(searchString))
            {
                dbUsers =
                    await
                        _context.Users.Where(u => u.IsApproved)
                            .OrderBy(u => u.FirstName)
                            .ThenBy(u => u.LastName)
                            .Skip(skip)
                            .Take(take)
                            .ToListAsync();
            }
            else
            {
                var searchStringToLower = searchString.ToLower();
                dbUsers = await
                    _context.Users.Where(
                        u =>
                            u.IsApproved &&
                            (u.FirstName.ToLower().Contains(searchStringToLower) ||
                             u.LastName.ToLower().Contains(searchStringToLower) ||
                             searchStringToLower.Contains(u.FirstName.ToLower()) ||
                             searchStringToLower.Contains(u.LastName.ToLower()))).Skip(skip).Take(take).ToListAsync();
            }
            var users = new List<UsersViewModel>();
            foreach (var user in dbUsers)
                users.Add(new UsersViewModel(user, await _userManager.GetRolesAsync(user)));
            return users;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getNotApproved")]
        public async Task<List<UsersViewModel>> GetNotApprovedUsers(string searchString, int skip, int take)
        {
            List<ApplicationUser> dbUsers;
            if (string.IsNullOrEmpty(searchString))
            {
                dbUsers =
                    await
                        _context.Users.Where(u => !u.IsApproved)
                            .OrderBy(u => u.FirstName)
                            .ThenBy(u => u.LastName)
                            .Skip(skip)
                            .Take(take)
                            .ToListAsync();
            }
            else
            {
                var searchStringToLower = searchString.ToLower();
                dbUsers = await
                    _context.Users.Where(
                            u =>
                                !u.IsApproved &&
                                (u.FirstName.ToLower().Contains(searchStringToLower) ||
                                 u.LastName.ToLower().Contains(searchStringToLower) ||
                                 searchStringToLower.Contains(u.FirstName.ToLower()) ||
                                 searchStringToLower.Contains(u.LastName.ToLower())))
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
            }
            var users = new List<UsersViewModel>();
            foreach (var user in dbUsers)
                users.Add(new UsersViewModel(user, await _userManager.GetRolesAsync(user)));
            return users;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("approveUser")]
        public async Task<string> ApproveUser([FromBody] string id)
        {
            if (string.IsNullOrEmpty(id))
                return "Invalid id";
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return "Not found";
            user.IsApproved = true;
            _context.ChangeTracker.DetectChanges();
            await _context.SaveChangesAsync();
            return "Approved";
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPost("�onfirm�hanges")]
        //public async Task<string> �onfirm�hanges([FromBody] string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //        return "Invalid id";
        //    var user = await _context.Users.Include(u => u.PendingUserData).FirstOrDefaultAsync(u => u.Id.Equals(id));
        //    if (user == null)
        //        return "Not found";
        //    var pendingData = user.PendingUserData.FirstOrDefault();
        //    if (pendingData != null)
        //    {
        //        user.UpdateUserData(pendingData);
        //        if (!string.IsNullOrEmpty(pendingData.Email))
        //        {
        //            var changeEmailToken = await _userManager.GenerateChangeEmailTokenAsync(user, pendingData.Email);
        //            var result = await _userManager.ChangeEmailAsync(user, pendingData.Email, changeEmailToken);
        //            if (!result.Succeeded)
        //                return "Error";
        //        }
        //        if (!string.IsNullOrEmpty(pendingData.Phone))
        //        {
        //            var changePhoneNumberToken = await _userManager.GenerateChangePhoneNumberTokenAsync(user,
        //                pendingData.Phone);
        //            var result = await _userManager.ChangePhoneNumberAsync(user, pendingData.Phone,
        //                changePhoneNumberToken);
        //            if (!result.Succeeded)
        //                return "Error";
        //        }
        //        _context.PendingUserData.RemoveRange(user.PendingUserData);
        //        user.IsPendingData = false;
        //        user.PendingUserData = null;
        //    }
        //    _context.ChangeTracker.DetectChanges();
        //    await _context.SaveChangesAsync();
        //    return "Confirmed";
        //}

        [Authorize(Roles = "Admin")]
        [HttpPost("blockUser")]
        public async Task<string> BlockUser([FromBody] string id)
        {
            if (string.IsNullOrEmpty(id))
                return "Invalid id";
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
            if (user == null)
                return "Not found";
            user.IsApproved = false;
            _context.ChangeTracker.DetectChanges();
            await _context.SaveChangesAsync();
            return "Blocked";
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("deleteUser")]
        public string DeleteUser([FromBody] string id)
        {
            if (string.IsNullOrEmpty(id))
                return "Invalid id";
            var user = _context.Users
                .FirstOrDefault(u => u.Id.Equals(id));
            if (user == null)
                return "Not found";
            try
            {
                _context.Users.Remove(user);
                _context.ChangeTracker.DetectChanges();
                _context.SaveChanges();
                return "Deleted";
            }
            catch (Exception)
            {
                return "Error";
            }
        }
    }
}