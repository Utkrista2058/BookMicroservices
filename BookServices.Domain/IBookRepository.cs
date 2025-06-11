using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookServices.Domain.Interfaces
{
    public interface IBookRepository
    {
        Books GetById(int id);
        IEnumerable<Books> GetAll();
        void Add(Books book);
        void Update(Books book);
        void Delete(int id);
    }
}
