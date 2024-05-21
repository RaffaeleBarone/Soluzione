using Microsoft.EntityFrameworkCore;
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
        public async Task<int> AddEsame(string nome, int voto, int idStudente)
        {
            var Esame = new Esame { Nome = nome, Voto = voto, IdStudente = idStudente };
            _appDbContext.Esami.Add(Esame);
             await _appDbContext.SaveChangesAsync();
            return Esame.Id;
            
        }

        public async Task RemoveEsame(int id)
        {
            var esameDaRimuovere = await _appDbContext.Esami.FirstOrDefaultAsync(x => x.Id == id);
            if(esameDaRimuovere != null)
            {
                _appDbContext.Esami.Remove(esameDaRimuovere);
                await _appDbContext.SaveChangesAsync();
            }
           

        }


    }
}
