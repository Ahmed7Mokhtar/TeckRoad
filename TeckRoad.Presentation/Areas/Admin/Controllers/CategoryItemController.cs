using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeckRoad.DataService.Data;
using TeckRoad.DataService.IConfig;
using TeckRoad.Entities.DbSets;
using TeckRoad.Presentation.Extensions;

namespace TeckRoad.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryItemController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryItemController(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/CategoryItem
        public async Task<IActionResult> Index(int categoryId)
        {
            var categoryItems = await _unitOfWork.CategoryItems.All(categoryId);


            foreach (var item in categoryItems)
            {
                var contnet = _context.Content.AsNoTracking().FirstOrDefault(x => x.CategoryItem.Id == item.Id);
                item.ContentId = (contnet != null) ? contnet.Id : 0;
            }


            ViewBag.CategoryId = categoryId;  

            return View(categoryItems);
        }

        // GET: Admin/CategoryItem/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0 || _unitOfWork.CategoryItems.isEmpty())
            {
                return NotFound();
            }

            var categoryItem = await _unitOfWork.CategoryItems.GetById(id);
            if (categoryItem == null)
            {
                return NotFound();
            }

            return View(categoryItem);
        }

        // GET: Admin/CategoryItem/Create
        public async Task<IActionResult> Create(int categoryId)
        {
            List<MediaType> mediaTypes = (List<MediaType>)await _unitOfWork.MediaTypes.All();

            CategoryItem categoryItem = new CategoryItem
            {
                CategoryId = categoryId,
                MediaTypes = mediaTypes.ConvertToSelectList(0)
            };

            return View(categoryItem);
        }

        // POST: Admin/CategoryItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CategoryId,MediaTypeId,DateTimeItemReleased")] CategoryItem categoryItem)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.CategoryItems.Add(categoryItem);
                await _unitOfWork.CompleteAsync();

                return RedirectToAction(nameof(Index), new {categoryId = categoryItem.CategoryId});
            }
            return View(categoryItem);
        }

        // GET: Admin/CategoryItem/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0 || _unitOfWork.CategoryItems.isEmpty())
            {
                return NotFound();
            }


            var categoryItem = await _unitOfWork.CategoryItems.GetById(id);
            if (categoryItem == null)
            {
                return NotFound();
            }

            List<MediaType> mediaTypes = (List<MediaType>) await _unitOfWork.MediaTypes.All();
            categoryItem.MediaTypes = mediaTypes.ConvertToSelectList(categoryItem.MediaTypeId);

            return View(categoryItem);
        }

        // POST: Admin/CategoryItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CategoryId,MediaTypeId,DateTimeItemReleased")] CategoryItem categoryItem)
        {
            if (id != categoryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.CategoryItems.Edit(categoryItem);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_unitOfWork.CategoryItems.CategoryItemExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new {categoryId = categoryItem.CategoryId});
            }
            return View(categoryItem);
        }

        // GET: Admin/CategoryItem/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0 || _unitOfWork.CategoryItems.isEmpty())
            {
                return NotFound();
            }

            var categoryItem = await _unitOfWork.CategoryItems.GetById(id);
            if (categoryItem == null)
            {
                return NotFound();
            }

            return View(categoryItem);
        }

        // POST: Admin/CategoryItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.CategoryItems.isEmpty())
            {
                return Problem("Entity set 'AppDbContext.categoryItem'  is null.");
            }
            var categoryItem = await _unitOfWork.CategoryItems.GetById(id);
            if (categoryItem != null)
            {
                await _unitOfWork.CategoryItems.Delete(id);
            }
            await _unitOfWork.CompleteAsync();
            
            return RedirectToAction(nameof(Index), new {categoryId = categoryItem.CategoryId});
        }
    }
}
