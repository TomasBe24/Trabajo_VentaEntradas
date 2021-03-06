using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabajo_VentaEntradas.BaseDato;
using Trabajo_VentaEntradas.Models;

namespace Trabajo_VentaEntradas.Controllers
{
    [Authorize]
    public class ShowController : Controller
    {
        private readonly EntradasDbContext _context;

        public ShowController(EntradasDbContext context)
        {
            _context = context;
        }

        // GET: Show
        [Authorize(Roles = nameof(Rol.Administrador))]
        public async Task<IActionResult> Index()
        {
            ViewBag.listaLocalidades = _context.Localidad.ToArray();
            ViewBag.listaBandas = _context.Banda.ToArray();
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
            var nombreLocalidad = await _context.Localidad.FirstOrDefaultAsync(m => m.id == show.idLocalidad); //Where(m => m.id == show.idLocalidad);
            ViewBag.nombre = nombreLocalidad.nombre;

            var nombreBanda = await _context.Banda.FirstOrDefaultAsync(m => m.id == show.banda); //Where(m => m.id == show.idLocalidad);
            ViewBag.nombreBanda = nombreBanda.nombre;


            return View(show);
        }

        // GET: Show/Create
        [Authorize(Roles = nameof(Rol.Administrador))]
        public IActionResult Create()
        {
            List<Localidad> lst = _context.Localidad.ToList();

            List<SelectListItem> items = lst.ConvertAll(m =>
            {
                return new SelectListItem()
                {
                    Text = m.nombre.ToString(),
                    Value = m.id.ToString(),
                    Selected = false //aca esta el tuco
                };
            });

            ViewBag.Items = items;

            List<Banda> lstBanda = _context.Banda.ToList();

            List<SelectListItem> itemsBanda = lstBanda.ConvertAll(m =>
            {
                return new SelectListItem()
                {
                    Text = m.nombre.ToString(),
                    Value = m.id.ToString(),
                    Selected = false //aca esta el tuco
                };
            });

            ViewBag.ItemsBanda = itemsBanda;


            return View();
        }

        // POST: Show/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = nameof(Rol.Administrador))]
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

            List<Localidad> lst = _context.Localidad.ToList();

            List<SelectListItem> items = lst.ConvertAll(m =>
            {
                return new SelectListItem()
                {
                    Text = m.nombre.ToString(),
                    Value = m.id.ToString(),
                    Selected = false //aca esta el tuco
                };
            });

            int i = 0;
            bool encontre = false;
            while (i < items.Count && !encontre)
            {
                if (items[i].Value == show.idLocalidad.ToString())
                {
                    items[i].Selected = true;
                    encontre = true;
                }
                else
                {
                    i++;
                }
            }


            ViewBag.Items = items;


            List<Banda> lstBanda = _context.Banda.ToList();

            List<SelectListItem> itemsBanda = lstBanda.ConvertAll(m =>
            {
                return new SelectListItem()
                {
                    Text = m.nombre.ToString(),
                    Value = m.id.ToString(),
                    Selected = false //aca esta el tuco
                };
            });

            int j = 0;
            bool encontre1 = false;
            while (j < itemsBanda.Count && !encontre1)
            {
                if (itemsBanda[j].Value == show.banda.ToString())
                {
                    itemsBanda[j].Selected = true;
                    encontre1 = true;
                }
                else
                {
                    j++;
                }
            }


            ViewBag.ItemsBanda = itemsBanda;





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

        public async Task<IActionResult> Comprar(int id)
        {
            ViewBag.listaShows = _context.Show.Where(m => (m.asientosCampo > 0 || m.asientosPlatea > 0)  && m.banda == id/*&& m.fecha > DateTime.Now*/).ToArray();

            ViewBag.listaLocalidades = _context.Localidad.ToArray();

            
            var banda = _context.Banda.Find(id);
            ViewBag.banda = banda.nombre;

            return View();
        }

        [HttpGet]
        public IActionResult ConfirmarCompra(int id)
        {
            var show = _context.Show
               .FirstOrDefault(m => m.id == id);

            ViewModels.ConfirmarCompraVM modelo = new ViewModels.ConfirmarCompraVM();

            modelo.idShow = show.id;
            modelo.fecha = show.fecha;
            modelo.banda = _context.Banda.FirstOrDefault(m => m.id == show.banda).nombre;
            modelo.asientosCampo = show.asientosCampo;
            modelo.asientosPlatea = show.asientosPlatea;
            modelo.precioCampo = show.precioCampo;
            modelo.precioPlatea = show.precioPlatea;
            modelo.idLocalidad = show.idLocalidad;
            modelo.localidad = _context.Localidad
                .FirstOrDefault(l => l.id == modelo.idLocalidad).nombre;

            return View(modelo);
        }

        //[HttpPost]
        //public async Task<IActionResult> ConfirmarCompra(string banda, DateTime fecha, int idShow, int seccion)
        //{
        //    int precio;
        //    string seccionFinal;
        //    Show show = await _context.Show.FirstOrDefaultAsync(s => s.id == idShow);

        //    if (seccion == 1)
        //    {
        //        precio = show.precioCampo;
        //        seccionFinal = "Campo";
        //    }
        //    else
        //    {
        //        precio = show.precioPlatea;
        //        seccionFinal = "Platea";
        //    }

        //    Entrada entrada = null;

            
        //        _context.Entrada.Add(entrada);
        //        await _context.Entrada.SaveChangesAsync();
        //        return RedirectToAction(nameof(ClienteController.Home), "Cliente");
            


        //    //return RedirectToAction("Create", "Entrada", entrada);

           
        //}

        public int prueba()
        {
            return 2;
        }


    }
}
