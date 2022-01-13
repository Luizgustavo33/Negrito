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
    public class AgendamentoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgendamentoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Agendamentoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Agendamento.Include(a => a.Paciente).Include(a => a.Profissional);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Agendamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamento
                .Include(a => a.Paciente)
                .Include(a => a.Profissional)
                .FirstOrDefaultAsync(m => m.IDAgendamento == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // GET: Agendamentoes/Create
        public IActionResult Create()
        {
            ViewData["Nome_Paciente"] = new SelectList(_context.Paciente, "IDPaciente", "Nome");
            ViewData["Nome_Profissional"] = new SelectList(_context.Profissional, "IDProfissional", "Nome");
            return View();
        }

        // POST: Agendamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDAgendamento,Periodo,Data,Nome_Paciente,Nome_Profissional")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agendamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Nome_Paciente"] = new SelectList(_context.Paciente, "IDPaciente", "Nome", agendamento.Nome_Paciente);
            ViewData["Nome_Profissional"] = new SelectList(_context.Profissional, "IDProfissional", "Nome", agendamento.Nome_Profissional);
            return View(agendamento);
        }

        // GET: Agendamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamento.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            ViewData["Nome_Paciente"] = new SelectList(_context.Paciente, "IDPaciente", "Nome", agendamento.Nome_Paciente);
            ViewData["Nome_Profissional"] = new SelectList(_context.Profissional, "IDProfissional", "Nome", agendamento.Nome_Profissional);
            return View(agendamento);
        }

        // POST: Agendamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDAgendamento,Periodo,Data,Nome_Paciente,Nome_Profissional")] Agendamento agendamento)
        {
            if (id != agendamento.IDAgendamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoExists(agendamento.IDAgendamento))
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
            ViewData["Nome_Paciente"] = new SelectList(_context.Paciente, "IDPaciente", "Nome", agendamento.Nome_Paciente);
            ViewData["Nome_Profissional"] = new SelectList(_context.Profissional, "IDProfissional", "Nome", agendamento.Nome_Profissional);
            return View(agendamento);
        }

        // GET: Agendamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamento
                .Include(a => a.Paciente)
                .Include(a => a.Profissional)
                .FirstOrDefaultAsync(m => m.IDAgendamento == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // POST: Agendamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agendamento = await _context.Agendamento.FindAsync(id);
            _context.Agendamento.Remove(agendamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoExists(int id)
        {
            return _context.Agendamento.Any(e => e.IDAgendamento == id);
        }
    }
}
