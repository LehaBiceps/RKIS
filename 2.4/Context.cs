using Microsoft.EntityFrameworkCore;
public partial class context : DbContext
{
    public context()
    {
        
    }

    public context(DbContextOptions<context> options) : base(options)
    {
        
    }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("person");
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.password)
                .HasMaxLength(50)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("task");
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.name).HasColumnName("name");
            entity.Property(e => e.description).HasColumnName("description");
            entity.Property(e => e.date).HasColumnName("date");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}