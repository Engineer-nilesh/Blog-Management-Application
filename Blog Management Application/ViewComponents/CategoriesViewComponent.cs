using Blog_Management_Application.Data;
using Blog_Management_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog_Management_Application.ViewComponents
{
    public class CategoriesViewComponent: ViewComponent
    {
        private readonly BlogManagementDBContext _context;
        public CategoriesViewComponent(BlogManagementDBContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
            //View Location shuld be : Views/Shared/Components/Categories/Default.cshtml
            return View(categories);
        }
    }
}
