using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto1.Manager
{
    public interface IEsameManager
    {
        Task<int> AddEsame(string nome, int voto, int idStudente);
        Task RemoveEsame(int id);
    }
}
