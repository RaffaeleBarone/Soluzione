using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto1.Manager
{
    public interface IEsameManager
    {
        Task<int> AddEsame(string nome);
        Task<int> RemoveEsame(string nome);
    }
}
