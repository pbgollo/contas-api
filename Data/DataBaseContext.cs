using ContasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContasAPI.Data {
    public class DataBaseContext : DbContext {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<RegraNegocio> RegrasNegocio { get; set; }
    }
}