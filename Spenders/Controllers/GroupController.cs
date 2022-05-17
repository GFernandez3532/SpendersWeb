using Microsoft.AspNetCore.Mvc;
using Spenders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Controllers
{
    public class GroupController : Controller
    {

        private readonly IGroupRepository _groupRepository;
        private readonly IGroupMemberRepository _groupMemberRepository;


        public GroupController(IGroupRepository groupRepository, IGroupMemberRepository groupMemberRepository)
        {
            _groupRepository = groupRepository;
            _groupMemberRepository = groupMemberRepository;
        }

        public ViewResult List()
        {
            return View(_groupRepository.GetAllGroups);
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
