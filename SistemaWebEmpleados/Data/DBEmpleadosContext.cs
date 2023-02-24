using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleados.Models;

namespace SistemaWebEmpleados.Data
{
    public class DBEmpleadosContext : DbContext
    {
        public DBEmpleadosContext(DbContextOptions<DBEmpleadosContext> options) : base(options) { }                          
        public DbSet<Empleado> Empleados { get; set; }        
    }
}
