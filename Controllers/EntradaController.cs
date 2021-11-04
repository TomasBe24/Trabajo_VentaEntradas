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
    public class EntradaController : Controller
    {
        private readonly EntradasDbContext _context;

        public EntradaController(EntradasDbContext context)
        {
            _context = context;
        }

        // GET: Entrada
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entrada.ToListAsync());
        }

        // GET: Entrada/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entrada
                .FirstOrDefaultAsync(m => m.id == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // GET: Entrada/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Entrada/Create                 [Bind("id,seccion,precio,asiento,fecha,dniUsuario,idShow")] 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entrada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index");
        }

        // GET: Entrada/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entrada.FindAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }
            return View(entrada);
        }

        // POST: Entrada/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,seccion,precio,asiento,fecha,dniUsuario,idShow")] Entrada entrada)
        {
            if (id != entrada.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaExists(entrada.id))
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
            return View(entrada);
        }

        // GET: Entrada/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entrada
                .FirstOrDefaultAsync(m => m.id == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // POST: Entrada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrada = await _context.Entrada.FindAsync(id);
            _context.Entrada.Remove(entrada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaExists(int id)
        {
            return _context.Entrada.Any(e => e.id == id);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarCompra(string banda, DateTime fecha, int idShow, int seccion, int Entrada)
        {
            int precioFinal;
            string seccionFinal;
            Show show = await _context.Show.FirstOrDefaultAsync(s => s.id == idShow);
            int asientoo = 0;

            //llamado a comprar

            for (int i = 0; i < Entrada; i++)
            {

                if (seccion == 1)
                {
                    precioFinal = show.precioCampo;
                    seccionFinal = "Campo";
                    asientoo = show.asientosCampo;
                    show.asientosCampo--;
                    _context.Show.Update(show);
                }
                else
                {
                    precioFinal = show.precioPlatea;
                    seccionFinal = "Platea";
                    asientoo = show.asientosPlatea;
                    show.asientosPlatea--;
                    _context.Show.Update(show);
                }

                Entrada entrada;
                entrada = new Entrada
                {
                    seccion = seccionFinal,
                    precio = precioFinal,
                    asiento = asientoo,
                    fecha = fecha,
                    dniUsuario = (User.FindFirstValue(ClaimTypes.NameIdentifier)),
                    idShow = idShow
                };


                _context.Add(entrada);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ClienteController.Home), "Cliente");


            //el for para que cree varias entradas al mismo tiempo

        }

    }
}
