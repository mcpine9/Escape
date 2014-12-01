using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Escape.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Escape.Data
{
    public class ApplicationDBConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public ApplicationDBConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //if (!context.Users.Any(c => c.UserName == "mcpine9"))
            //{
            var user = context.Users.FirstOrDefault(u => u.Email == "mcpine9@yahoo.com");
            if (user != null)
            {
                    context.Roles.Add(new IdentityRole("SuperAdmin"));
                    context.SaveChanges();
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    //var user = new ApplicationUser() { UserName = "mcpine9", Email = "mcpine9@yahoo.com", EmailConfirmed = true };
                    manager.AddToRole(user.Id, "SuperAdmin");
                    //manager.Create(user, "uD6Id+iA*b");

            }
           // }
        }
    }
}