using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public async Task<int> AddStudente(string nome, string cognome)
        {
            var studente = new Studente { Nome = nome, Cognome = cognome };
            _appDbContext.Studenti.Add(studente);
            await _appDbContext.SaveChangesAsync();
            return studente.Id;
        }

        public async Task RemoveStudente(int studenteId)
        {
            //var studenteDaRimuovere = await _appDbContext.Studenti.GroupBy(x => x.EsamiFatti).ToListAsync();
            using (var dbContextTransaction = _appDbContext.Database.BeginTransaction())
            {
                try
                {
                    var studenteDaRimuovere = _appDbContext.Studenti.Include(s => s.EsamiFatti).SingleOrDefault(s => s.Id == studenteId);

                    if (studenteDaRimuovere != null)
                    {
                        _appDbContext.Esami.RemoveRange(studenteDaRimuovere.EsamiFatti);
                        _appDbContext.Studenti.Remove(studenteDaRimuovere);
                        await _appDbContext.SaveChangesAsync();
                        dbContextTransaction.Commit();
                    }
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }

                using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = factory.CreateLogger("Program");
                logger.LogInformation("Modifiche avvenute!");

                //_appDbContext.Studenti.Remove(new Studente { Nome = nome, Cognome = cognome });
                await _appDbContext.SaveChangesAsync();
            }


        }
    }
}
