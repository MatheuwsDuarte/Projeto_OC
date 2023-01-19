using OperacaoCuriosidade.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacaoCuriosidade.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Data Source=DESKTOP-5GB3ASG\\SQLDUARTE;Initial Catalog=operacaoC;TrustServerCertificate=true; Integrated Security=true")
        {
            Database.SetInitializer<DataContext>(null);
        }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
