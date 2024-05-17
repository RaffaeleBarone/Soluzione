using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto1.Manager
{
    public interface IStudenteManager
    {
        Task<int> AddStudente(string nome, string cognome);
        Task<int> RemoveStudente(string nome, string cognome);
    }
}
