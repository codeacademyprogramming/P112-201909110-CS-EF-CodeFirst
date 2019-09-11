using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GunelEF.Models;

namespace GunelEF.DAL
{
    class ComputerContext: DbContext
    {
        public ComputerContext():base("ComputerDbConnection")
        {
        }

        public DbSet<Computer> Computers{ get; set; }


    }
}
