using Progetto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto1.Manager
{
    public class EsameManager : IEsameManager
    {
        private readonly AppDbContext _appDbContext;
        public EsameManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<int> AddEsame(string nome)
        {
            _appDbContext.Esami.Add(new Esame { Nome = nome});
            return _appDbContext.SaveChangesAsync();
        }

        public Task<int> RemoveEsame(string nome)
        {
            _appDbContext.Esami.Remove(new Esame { Nome = nome });
            return _appDbContext.SaveChangesAsync();
        }


    }
}
