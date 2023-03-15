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

namespace TeckRoad.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContentController : Controller
    {
        // private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ContentController(AppDbContext context, IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Create(int categoryItemId, int categoryId)
        {
            return View(new Content { CatItemId = categoryItemId, CategoryId = categoryId});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,HTMLContent,VideoLink, CatItemId, CategoryId")] Content content)
        {
            if (ModelState.IsValid)
            {
                content.CategoryItem = await _unitOfWork.CategoryItems.GetById(content.CatItemId);
                await _unitOfWork.Content.Add(content);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), "CategoryItem", new {categoryId = content.CategoryId});
            }
            return View(content);
        }

        public async Task<IActionResult> Edit(int categoryItemId, int categoryId)
        {
            if (categoryItemId == 0 || _unitOfWork.Content.isEmpty())
            {
                return NotFound();
            }

            var content = await _unitOfWork.Content.GetContentByCategoryId(categoryItemId);
            
            if (content == null)
            {
                return NotFound();
            }

            content.CategoryId = categoryId;

            return View(content);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,HTMLContent,VideoLink, CategoryId")] Content content)
        {
            if (id != content.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Content.Edit(content);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_unitOfWork.Content.ContentExists(content.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "CategoryItem", new {categoryId = content.CategoryId});
            }
            return View(content);
        }
    }
}
