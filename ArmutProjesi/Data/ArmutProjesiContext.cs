using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityLayer;

namespace ArmutProjesi.Data
{
    public class ArmutProjesiContext : DbContext
    {
        public ArmutProjesiContext (DbContextOptions<ArmutProjesiContext> options)
            : base(options)
        {
        }

        public DbSet<EntityLayer.Kategori> Kategori { get; set; } = default!;
    }
}
