using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_TP.Models
{
    public class ASPNet_TPContext : DbContext
    {
        public ASPNet_TPContext (DbContextOptions<ASPNet_TPContext> options)
            : base(options)
        {
        }

        public DbSet<ASP.Net_TP.Models.Movie> Movie { get; set; }
    }
}
