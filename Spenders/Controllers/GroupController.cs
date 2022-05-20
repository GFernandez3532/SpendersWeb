using Microsoft.AspNetCore.Mvc;
using Spenders.Models;
using Spenders.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Controllers
{
    public class GroupController : Controller
    {

        private readonly IGroupRepository _groupRepository;


        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public IActionResult List()
        {
            var groupDetailsViewModel = new GroupDetailsViewModel();
            groupDetailsViewModel.Groups = _groupRepository.GetAllGroups;

            return View(groupDetailsViewModel);

        }

        public ViewResult GetGroupByGroupId(int groupId)
        {
            return View(_groupRepository.GetGroupByGroupId(groupId));
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
