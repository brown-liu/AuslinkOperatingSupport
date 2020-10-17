using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuslinkOperatingSupport.Models;


namespace AuslinkOperatingSupport.Data
{
    public class MvcAuslinkContext : DbContext
    {
        public MvcAuslinkContext(DbContextOptions<MvcAuslinkContext> options) : base(options)
        {


        }
        public DbSet<ClientClass> ClientClasses { get;set;}
        public DbSet<ContainerClass> ContainerClasses { get; set; }
        public DbSet<Staff_class> staff_Classes { get; set; }

    }
}
