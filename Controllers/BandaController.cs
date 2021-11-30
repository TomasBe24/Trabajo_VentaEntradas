using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabajo_VentaEntradas.BaseDato;
using Trabajo_VentaEntradas.Models;

namespace Trabajo_VentaEntradas.Controllers
{
    public class BandaController : Controller
    {
        private readonly EntradasDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BandaController(EntradasDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Banda
        public async Task<IActionResult> Index()
        {
            return View(await _context.Banda.ToListAsync());
        }

        // GET: Banda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banda = await _context.Banda
                .FirstOrDefaultAsync(m => m.id == id);
            if (banda == null)
            {
                return NotFound();
            }

            return View(banda);
        }

        // GET: Banda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,Imagefile")] Banda banda)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(banda.Imagefile.FileName);
                string extension = Path.GetExtension(banda.Imagefile.FileName);
                banda.foto = fileName = fileName + extension;
                string path = Path.Combine(wwwRootPath + "/imagenes/bandas/", fileName);
                using(var fileStream = new FileStream(path, FileMode.Create))
                {
                    await banda.Imagefile.CopyToAsync(fileStream);
                }

                _context.Add(banda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banda);
        }

        // GET: Banda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banda = await _context.Banda.FindAsync(id);
            if (banda == null)
            {
                return NotFound();
            }
            return View(banda);
        }

        // POST: Banda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,Imagefile")] Banda banda)
        {
            if (id != banda.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (banda.Imagefile != null) {
                        //var fotoABorrar = await _context.Banda.FirstOrDefaultAsync(b => b.id == id);

                        //var rutaImagen = Path.Combine(_hostEnvironment.WebRootPath, "imagenes/bandas", fotoABorrar.foto);
                        //System.IO.File.Delete(rutaImagen);


                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(banda.Imagefile.FileName);
                        string extension = Path.GetExtension(banda.Imagefile.FileName);
                        banda.foto = fileName = fileName + extension;
                        string path = Path.Combine(wwwRootPath + "/imagenes/bandas/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await banda.Imagefile.CopyToAsync(fileStream);
                        }
                    }

                    _context.Update(banda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BandaExists(banda.id))
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
            return View(banda);
        }

        // GET: Banda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banda = await _context.Banda
                .FirstOrDefaultAsync(m => m.id == id);
            if (banda == null)
            {
                return NotFound();
            }

            return View(banda);
        }

        // POST: Banda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banda = await _context.Banda.FindAsync(id);

            var rutaImagen = Path.Combine(_hostEnvironment.WebRootPath, "imagenes/bandas", banda.foto);
            System.IO.File.Delete(rutaImagen);

            _context.Banda.Remove(banda);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BandaExists(int id)
        {
            return _context.Banda.Any(e => e.id == id);
        }

        public IActionResult Shows(int id)
        {
            ViewBag.Shows = _context.Show.Where(s => s.banda == id).ToArray();

            return View();
        }

        public async Task<IActionResult> Home()
        {
            return View(await _context.Banda.ToListAsync());
        }





    }
}
