﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Context;
using PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Models;

namespace PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Controllers
{
    public class PropiedadVentaController : Controller
    {
        private readonly InmobiliariaDatabaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PropiedadVentaController(InmobiliariaDatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: PropiedadVenta
        public async Task<IActionResult> Index()
        {
            return View(await _context.PropiedadVenta.ToListAsync());
        }

        // GET: PropiedadVenta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propiedadVenta = await _context.PropiedadVenta
                .FirstOrDefaultAsync(m => m.IdPropiedad == id);
            if (propiedadVenta == null)
            {
                return NotFound();
            }

            return View(propiedadVenta);
        }

        // GET: PropiedadVenta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropiedadVenta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPropiedad,Descripcion,Precio,SrcImagen,Tipo")] PropiedadVenta propiedadVenta)
        {
            if (ModelState.IsValid)
            {
                if (propiedadVenta.FotoPropiedad != null)
                {
                    string folder = "images/prop_venta/";
                    folder += Guid.NewGuid().ToString() + "_" + propiedadVenta.FotoPropiedad.FileName;

                    propiedadVenta.FotoPropiedadUrl = "/" + folder;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await propiedadVenta.FotoPropiedad.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                _context.Add(propiedadVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propiedadVenta);
        }

        // GET: PropiedadVenta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propiedadVenta = await _context.PropiedadVenta.FindAsync(id);
            if (propiedadVenta == null)
            {
                return NotFound();
            }
            return View(propiedadVenta);
        }

        // POST: PropiedadVenta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPropiedad,Descripcion,Precio,SrcImagen,Tipo")] PropiedadVenta propiedadVenta)
        {
            if (id != propiedadVenta.IdPropiedad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propiedadVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropiedadVentaExists(propiedadVenta.IdPropiedad))
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
            return View(propiedadVenta);
        }

        // GET: PropiedadVenta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propiedadVenta = await _context.PropiedadVenta
                .FirstOrDefaultAsync(m => m.IdPropiedad == id);
            if (propiedadVenta == null)
            {
                return NotFound();
            }

            return View(propiedadVenta);
        }

        // POST: PropiedadVenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propiedadVenta = await _context.PropiedadVenta.FindAsync(id);
            _context.PropiedadVenta.Remove(propiedadVenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropiedadVentaExists(int id)
        {
            return _context.PropiedadVenta.Any(e => e.IdPropiedad == id);
        }
    }
}
