using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class BookManagementService : IBookManagementService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public async Task CreateBookAsync(string title, DateTime publishDate, string authorName)
        {
           Book book = new Book { 
            Title = title,
            PublishDate = publishDate,
            AuthorName = authorName
           };
            _unitOfWork.BookRepository.Add(book);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteBookAsync(Guid id)
        {
            await _unitOfWork.BookRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _unitOfWork.BookRepository.GetByIdAsync(id);
        }

        public Task UpdateBookAsync(Guid id, string title, DateTime publishDate, string authorName)
        {
            throw new NotImplementedException();
        }
    }
}
