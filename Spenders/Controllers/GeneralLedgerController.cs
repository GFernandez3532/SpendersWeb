using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spenders.Data;
using Spenders.Models;

namespace Spenders.Controllers
{
    public class GeneralLedgerController : Controller
    {
        private readonly SpendersContext _spendersContext;
        private readonly IGeneralLedgerRepository _generalLedgerRepository;
        private readonly IGroupSpendersUserRepository _groupSpendersUserRepository ;
        private readonly ISpendersUserRepository _spendersUserRepository;
        private readonly IGroupRepository _groupRepository;

        public GeneralLedgerController(SpendersContext spendersContext, IGeneralLedgerRepository generalLedgerRepository,
        IGroupSpendersUserRepository groupSpendersUserRepository, ISpendersUserRepository spendersUserRepository, IGroupRepository groupRepository)
        {
            _spendersContext = spendersContext;
            _generalLedgerRepository = generalLedgerRepository;
            _groupSpendersUserRepository = groupSpendersUserRepository;
            _spendersUserRepository = spendersUserRepository;
            _groupRepository = groupRepository;
        }


        // GET: GeneralLedgerController
        public IActionResult Index(int groupId)
        {
            var group = _groupRepository.GetGroupByGroupId(groupId);

            return View(group);
        }

        // GET: GeneralLedgerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GeneralLedgerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneralLedgerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GeneralLedgerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GeneralLedgerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GeneralLedgerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GeneralLedgerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
