using ItemsManager.Context;
using ItemsManager.Models;
using ItemsManager.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItemsManager.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext appDbContext;
        public ItemsController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            var items = await appDbContext.Items.ToListAsync();
            return View(items);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ItemViewModel addItemRequest)
        {
            var item = new ItemModel()
            {
                Name = addItemRequest.Name,
                Category = addItemRequest.Category,
                Price = addItemRequest.Price
            };

            await appDbContext.Items.AddAsync(item);
            await appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var item = await appDbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            
            if(item!=null)
            {
                var updatedModel = new ItemModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category,
                    Price = item.Price
                };
                return await Task.Run(()=>View("View",updatedModel));
            }
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(ItemModel itemToUpdate)
        {
            var item = await appDbContext.Items.FindAsync(itemToUpdate.Id);
            if (item != null)
            {
                item.Name = itemToUpdate.Name;
                item.Category = itemToUpdate.Category;
                item.Price = itemToUpdate.Price;

                await appDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ItemModel itemToDelete)
        {
            var item = await appDbContext.Items.FindAsync(itemToDelete.Id);

            if(item != null)
            {
                appDbContext.Items.Remove(item);
                await appDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
