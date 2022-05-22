using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spenders.Areas.Identity.Data;
using Spenders.Models;

namespace Spenders.Data
{
    public class SpendersContext : IdentityDbContext<SpendersUser>
    {
        public SpendersContext(DbContextOptions<SpendersContext> options)
            : base(options)
        {
        }

        public DbSet<Group> Group { get; set; }
        public DbSet<GroupSpendersUser> GroupSpendersUser { get; set; }
        public DbSet<SpendersUser> SpendersUser { get; set; }
        public DbSet<Expense> Expenses{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<SpendersUser>().HasData(new SpendersUser { Email ="Gonza@Gmail.com", FirstName= "Gonzalo", LastName ="Fernandez"});
            builder.Entity<SpendersUser>().HasData(new SpendersUser { Email = "Ashley@Gmail.com", FirstName = "Ashley", LastName = "Hague" });
            builder.Entity<SpendersUser>().HasData(new SpendersUser { Email = "Eduardo@Gmail.com", FirstName = "Eduardo", LastName = "Simonson" });


            builder.Entity<Group>().HasData(new Group { GroupId = 1, Name = "Spending at home", Description = "Spendings at home" });
            builder.Entity<Group>().HasData(new Group { GroupId = 2, Name = "Spending at home", Description = "Spendings at the office" });
            builder.Entity<Group>().HasData(new Group { GroupId = 3, Name = "Spending at home", Description = "Spendings during holiday" });

            builder.Entity<GroupSpendersUser>().HasData(new GroupSpendersUser { GroupSpendersUserID = 1, GroupId = 1, SpendersUserId = "1" });
            builder.Entity<GroupSpendersUser>().HasData(new GroupSpendersUser { GroupSpendersUserID = 2, GroupId = 1, SpendersUserId = "2" });
            builder.Entity<GroupSpendersUser>().HasData(new GroupSpendersUser { GroupSpendersUserID = 3, GroupId = 2, SpendersUserId = "2" });
            builder.Entity<GroupSpendersUser>().HasData(new GroupSpendersUser { GroupSpendersUserID = 4, GroupId = 2, SpendersUserId = "3" });
            builder.Entity<GroupSpendersUser>().HasData(new GroupSpendersUser { GroupSpendersUserID = 5, GroupId = 3, SpendersUserId = "1" });
            builder.Entity<GroupSpendersUser>().HasData(new GroupSpendersUser { GroupSpendersUserID = 6, GroupId = 3, SpendersUserId = "2" });
            builder.Entity<GroupSpendersUser>().HasData(new GroupSpendersUser { GroupSpendersUserID = 7, GroupId = 3, SpendersUserId = "3" });

            builder.Entity<Expense>().HasData(new Expense { ExpenseId = 1, Name = "New world", GroupId = 1});
            builder.Entity<Expense>().HasData(new Expense { ExpenseId = 2, Name = "Take out", GroupId = 1});
        }
    }
}
