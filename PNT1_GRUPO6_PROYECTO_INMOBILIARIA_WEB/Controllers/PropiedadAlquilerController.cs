using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Context;
using PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Models;


namespace PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Controllers
{
    public class PropiedadAlquilerController : Controller
    {
        private readonly InmobiliariaDatabaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PropiedadAlquilerController(InmobiliariaDatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: PropiedadAlquiler
        public async Task<IActionResult> Index()
        {
            return View(await _context.PropiedadAlquiler.Include(x=>x.usuario).ToListAsync());
        }

        // GET: PropiedadAlquiler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propiedadAlquiler = await _context.PropiedadAlquiler.Include(x => x.usuario)
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
        public async Task<IActionResult> Create([Bind("CantMeses,IdPropiedad,Descripcion,Precio,FotoPropiedad,Tipo")] PropiedadAlquiler propiedadAlquiler)
        {
            if (ModelState.IsValid)
            {
                if (propiedadAlquiler.FotoPropiedad != null)
                {
                    string folder = "images/prop_alquiler/";
                    folder += Guid.NewGuid().ToString() + "_" + propiedadAlquiler.FotoPropiedad.FileName;

                    propiedadAlquiler.FotoPropiedadUrl = "/" + folder;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await propiedadAlquiler.FotoPropiedad.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
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

            var propiedadAlquiler = await _context.PropiedadAlquiler.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("CantMeses,IdPropiedad,Descripcion,Precio,FotoPropiedad,Tipo")] PropiedadAlquiler propiedadAlquiler)
        {
            if (id != propiedadAlquiler.IdPropiedad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (propiedadAlquiler.FotoPropiedad != null)
                    {
                        string folder = "images/prop_alquiler/";
                        folder += Guid.NewGuid().ToString() + "_" + propiedadAlquiler.FotoPropiedad.FileName;

                        propiedadAlquiler.FotoPropiedadUrl = "/" + folder;

                        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                        await propiedadAlquiler.FotoPropiedad.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    }
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

            var propiedadAlquiler = await _context.PropiedadAlquiler
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
            var propiedadAlquiler = await _context.PropiedadAlquiler.FindAsync(id);
            _context.PropiedadAlquiler.Remove(propiedadAlquiler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropiedadAlquilerExists(int id)
        {
            return _context.PropiedadAlquiler.Any(e => e.IdPropiedad == id);
        }

        // GET: PropiedadAlquiler/Alquilar/5
        public async Task<IActionResult> Alquilar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ListaUsuarios = await _context.Usuarios.ToListAsync();

            var propiedadAlquiler = await _context.PropiedadAlquiler.FindAsync(id);
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
        public async Task<IActionResult> Alquilar(PropiedadVenta model)
        {
            PropiedadAlquiler propiedadAlquiler = _context.PropiedadAlquiler.SingleOrDefault(b => b.IdPropiedad == model.IdPropiedad);

            if (propiedadAlquiler == null)
            {
                return NotFound();
            }

            Usuario usuarioDB = _context.Usuarios.SingleOrDefault(b => b.IdUsuario == model.usuario.IdUsuario);

            if (usuarioDB == null)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    propiedadAlquiler.usuario = usuarioDB;
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

            return View("Details",propiedadAlquiler);
        }

    }
}
