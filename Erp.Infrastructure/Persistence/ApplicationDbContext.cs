using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Erp.Application.Common.Interfaces;
using Erp.Application.Common.Models;
using Erp.Domain.Common;
using Erp.Domain.Entities.MenuPermission;
using Erp.Domain.Entities.CommonSettings;


using Erp.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



/*Dont even dare to add new model without knowing the logic because some models are working through Dapper*/


namespace Erp.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
        UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<RequestLoggerEntity> LoggerEntities { get; set; }

    
    
        //Common Settings
        public DbSet<FactorySettingModel> FactorySettings { get; set; }
        public DbSet<SizeSetupModel> SizesSetup { get; set; }
        // public DbSet<StyleSettingModel> StyleSettings { get; set; }
        // public DbSet<StyleProcessModel> StyleProcesses { get; set; }
        // public DbSet<StyleFabricModel> StyleFabricProcess { get; set; }
        public DbSet<ColorSettingModel> ColorSettings { get; set; }
        //public DbSet<StyleFabricHead> StyleFabricHeads { get; set; }
        //public DbSet<StylePartInfo> StylePartInfos { get; set; }

        
        //Multiple File Save
        public DbSet<FileObjectModel> FileObjects { get; set; }
        public DbSet<FileModel> Files { get; set; }
        //Authentication Authorization
        public DbSet<ActionModel> ActionsList { get; set; }
        public DbSet<MenuMainModel> MenuMains { get; set; }
        public DbSet<MenuSubModel> MenuSubs { get; set; }
        public DbSet<MenuSubSubModel> MenuSubSubs { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.EmployeeId;
                        entry.Entity.CreateDate = _dateTime.Now;
                        entry.Entity.HeadOfficeId = _currentUserService.HeadOfficeId;
                        entry.Entity.BranchOfficeId = _currentUserService.BranchOfficeId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateBy = _currentUserService.EmployeeId;
                        entry.Entity.UpdateDate = _dateTime.Now;
                        entry.Entity.HeadOfficeId = _currentUserService.HeadOfficeId;
                        entry.Entity.BranchOfficeId = _currentUserService.BranchOfficeId;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();


            });





        }
    }
}
