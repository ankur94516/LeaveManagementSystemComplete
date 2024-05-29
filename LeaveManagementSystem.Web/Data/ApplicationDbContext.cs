using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<LeaveType> LeaveTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // seed the IdentityRoles Table
            builder.Entity<IdentityRole>().HasData(
                        new IdentityRole
                        {
                            Id = "d3b38299-e30c-4cac-8b81-f816aa5f1ef9",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE".ToUpper()
                        },
                        new IdentityRole
                        {
                            Id = "2e02a921-c40b-47b8-8c3c-91749113f863",
                            Name = "Supervisor",
                            NormalizedName = "SUPERVISOR".ToUpper()
                        },
                        new IdentityRole
                        {
                            Id = "059ff44e-6f91-4cb4-9c7c-e85be3326c7c",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR".ToUpper()
                        }
                    );

            var hasher = new PasswordHasher<ApplicationUser>();

            // seed the IdentityUser Table
            builder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser
                    {
                        Id = "af680b95-2a36-463d-8653-ab0fc6d69f98",
                        Email = "admin@localhost.com",
                        NormalizedEmail = "admin@localhost.com".ToUpper(),
                        UserName = "admin@localhost.com",
                        NormalizedUserName = "admin@localhost.com".ToUpper(),
                        PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                        EmailConfirmed = true,
                        FirstName = "Default",
                        LastName = "Admin",
                        DateOfBirth = new DateOnly(1990, 12, 01)
                    }
               );

            // seeding to UserRoles Table
            builder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "059ff44e-6f91-4cb4-9c7c-e85be3326c7c",
                        UserId = "af680b95-2a36-463d-8653-ab0fc6d69f98"
                    }
                );
        }

    }
}
