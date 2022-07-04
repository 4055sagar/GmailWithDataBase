using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GmailWithDataBase.Models;

namespace GmailWithDataBase.DataAccessLayer_Ef
{
    public class DataAccessLayer_EF:DbContext
    {
        public DataAccessLayer_EF(DbContextOptions<DataAccessLayer_EF>options):base(options)
        {
                
        }

        public DbSet<EmployeeModel> Employee { get; set; }
    }
}
