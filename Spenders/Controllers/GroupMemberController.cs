using Microsoft.AspNetCore.Mvc;
using Spenders.Models;
using Spenders.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Controllers
{
    public class GroupMemberController : Controller
    {
        private readonly IGroupRepository _groupRepository;
        private readonly ISpendersUserRepository _spendersUserRepository;
        private readonly IGroupMemberRepository _groupMemberRepository;

        public GroupMemberController(IGroupRepository groupRepository, IGroupMemberRepository groupMemberRepository, ISpendersUserRepository spendersUserRepository)
        {
            _groupMemberRepository = groupMemberRepository;
            _groupRepository = groupRepository;
            _spendersUserRepository = spendersUserRepository;

        }

        public IActionResult List()
        {
            var GroupDetailsViewModel = new GroupDetailsViewModel();
            GroupDetailsViewModel.Groups = _groupRepository.GetAllGroups;
            GroupDetailsViewModel.Users = _spendersUserRepository.GetAllUsers;
            GroupDetailsViewModel.groupMembers = _groupMemberRepository.GetAllGroupMembers;

            return View(GroupDetailsViewModel);

        }
        public ViewResult ListByUserId(int userId)
        {

            return View(_groupMemberRepository.GetAllGroupsByUserID(userId));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
