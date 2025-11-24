using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Moq;
using Spenders.Areas.Identity.Data;
using Spenders.Controllers;
using Spenders.Data;
using Spenders.Models;
using Xunit;

namespace Spenders.Tests
{
    public class GroupControllerTests
    {
        [Fact]
        public void CreateGroup_WithEmptyName_SetsErrorAndRedirects()
        {
            using var context = CreateContext();
            var controller = CreateController(context, "user-1");

            var result = controller.CreateGroup("   ", "desc");

            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Equal("Group name is required.", controller.TempData["ErrorMessage"]);
            Assert.Empty(context.Group);
        }

        [Fact]
        public void CreateGroup_WithDuplicateName_DoesNotCreateGroup()
        {
            using var context = CreateContext();
            context.Group.Add(new Group { GroupId = 1, Name = "Existing" });
            context.SaveChanges();
            var controller = CreateController(context, "user-1");

            var result = controller.CreateGroup("Existing", "desc");

            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Equal("A group with this name already exists.", controller.TempData["ErrorMessage"]);
            Assert.Equal(1, context.Group.Count());
        }

        [Fact]
        public void AddUserToGroup_AsNonMember_ReturnsForbid()
        {
            using var context = CreateContext();
            context.Group.Add(new Group { GroupId = 1, Name = "Test" });
            context.SpendersUser.Add(new SpendersUser { Id = "invitee", Email = "invitee@example.com" });
            context.SaveChanges();
            var controller = CreateController(context, "user-not-in-group");

            var result = controller.AddUserToGroup(1, "invitee@example.com");

            Assert.IsType<ForbidResult>(result);
            Assert.Empty(context.GroupSpendersUser);
        }

        [Fact]
        public void AddUserToGroup_AsMember_AddsRecord()
        {
            using var context = CreateContext();
            context.Group.Add(new Group { GroupId = 1, Name = "Test" });
            context.SpendersUser.AddRange(
                new SpendersUser { Id = "member", Email = "member@example.com" },
                new SpendersUser { Id = "invitee", Email = "invitee@example.com" });
            context.GroupSpendersUser.Add(new GroupSpendersUser { GroupSpendersUserID = 10, GroupId = 1, SpendersUserId = "member" });
            context.SaveChanges();
            var controller = CreateController(context, "member");

            var result = controller.AddUserToGroup(1, "invitee@example.com");

            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Details", redirect.ActionName);
            Assert.Single(context.GroupSpendersUser.Where(gsu => gsu.SpendersUserId == "invitee"));
            Assert.Equal("invitee Added Successfully", controller.TempData["SuccessMessage"]);
        }

        private static GroupController CreateController(SpendersContext context, string currentUserId)
        {
            var groupRepo = new GroupRepository(context);
            var groupUserRepo = new GroupSpendersUserRepository(context);
            var expenseRepo = new ExpenseRepository(context);
            var userManager = MockUserManager();

            var controller = new GroupController(groupRepo, userManager.Object, context, groupUserRepo, expenseRepo);
            var httpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(
                    new[] { new Claim(ClaimTypes.NameIdentifier, currentUserId) }, "mock"))
            };
            controller.ControllerContext = new ControllerContext { HttpContext = httpContext };
            controller.TempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            return controller;
        }

        private static Mock<UserManager<SpendersUser>> MockUserManager()
        {
            var store = new Mock<IUserStore<SpendersUser>>();
            return new Mock<UserManager<SpendersUser>>(store.Object, null, null, null, null, null, null, null, null);
        }

        private static SpendersContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<SpendersContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new SpendersContext(options);
        }
    }
}
