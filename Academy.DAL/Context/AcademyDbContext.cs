using Academy.Models.Core;
using Academy.Models.Training;
using Academy.Models.TrainingApplication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Academy.DAL.Context
{
    public class AcademyDbContext : IdentityDbContext<ApplicationUser>
    {
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Iterate through all EF Entity types
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                #region Convert UniqueKeyAttribute on Entities to UniqueKey in DB
                var properties = entityType.GetProperties();
                if (properties != null && properties.Any())
                {
                    foreach (var property in properties)
                    {
                        var uniqueKeys = GetUniqueKeyAttributes(entityType, property);
                        if (uniqueKeys != null)
                        {
                            foreach (var uniqueKey in uniqueKeys.Where(x => x.Order == 0))
                            {
                                // Single column Unique Key
                                if (string.IsNullOrWhiteSpace(uniqueKey.GroupId))
                                {
                                    entityType.AddIndex(property).IsUnique = true;
                                }
                                // Multiple column Unique Key
                                else
                                {
                                    var mutableProperties = new List<IMutableProperty>();
                                    properties.ToList().ForEach(x =>
                                    {
                                        var uks = GetUniqueKeyAttributes(entityType, x);
                                        if (uks != null)
                                        {
                                            foreach (var uk in uks)
                                            {
                                                if (uk != null && uk.GroupId == uniqueKey.GroupId)
                                                {
                                                    mutableProperties.Add(x);
                                                }
                                            }
                                        }
                                    });
                                    entityType.AddIndex(mutableProperties).IsUnique = true;
                                }
                            }
                        }
                    }
                }
                #endregion Convert UniqueKeyAttribute on Entities to UniqueKey in DB
            }

            // any guid
            string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e513";
            string SUPERADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e613";
            string STAFF = "a18be9c0-aa65-4af8-bd17-00bd934nfn13";
            string APPLICANT = "a18be9c0-aa65-4af8-kj17-00bd934nfn13";
            // any guid, but nothing is against to use the same one
            string ROLE_ID = ADMIN_ID;
            string SUPERROLE_ID = SUPERADMIN_ID;
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Admin",
                NormalizedName = "Admin"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = SUPERROLE_ID,
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = APPLICANT,
                Name = "Applicant",
                NormalizedName = "APPLICANT"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = STAFF,
                Name = "Staff",
                NormalizedName = "STAFF"
            });

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "Admin@icaacademy.com",
                Email = "Admin@icaacademy.com",
                NormalizedUserName = "ADMIN@ICAACADEMY.COM",
                NormalizedEmail = "ADMIN@ICAACADEMY.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "AdminicaAcademy@12345.."),
                SecurityStamp = string.Empty
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = SUPERADMIN_ID,
                UserName = "SuperAdmin@icaacademy.com",
                Email = "SuperAdmin@icaacademy.com",
                NormalizedUserName = "SUPERADMIN@ICAACADEMY.COM",
                NormalizedEmail = "SUPERADMIN@ICAACADEMY.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "supericaAcademy@12345"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = SUPERROLE_ID,
                UserId = SUPERADMIN_ID
            });
        }

        private static IEnumerable<UniqueKeyAttribute> GetUniqueKeyAttributes(IMutableEntityType entityType, IMutableProperty property)
        {
            if (entityType == null)
            {
                throw new ArgumentNullException(nameof(entityType));
            }
            else if (entityType.ClrType == null)
            {
                throw new ArgumentNullException(nameof(entityType.ClrType));
            }
            else if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            else if (property.Name == null)
            {
                throw new ArgumentNullException(nameof(property.Name));
            }
            var propInfo = entityType.ClrType.GetProperty(
                property.Name,
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly);
            if (propInfo == null)
            {
                return null;
            }
            return propInfo.GetCustomAttributes<UniqueKeyAttribute>();
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ProfessionalCategory> ProfessionalCategories { get; set; }

        public DbSet<SessionSpeaker> SessionSpeakers { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<TrainingSchedule> TrainingSchedules { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<TraningType> TraningTypes { get; set; }
            
        public DbSet<AcademicQualification> AcademicQualifications { get; set; }
        public DbSet<ApplicantSchedule> ApplicantSchedules { get; set; }
        public DbSet<WorkingExperience> WorkingExperiences { get; set; }


    }
}
