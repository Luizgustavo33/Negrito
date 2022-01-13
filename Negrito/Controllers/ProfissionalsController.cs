using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Negrito.Data;
using Negrito.Models;

namespace Negrito.Controllers
{
    public class ProfissionalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfissionalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Profissionals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Profissional.Include(p => p.Especialidade);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Profissionals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissional = await _context.Profissional
                .Include(p => p.Especialidade)
                .FirstOrDefaultAsync(m => m.IDProfissional == id);
            if (profissional == null)
            {
                return NotFound();
            }

            return View(profissional);
        }

        // GET: Profissionals/Create
        public IActionResult Create()
        {
            ViewData["Especialidades"] = new SelectList(_context.Especialidade, "IDEspecialidade", "Especialidad");
            return View();
        }

        // POST: Profissionals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDProfissional,Nome,genero,Email,CPF,RG,Endereço,Bairro,Cidade,Estado,Data_Nascimento_Pro,Telefone,Registro,Especialidades")] Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Especialidades"] = new SelectList(_context.Especialidade, "IDEspecialidade", "Especialidad", profissional.Especialidades);
            return View(profissional);
        }

        // GET: Profissionals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissional = await _context.Profissional.FindAsync(id);
            if (profissional == null)
            {
                return NotFound();
            }
            ViewData["Especialidades"] = new SelectList(_context.Especialidade, "IDEspecialidade", "Especialidad", profissional.Especialidades);
            return View(profissional);
        }

        // POST: Profissionals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDProfissional,Nome,genero,Email,CPF,RG,Endereço,Bairro,Cidade,Estado,Data_Nascimento_Pro,Telefone,Registro,Especialidades")] Profissional profissional)
        {
            if (id != profissional.IDProfissional)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissionalExists(profissional.IDProfissional))
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
            ViewData["Especialidades"] = new SelectList(_context.Especialidade, "IDEspecialidade", "Especialidad", profissional.Especialidades);
            return View(profissional);
        }

        // GET: Profissionals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissional = await _context.Profissional
                .Include(p => p.Especialidade)
                .FirstOrDefaultAsync(m => m.IDProfissional == id);
            if (profissional == null)
            {
                return NotFound();
            }

            return View(profissional);
        }

        // POST: Profissionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profissional = await _context.Profissional.FindAsync(id);
            _context.Profissional.Remove(profissional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissionalExists(int id)
        {
            return _context.Profissional.Any(e => e.IDProfissional == id);
        }
    }
}
