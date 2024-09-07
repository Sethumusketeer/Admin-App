using LogRegister.Models;
using Microsoft.EntityFrameworkCore;

namespace LogRegister
{
    public class DynamicDbContext(DbContextOptions<DynamicDbContext> options) : DbContext(options)
    {
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<ProfessionalDetails> ProfessionalDetails { get; set; }
        public DbSet<OtherDetails> OtherDetails { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<ProfilePicture> ProfilePicture { get; set; }
    }
}
