using AutoKatalogas.Models;
using Microsoft.EntityFrameworkCore;
using AutoKatalogas.Auth.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AutoKatalogas.Data
{
    public class ApiContext : IdentityDbContext<ForumRestUser>
    {
        public DbSet<Automobiliai> Autos { get; set; }
        public DbSet<Aprasymas> Descriptions { get; set; }
        public DbSet<Dalys> Parts { get; set; }
        public DbSet<Schema> Scheme { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
    }
}
