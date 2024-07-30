using Microsoft.EntityFrameworkCore;

namespace jasguarApi;

public class JasguarContext : DbContext
{

    public JasguarContext(DbContextOptions options) : base(options){}


    public DbSet<ACAdapter> ACAdapters { get; set; }
    public DbSet<ConnectorType> ConnectorTypes { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<DesktopSystem> DesktopSystems { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceType> DeviceTypes { get; set; } 
    public DbSet<Display> Displays{ get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Laptop> Laptops { get; set; }
    public DbSet<Material> Materials{ get; set; }
    public DbSet<Monitor> Monitors { get; set; }
    public DbSet<Printer> Printers{ get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserPermissions> UserPermissions { get; set; }
    public DbSet<ScreenApp> ScreenApps { get; set; }
    
}
