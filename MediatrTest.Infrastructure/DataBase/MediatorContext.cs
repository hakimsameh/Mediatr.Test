namespace MediatrTest.Infrastructure.DataBase
{
    public class MediatorContext : DbContext
    {
        public MediatorContext(DbContextOptions options)
        : base(options)
        { 

        }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<DataLog> Logs { get; set; }
        public DbSet<StoreData> StoreData { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ItemModel>().HasKey(x => x.Id);
            modelBuilder.Entity<ItemModel>().Property(x=>x.Id).ValueGeneratedNever();

            modelBuilder.Entity<DataLog>().HasKey(x => x.Id);
            modelBuilder.Entity<DataLog>().Property(x => x.Id).ValueGeneratedNever();

            modelBuilder.Entity<StoreData>().HasKey(x => x.Id);
            modelBuilder.Entity<StoreData>().Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
