using Autofac;
using Library.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BookController : Controller
	{
		private readonly ILifetimeScope _scope;
		private readonly ILogger<BookController> _logger;
        public BookController(ILifetimeScope scope,ILogger<BookController> logger)
        {
				_scope = scope;
				_logger = logger;
        }
        public IActionResult Index()
		{
			return View();
		}
		public IActionResult Create()
		{
			var model = _scope.Resolve<BookCreateModel>();
			return View();
		}
		[HttpPost,ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(BookCreateModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					model.Resolve(_scope);
					await model.CreateCourseAsync();
					return RedirectToAction("Index");
				}
				catch (Exception e)
				{

					_logger.LogError(e,"error in create");
				}
			}
            return View(model);
        }


	}
}
