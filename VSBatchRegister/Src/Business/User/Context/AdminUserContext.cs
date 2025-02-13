using Microsoft.EntityFrameworkCore;
using VSBatchRegister.Business.User.Model;
using VSBatchRegister.Serialize;

namespace VSBatchRegister.Business.User.Context;

public class AdminUserContext(DbContextOptions<AdminUserContext> options) : DbContext(options)
{
    public DbSet<AdminUser> Detail { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }

        var connectionString = GlobalProjectConfig.Instance.Config?.DBTest;
        optionsBuilder.UseMySql(connectionString,
            new MySqlServerVersion(new Version(8, 0, 21))
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

/// <summary>
/// 银行信息表上下文 工厂模式(线程安全的)
/// </summary>
public class AdminUserContextFactory : IDbContextFactory<AdminUserContext>
{
    public AdminUserContext CreateDbContext()
    {
        var connectionString = GlobalProjectConfig.Instance.Config?.DB;
        var options = new DbContextOptionsBuilder<AdminUserContext>()
            .UseMySql(connectionString!, new MySqlServerVersion(new Version(8, 0, 21)))
            .Options;

        return new AdminUserContext(options);
    }
}