using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabajo_VentaEntradas.BaseDato;
using Trabajo_VentaEntradas.Models;

namespace Trabajo_VentaEntradas.Controllers
{
    public class ShowController : Controller
    {
        private readonly EntradasDbContext _context;

        public ShowController(EntradasDbContext context)
        {
            _context = context;
        }

        // GET: Show
        public async Task<IActionResult> Index()
        {
            ViewBag.listaLocalidades = _context.Localidad.ToArray();
            return View(await _context.Show.ToListAsync());
        }

        // GET: Show/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .FirstOrDefaultAsync(m => m.id == id);
            if (show == null)
            {
                return NotFound();
            }
            //show.idLocalidad
            var nombreLocalidad =  await _context.Localidad.FirstOrDefaultAsync(m => m.id == show.idLocalidad); //Where(m => m.id == show.idLocalidad);
            ViewBag.nombre = nombreLocalidad.nombre;
            return View(show);
        }

        // GET: Show/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Show/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,fecha,banda,precioCampo,precioPlatea,asientosPlatea,asientosCampo,idLocalidad")] Show show)
        {
            if (ModelState.IsValid)
            {
                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(show);
        }

        // GET: Show/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            return View(show);
        }

        // POST: Show/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,fecha,banda,precioCampo,precioPlatea,asientosPlatea,asientosCampo,idLocalidad")] Show show)
        {
            if (id != show.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.id))
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
            return View(show);
        }

        // GET: Show/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .FirstOrDefaultAsync(m => m.id == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Show/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Show.FindAsync(id);
            _context.Show.Remove(show);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Show.Any(e => e.id == id);
        }

        public IActionResult Comprar()
        {
            ViewBag.listaShows = _context.Show.Where(m => m.asientosCampo > 0 || m.asientosPlatea > 0).ToArray();
            
            ViewBag.listaLocalidades = _context.Localidad.ToArray();

            return View();
        }

        [HttpGet]
        public IActionResult ConfirmarCompra(int id)
        {
            var show =  _context.Show
               .FirstOrDefault(m => m.id == id);

            ViewModels.ConfirmarCompraVM modelo = new ViewModels.ConfirmarCompraVM();

            modelo.idShow = show.id;
            modelo.fecha = show.fecha;
            modelo.banda = show.banda;
            modelo.precioCampo = show.precioCampo;
            modelo.precioPlatea = show.precioPlatea;
            modelo.idLocalidad = show.idLocalidad;
            modelo.localidad = _context.Localidad
                .FirstOrDefault(l => l.id == modelo.idLocalidad).nombre;

            return View(modelo);
        }

        [HttpPost]
        public IActionResult ConfirmarCompra(string seccion)
        {


            return RedirectToAction(nameof(ClienteController.Home), "Cliente");
        }


    }
}
