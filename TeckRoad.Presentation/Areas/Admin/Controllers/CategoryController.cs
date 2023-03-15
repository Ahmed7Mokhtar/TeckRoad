using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeckRoad.DataService.Data;
using TeckRoad.DataService.IConfig;
using TeckRoad.Entities.DbSets;

namespace TeckRoad.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        //private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(AppDbContext context, IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Category
        public async Task<IActionResult> Index()
        {
              return View(await _unitOfWork.Categories.All());
        }

        // GET: Admin/Category/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0 || _unitOfWork.Categories.isEmpty())
            {
                return NotFound();
            }

            var category = await _unitOfWork.Categories.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ThumbnailImagePath")] Category category)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Categories.Add(category);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0 || _unitOfWork.Categories.isEmpty())
            {
                return NotFound();
            }

            var category = await _unitOfWork.Categories.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ThumbnailImagePath")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Categories.Edit(category);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_unitOfWork.Categories.CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/Category/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0 || _unitOfWork.Categories.isEmpty())
            {
                return NotFound();
            }

            var category = await _unitOfWork.Categories.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.Categories.isEmpty())
            {
                return Problem("Entity set 'AppDbContext.Category'  is null.");
            }
            var isDeleted = await _unitOfWork.Categories.Delete(id);
            if (isDeleted)
                await _unitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
