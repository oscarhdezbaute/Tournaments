using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tournaments.Web.Data;
using Tournaments.Web.Data.Entities;
using Tournaments.Web.Helpers;
using Tournaments.Web.Models;

namespace Tournaments.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SportsController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public SportsController(DataContext context, IImageHelper imageHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }

        // GET: Sports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sports.OrderBy(t => t.Name).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SportEntity sportEntity = await _context.Sports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportEntity == null)
            {
                return NotFound();
            }

            return View(sportEntity);
        }

        // GET: Sports/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SportViewModel sportViewModel)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;

                if (sportViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(sportViewModel.LogoFile, "Sports");
                }

                SportEntity sportEntity = _converterHelper.ToSportEntity(sportViewModel, path, true);

                _context.Add(sportEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists the sport: {sportEntity.Name}");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(sportViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SportEntity sportEntity = await _context.Sports.FindAsync(id);
            if (sportEntity == null)
            {
                return NotFound();
            }

            SportViewModel sportViewModel = _converterHelper.ToSportViewModel(sportEntity);
            return View(sportViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SportViewModel sportViewModel)
        {
            if (id != sportViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string path = sportViewModel.LogoPath;

                if (sportViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(sportViewModel.LogoFile, "Sports");
                }

                SportEntity sportEntity = _converterHelper.ToSportEntity(sportViewModel, path, false);
                _context.Update(sportEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists the sport: {sportEntity.Name}");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(sportViewModel);
        }

        // GET: Sports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SportEntity sportEntity = await _context.Sports.FirstOrDefaultAsync(m => m.Id == id);
            if (sportEntity == null)
            {
                return NotFound();
            }

            _context.Sports.Remove(sportEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
