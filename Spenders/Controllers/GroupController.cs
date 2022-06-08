using Microsoft.AspNetCore.Mvc;
using Spenders.Models;
using Spenders.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Spenders.Areas.Identity.Data;
using Spenders.Data;

namespace Spenders.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {

        private readonly IGroupRepository _groupRepository;
        private readonly IGroupSpendersUserRepository _groupSpendersUserRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly SpendersContext _spendersContext;
        private readonly UserManager<SpendersUser> _userManager;


        public GroupController(IGroupRepository groupRepository, UserManager<SpendersUser> userManager, SpendersContext spendersContext,
            IGroupSpendersUserRepository groupSpendersUserRepository, IExpenseRepository expenseRepository)
        {
            _groupRepository = groupRepository;
            _userManager = userManager;
            _spendersContext = spendersContext;
            _groupSpendersUserRepository = groupSpendersUserRepository;
            _expenseRepository = expenseRepository;
        }

        public IActionResult List()
        {
            var groupDetailsViewModel = new GroupDetailsViewModel();
            groupDetailsViewModel.Groups = _groupRepository.GetAllGroups;

            return View(groupDetailsViewModel);

        }

        public IActionResult Index()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var groupDetailsViewModel = new GroupDetailsViewModel();

            groupDetailsViewModel.Groups = _groupRepository.GetGroupsByUserId(currentUserId);

            return View(groupDetailsViewModel);
        }

        [HttpPost]
        public IActionResult CreateGroup(string groupName, string groupDescription)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var group = new Group
            {
                Name = groupName,
                Description = groupDescription
            };

            if (ModelState.IsValid)
            {
                _groupRepository.CreateGroup(group);
            };

            GroupSpendersUser newGroupSpendersUser = new GroupSpendersUser();

            newGroupSpendersUser.GroupId = _groupRepository.GetGroupByName(group.Name).GroupId;

            newGroupSpendersUser.SpendersUserId = currentUserId;

            _groupSpendersUserRepository.CreateGroupSpendersUser(newGroupSpendersUser);
            
            _spendersContext.SaveChanges();

            return RedirectToAction("Details", new { newGroupSpendersUser.GroupId });
        }

        public IActionResult Details(int groupId)
        {

         GroupAndExpensesDetailViewModel groupAndExpensesDetailViewModel =   new GroupAndExpensesDetailViewModel
            {
                Group = _groupRepository.GetGroupByGroupId(groupId),
                Expenses = _expenseRepository.GetAllExpensesByGroupId(groupId)
            };

            if (groupAndExpensesDetailViewModel.Group == null)
            {
                return NotFound();
            }

            return View(groupAndExpensesDetailViewModel);
        }

        public IActionResult RemoveUserFromGroup(int userId, int groupId)
        {
            var groupSpenderUserToDelete = _groupSpendersUserRepository.GetGroupSpendersUserById(userId);

            if (groupSpenderUserToDelete != null)
            {
                var generalLedgerEntriesToDelete = _spendersContext.GeneralLedgers.Where(gl =>
                    gl.GroupSpendersUserId == groupSpenderUserToDelete.GroupSpendersUserID);

                _spendersContext.GeneralLedgers.RemoveRange(generalLedgerEntriesToDelete);

                _spendersContext.GroupSpendersUser.Remove(groupSpenderUserToDelete);
            }

            _spendersContext.SaveChanges();

            return RedirectToAction("Details",new { groupId });
        }

        [HttpPost]
        public IActionResult AddUserToGroup(int groupId, string userEmail)
        {
            string errMessage;

            var newUserToGroup = _spendersContext.SpendersUser.FirstOrDefault(u => u.Email == userEmail);

            if (newUserToGroup != null)
            {
                //check that user has not already been included in this group
                var groupSpendersUserRecord = _spendersContext.GroupSpendersUser.FirstOrDefault(gsu =>
                    gsu.SpendersUserId == newUserToGroup.Id && gsu.GroupId == groupId);

                if (groupSpendersUserRecord == null)
                {
                    var newGroupSpendersUser = new GroupSpendersUser
                    {
                        SpendersUserId = newUserToGroup.Id,
                        GroupId = groupId
                    };

                    _spendersContext.GroupSpendersUser.Add(newGroupSpendersUser);
                    TempData["SuccessMessage"] = newUserToGroup.FirstName +" Added Successfully";
                    _spendersContext.SaveChanges();
                }
                else
                {
                    errMessage = "User is already part of this group";
                    TempData["ErrorMessage"] = errMessage;

                    return RedirectToAction("Details", new { groupId });
                }
            }
            else
            {
                errMessage = "User not Found";

                TempData["ErrorMessage"] = errMessage;

                return RedirectToAction("Details", new { groupId });
            }

            return RedirectToAction("Details" ,new {groupId});

        }

        public IActionResult Delete(int groupId)
        {
            var groupToDelete = _spendersContext.Group.FirstOrDefault(g => g.GroupId == groupId);

            if (groupToDelete != null)
            {
                _spendersContext.Group.Remove(groupToDelete);

                IEnumerable<GroupSpendersUser> groupSpendersUsersToDelete =
                    _groupSpendersUserRepository.GetGroupSpendersUserByGroupId(groupId);



                foreach (var groupSpendersUser in groupSpendersUsersToDelete)
                {
                    IEnumerable<GeneralLedger> generalLedgersToDelete =
                        _spendersContext.GeneralLedgers.Where(gl =>
                            gl.GroupSpendersUserId == groupSpendersUser.GroupSpendersUserID);

                        _spendersContext.RemoveRange(generalLedgersToDelete);

                        _spendersContext.GroupSpendersUser.Remove(groupSpendersUser);
                }

                IEnumerable<Expense> expensesToDelete = _spendersContext.Expenses.Where(e => e.GroupId == groupId);

                _spendersContext.Expenses.RemoveRange(expensesToDelete);

                _spendersContext.SaveChanges();

            }

            return RedirectToAction("Index");
        }
    }
}
