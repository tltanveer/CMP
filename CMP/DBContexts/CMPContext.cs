using Microsoft.EntityFrameworkCore;
using CMP.Models;

namespace CMP.DBContexts
{
    public class CMPContext: DbContext
    {
        public CMPContext(DbContextOptions<CMPContext> options) : base(options)
        {
        }
        public DbSet<ClientMSA> ClientMSA { get; set; }
        public DbSet<ClientNDA> ClientNDA { get; set; }
        public DbSet<PartnerNDA> PartnerNDA { get; set; }
    }
}
