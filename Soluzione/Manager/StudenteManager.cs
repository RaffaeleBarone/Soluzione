using Microsoft.EntityFrameworkCore;
using Progetto1.Models;

namespace Progetto1.Manager
{
    public class StudenteManager : IStudenteManager
    {
        private readonly AppDbContext _appDbContext;
        public StudenteManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<int> AddStudente(string nome, string cognome)
        {
            _appDbContext.Studenti.Add(new Studente { Nome = nome, Cognome = cognome });
            return _appDbContext.SaveChangesAsync();             
        }

        public Task<int> RemoveStudente(string nome, string cognome)
        {
            _appDbContext.Studenti.Remove(new Studente { Nome = nome, Cognome = cognome });
            return _appDbContext.SaveChangesAsync();
        }


    }
}
