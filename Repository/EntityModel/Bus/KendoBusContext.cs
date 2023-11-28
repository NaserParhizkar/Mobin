using KendoBus.Repository;
using Microsoft.EntityFrameworkCore;

namespace KendoBus
{
    public class KendoBusContext : DbContext
    {
        public KendoBusContext() { }

        public KendoBusContext(DbContextOptions<KendoBusContext> options) : base(options) { }

        public DbSet<Bus> Buses { get; set; }
        public DbSet<Path> Paths { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<PathDetail> PathDetails { get; set; }
        public DbSet<BusOwner> BusOwners { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountGroup> AccountGroups { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<News> Newses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<WorksOn> WorksOns { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=IT-LA-TEH3628\\;Database=KendoKendoBusContext;user=sa;password=N@$er8989");
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.HasDefaultSchema("dbo");

        //    //modelBuilder.Properties().Where(t => t.PropertyType == typeof(string)).
        //    //    Configure(t => t.IsUnicode(false));

        //    //modelBuilder.Entity<Account>().HasRequired(t => t.Employee).WithOptional(
        //    //    f => f.Account).Map(f => f.MapKey("EmpID"));

        //    //modelBuilder.Entity<Account>().HasMany(t => t.ActionsAccess).WithMany(
        //    //    r => r.AccessByAccount).Map(g => g.ToTable("AccountAction"));

        //    base.SaveChanges();
        //}
    }

    //public class AddMenuToDatabase
    //{
    //    public AddMenuToDatabase(KendoBusContext context)
    //    {
    //        Assembly asm = Assembly.GetExecutingAssembly();

    //        var controllers = asm.GetTypes()
    //            .Where(type => typeof(Controller).IsAssignableFrom(type)) //filter controllers
    //            .Select(type => type).ToList();

    //        try
    //        {
    //            if (context != null)
    //            {
    //                controllers.ForEach(t =>
    //                {
    //                    if (context.DbController.SingleOrDefault(c => c.Name == t.Name) == null)
    //                    {
    //                        DbController controller =
    //                           new DbController
    //                           {
    //                               Name = t.Name,
    //                               TextController = ((MenuAttribute)t.GetCustomAttribute(typeof(MenuAttribute))).ControllerName,
    //                               Actions = GetMenuAttribute(t)
    //                           };
    //                        context.DbController.Add(controller);
    //                    }
    //                    context.SaveChanges();
    //                });
    //            }
    //        }
    //        catch(Exception ex)
    //        {
    //            string message = ex.Message;
    //        }
    //    }
    //    private List<DbAction> GetMenuAttribute(Type dbActionType) 
    //    {
    //        List<MenuAttribute> attrs = new List<MenuAttribute>();

    //        List<MethodInfo> lstMethodInfo = dbActionType.GetMethods().Where(w => 
    //            w.ReturnType.IsSubclassOf(typeof(ActionResult)) || w.ReturnType == typeof(ActionResult))
    //            .ToList();
    //        List<DbAction> lstActions = new List<DbAction>();
    //        foreach (var item in lstMethodInfo) 
    //        {
    //            MenuAttribute attr = 
    //                (MenuAttribute)item.GetCustomAttribute(typeof(MenuAttribute));
    //            if (attr != null)
    //                lstActions.Add(new DbAction
    //                {
    //                    Name = item.Name,
    //                    TextMenu = attr.ActionName,
    //                    Url = dbActionType.Name+"/"+item.Name
    //                });
    //        }
    //        return lstActions;
    //    }
    //}
}