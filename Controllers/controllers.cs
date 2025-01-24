using Crud_Colegio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Crud_Colegio.Controllers
{
    public class controllers : Controller
    {
        private readonly Context _context;

        public controllers(Context context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuario.Include(u => u.Documentos).Include(u => u.Roles).ToListAsync();
            return View(usuarios);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Documentos)
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(m => m.Id_User == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["Id_Doc"] = new SelectList(_context.Documentos, "Id_Doc", "Nombre_Doc");
            ViewData["Id_Rol"] = new SelectList(_context.Roles, "Id_Rol", "Nombre_Rol");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Id_User,Id_Rol,Id_Doc,Nombre_User,Edad_User,NumDoc_User,Date_User,Email_User,NumTel_User")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"Key: {error.Key}, Error: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}");
                }
            }
            ViewData["Id_Doc"] = new SelectList(_context.Documentos, "Id_Doc", "Nombre_Doc", usuario.Id_Doc);
            ViewData["Id_Rol"] = new SelectList(_context.Roles, "Id_Rol", "Nombre_Rol", usuario.Id_Rol);
            return View(usuario);
        }


        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["Id_Doc"] = new SelectList(_context.Documentos, "Id_Doc", "Nombre_Doc", usuario.Id_Doc);
            ViewData["Id_Rol"] = new SelectList(_context.Roles, "Id_Rol", "Nombre_Rol", usuario.Id_Rol);
            return View(usuario);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_User,Id_Rol,Id_Doc,Nombre_User,Edad_User,NumDoc_User,Date_User,Email_User,NumTel_User")] Usuario usuario)
        {
            if (id != usuario.Id_User)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id_User))
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
            ViewData["Id_Doc"] = new SelectList(_context.Documentos, "Id_Doc", "Nombre_Doc", usuario.Id_Doc);
            ViewData["Id_Rol"] = new SelectList(_context.Roles, "Id_Rol", "Nombre_Rol", usuario.Id_Rol);
            return View(usuario);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Documentos)
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(m => m.Id_User == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id_User == id);
        }
    }
}

