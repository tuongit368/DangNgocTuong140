using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DangNgocTuong140.Data;
using DangNgocTuong140.Models;

namespace DangNgocTuong140.Controllers
{
    public class LopHocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LopHocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LopHoc
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LopHoc.Include(l => l.HocSinh);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LopHoc/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHoc
                .Include(l => l.HocSinh)
                .FirstOrDefaultAsync(m => m.MaLopHoc == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }

        // GET: LopHoc/Create
        public IActionResult Create()
        {
            ViewData["MaHocSinh"] = new SelectList(_context.HocSinh, "MaHocSinh", "MaHocSinh");
            return View();
        }

        // POST: LopHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLopHoc,SoLopHoc,MaHocSinh")] LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHocSinh"] = new SelectList(_context.HocSinh, "MaHocSinh", "MaHocSinh", lopHoc.MaHocSinh);
            return View(lopHoc);
        }

        // GET: LopHoc/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHoc.FindAsync(id);
            if (lopHoc == null)
            {
                return NotFound();
            }
            ViewData["MaHocSinh"] = new SelectList(_context.HocSinh, "MaHocSinh", "MaHocSinh", lopHoc.MaHocSinh);
            return View(lopHoc);
        }

        // POST: LopHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaLopHoc,SoLopHoc,MaHocSinh")] LopHoc lopHoc)
        {
            if (id != lopHoc.MaLopHoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopHocExists(lopHoc.MaLopHoc))
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
            ViewData["MaHocSinh"] = new SelectList(_context.HocSinh, "MaHocSinh", "MaHocSinh", lopHoc.MaHocSinh);
            return View(lopHoc);
        }

        // GET: LopHoc/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHoc
                .Include(l => l.HocSinh)
                .FirstOrDefaultAsync(m => m.MaLopHoc == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }

        // POST: LopHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lopHoc = await _context.LopHoc.FindAsync(id);
            if (lopHoc != null)
            {
                _context.LopHoc.Remove(lopHoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopHocExists(string id)
        {
            return _context.LopHoc.Any(e => e.MaLopHoc == id);
        }
    }
}
