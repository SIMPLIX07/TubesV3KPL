// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using TubesV3;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {}

    public DbSet<Perusahaan> Perusahaans => Set<Perusahaan>();
    public DbSet<Pelamar> Pelamars => Set<Pelamar>();
    public DbSet<Lowongan> Lowongans => Set<Lowongan>();
    public DbSet<LowonganPelamar> Lamarans => Set<LowonganPelamar>();
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<KaryawanPerusahaan> KaryawanPerusahaans => Set<KaryawanPerusahaan>();
    
}
