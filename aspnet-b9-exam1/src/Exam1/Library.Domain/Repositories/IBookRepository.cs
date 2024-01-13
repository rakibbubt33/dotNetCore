using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public interface IBookRepository:IRepositoryBase<Book,Guid>
    {
        Task<bool> IsTitleDuplicateAsync(string title, Guid? id = null);
    }
}
