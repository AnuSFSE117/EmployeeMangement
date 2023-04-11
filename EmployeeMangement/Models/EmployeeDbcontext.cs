using Microsoft.EntityFrameworkCore;

namespace EmployeeMangement.Models
{
    public class EmployeeDbcontext : DbContext
    {
        public EmployeeDbcontext(DbContextOptions options):base(options) { }
         
           public DbSet<EmployeeModel> Employeetable { get; set; }
        

    }
}

    
    

