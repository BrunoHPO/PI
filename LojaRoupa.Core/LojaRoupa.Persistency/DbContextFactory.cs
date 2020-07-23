using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaRoupa.Persistency
{
    public class LojaDbContextFactory : IDesignTimeDbContextFactory<LojaDbContext>
    {
        public LojaDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<LojaDbContext>();
            options.UseSqlite("Filename=Loja.db", opt =>
            {
                opt.MigrationsAssembly(
                    typeof(LojaDbContext).Assembly.FullName
                );
            });

            return new LojaDbContext(options.Options);
        }
    }
}
