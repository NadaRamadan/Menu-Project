using Menu.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuContext _context;
        public MenuController(MenuContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index (string searchString)
        {
            var dishes = from d in _context.Dish
                         select d;
            if (!string.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(dishes => dishes.Name.Contains(searchString));

            }
            return View(await dishes.ToListAsync());

        }
        public async Task <IActionResult> Details (int? id)
        {
            var Dish = await _context.Dish.
                Include(di => di.DishIngredient).
                ThenInclude(i => i.Ingredient).
                FirstOrDefaultAsync(x => x.Id == id);

            if (Dish == null)
            {
                return NotFound();
            }
            return View(Dish);
        }

    }
}
