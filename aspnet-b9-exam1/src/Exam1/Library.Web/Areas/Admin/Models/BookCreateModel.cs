using Autofac;
using Library.Application.Services;

namespace Library.Web.Areas.Admin.Models
{
    public class BookCreateModel
    {
        private ILifetimeScope _scope;
        private IBookManagementService _bookManagementService;
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string AuthorName { get; set; }
        public BookCreateModel()
        {
            
        }
        public BookCreateModel(IBookManagementService bookManagement)
        {
            _bookManagementService = bookManagement;
        }
        internal void Resolve(ILifetimeScope scope)
        { 
            _scope = scope;
            _bookManagementService = _scope.Resolve<BookManagementService>();
        }
        internal async Task CreateCourseAsync() 
        {
            await _bookManagementService.CreateBookAsync(Title,PublishDate,AuthorName);
        }
    }
}
