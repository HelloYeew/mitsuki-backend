using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mitsuki.Models;

namespace Mitsuki;

public class MitsukiDatabaseContext : IdentityDbContext<User>
{
    public MitsukiDatabaseContext(DbContextOptions<MitsukiDatabaseContext> options)
        : base(options)
    {
    }
    
    public DbSet<Profile> Profiles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var newUsers = ChangeTracker.Entries<User>()
            .Where(e => e.State == EntityState.Added)
            .Select(e => e.Entity);
        
        var profiles = new List<Profile>();

        foreach (var user in newUsers)
        {
            var profile = new Profile
            {
                UserId = user.Id,
                User = user
            };
            profiles.Add(profile);
        }
        
        Profiles.AddRange(profiles);

        return await base.SaveChangesAsync(cancellationToken);
    }
}