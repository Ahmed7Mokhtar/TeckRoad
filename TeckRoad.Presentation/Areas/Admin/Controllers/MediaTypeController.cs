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
    public class MediaTypeController : Controller
    {
        // private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public MediaTypeController(AppDbContext context, IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
              return View(await _unitOfWork.MediaTypes.All());
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0 || _unitOfWork.MediaTypes.isEmpty())
            {
                return NotFound();
            }

            var mediaType = await _unitOfWork.MediaTypes.GetById(id);
            if (mediaType == null)
            {
                return NotFound();
            }

            return View(mediaType);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ThumbnailImagePath")] MediaType mediaType)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.MediaTypes.Add(mediaType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mediaType);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0 || _unitOfWork.MediaTypes.isEmpty())
            {
                return NotFound();
            }

            var mediaType = await _unitOfWork.MediaTypes.GetById(id);
            if (mediaType == null)
            {
                return NotFound();
            }
            return View(mediaType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ThumbnailImagePath")] MediaType mediaType)
        {
            if (id != mediaType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _unitOfWork.MediaTypes.Edit(mediaType);
                   await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_unitOfWork.MediaTypes.MediaTypeExists(mediaType.Id))
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
            return View(mediaType);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0 || _unitOfWork.MediaTypes.isEmpty())
            {
                return NotFound();
            }

            var mediaType = await _unitOfWork.MediaTypes.GetById(id);
            if (mediaType == null)
            {
                return NotFound();
            }

            return View(mediaType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.MediaTypes.isEmpty())
            {
                return Problem("Entity set 'AppDbContext.MediaType'  is null.");
            }
            
            var isDeleted = await _unitOfWork.MediaTypes.Delete(id);
            if (isDeleted == true)
                await _unitOfWork.CompleteAsync();
                
            return RedirectToAction(nameof(Index));
        }
    }
}
