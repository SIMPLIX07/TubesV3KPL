// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using TubesV3;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Perusahaan> Perusahaans => Set<Perusahaan>();
    public DbSet<Pelamar> Pelamars => Set<Pelamar>();
    public DbSet<Lowongan> Lowongans => Set<Lowongan>();
    public DbSet<LowonganPelamar> Lamarans => Set<LowonganPelamar>();
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<KaryawanPerusahaan> KaryawanPerusahaans => Set<KaryawanPerusahaan>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Mengonversi enum ke string jika ingin menyimpan sebagai string
        modelBuilder.Entity<Pelamar>()
            .Property(p => p.state)
            .HasConversion<string>();  // Menggunakan string, atau bisa menggunakan integer
    }
}
