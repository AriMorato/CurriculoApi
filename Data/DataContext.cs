using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CurriculoApi.Model;

namespace CurriculoApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbOptions) : base(dbOptions){ }

        public DbSet<Curriculo> Curriculo { get; set; }
        public DbSet<Historico> Historico { get; set; }
        public DbSet<CurriculoApi.Model.StatusCurriculo> StatusCurriculo { get; set; }
    }
}
