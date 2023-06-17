using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArmutProjesi.Data;
using EntityLayer;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using System.Configuration;

namespace ArmutProjesi.Controllers
{
    public class KategorisController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly KategoriManager _KategoriManager;

        public KategorisController(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
            this._KategoriManager = new KategoriManager(new EFKategoriRepository(this._databaseContext));
        }

        // GET: Kategoris
        public async Task<IActionResult> Index()
        {
              return _databaseContext.Kategoriler != null ? 
                          View(await _databaseContext.Kategoriler.ToListAsync()) :
                          Problem("Entity set 'ArmutProjesiContext.Kategori'  is null.");
        }

        // GET: Kategoris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _databaseContext.Kategoriler == null)
            {
                return NotFound();
            }

            var kategori = await _databaseContext.Kategoriler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        // GET: Kategoris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategoris/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _databaseContext.Add(kategori);
                await _databaseContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }

        // GET: Kategoris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _databaseContext.Kategoriler == null)
            {
                return NotFound();
            }

            var kategori = await _databaseContext.Kategoriler.FindAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }

        // POST: Kategoris/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KategoriAdi")] Kategori kategori)
        {
            if (id != kategori.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _databaseContext.Update(kategori);
                    await _databaseContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriExists(kategori.Id))
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
            return View(kategori);
        }

        // GET: Kategoris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _databaseContext.Kategoriler == null)
            {
                return NotFound();
            }

            var kategori = await _databaseContext.Kategoriler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        // POST: Kategoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_databaseContext.Kategoriler == null)
            {
                return Problem("Entity set 'ArmutProjesiContext.Kategori'  is null.");
            }
            var kategori = await _databaseContext.Kategoriler.FindAsync(id);
            if (kategori != null)
            {
                _databaseContext.Kategoriler.Remove(kategori);
            }
            
            await _databaseContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriExists(int id)
        {
          return (_databaseContext.Kategoriler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
