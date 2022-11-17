using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB;
using PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Context;

namespace PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Controllers
{
    public class PropiedadAlquilerController : Controller
    {
        private readonly InmobiliariaDatabaseContext _context;

        public PropiedadAlquilerController(InmobiliariaDatabaseContext context)
        {
            _context = context;
        }

        // GET: PropiedadAlquiler
        public async Task<IActionResult> Index()
        {
            return View(await _context.PropiedadVenta.ToListAsync());
        }

        // GET: PropiedadAlquiler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propiedadAlquiler = await _context.PropiedadVenta
                .FirstOrDefaultAsync(m => m.IdPropiedad == id);
            if (propiedadAlquiler == null)
            {
                return NotFound();
            }

            return View(propiedadAlquiler);
        }

        // GET: PropiedadAlquiler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropiedadAlquiler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CantMeses,IdPropiedad,Descripcion,Precio,SrcImagen,Tipo")] PropiedadAlquiler propiedadAlquiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propiedadAlquiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propiedadAlquiler);
        }

        // GET: PropiedadAlquiler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propiedadAlquiler = await _context.PropiedadVenta.FindAsync(id);
            if (propiedadAlquiler == null)
            {
                return NotFound();
            }
            return View(propiedadAlquiler);
        }

        // POST: PropiedadAlquiler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CantMeses,IdPropiedad,Descripcion,Precio,SrcImagen,Tipo")] PropiedadAlquiler propiedadAlquiler)
        {
            if (id != propiedadAlquiler.IdPropiedad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propiedadAlquiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropiedadAlquilerExists(propiedadAlquiler.IdPropiedad))
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
            return View(propiedadAlquiler);
        }

        // GET: PropiedadAlquiler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propiedadAlquiler = await _context.PropiedadVenta
                .FirstOrDefaultAsync(m => m.IdPropiedad == id);
            if (propiedadAlquiler == null)
            {
                return NotFound();
            }

            return View(propiedadAlquiler);
        }

        // POST: PropiedadAlquiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propiedadAlquiler = await _context.PropiedadVenta.FindAsync(id);
            _context.PropiedadVenta.Remove(propiedadAlquiler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropiedadAlquilerExists(int id)
        {
            return _context.PropiedadVenta.Any(e => e.IdPropiedad == id);
        }

        // GET: PropiedadAlquiler/Alquilar/5
        public async Task<IActionResult> Alquilar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propiedadAlquiler = await _context.PropiedadVenta.FindAsync(id);
            if (propiedadAlquiler == null)
            {
                return NotFound();
            }
            return View(propiedadAlquiler);
        }

        // POST: PropiedadAlquiler/Alquilar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alquilar(int id, [Bind("CantMeses,IdPropiedad,Descripcion,Precio,SrcImagen,Tipo")] PropiedadAlquiler propiedadAlquiler)
        {
            if (id != propiedadAlquiler.IdPropiedad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propiedadAlquiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropiedadAlquilerExists(propiedadAlquiler.IdPropiedad))
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
            return View(propiedadAlquiler);
        }

    }
}
