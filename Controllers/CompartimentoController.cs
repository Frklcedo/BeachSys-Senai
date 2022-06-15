using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeachSys.Models;

namespace BeachSys.Controllers
{
    public class CompartimentoController : Controller
    {
        private readonly BeachSysContext _context;

        public CompartimentoController(BeachSysContext context)
        {
            _context = context;
        }

        // GET: Compartimento
        public async Task<IActionResult> Index()
        {
            var beachSysContext = _context.Compartimento.Include(c => c.Armario).Include(c => c.Usuario);
            return View(await beachSysContext.ToListAsync());
        }

        // GET: Compartimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compartimento = await _context.Compartimento
                .Include(c => c.Armario)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CompartimentoId == id);
            if (compartimento == null)
            {
                return NotFound();
            }

            return View(compartimento);
        }

        // GET: Compartimento/Create
        public IActionResult Create()
        {
            ViewData["ArmarioId"] = new SelectList(_context.Armario, "ArmarioId", "Nome");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Cpf");
            return View();
        }

        // POST: Compartimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompartimentoId,numero,Altura,Largura,IsDisponivel,ArmarioId,UsuarioId")] Compartimento compartimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compartimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArmarioId"] = new SelectList(_context.Armario, "ArmarioId", "Nome", compartimento.ArmarioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Cpf", compartimento.UsuarioId);
            return View(compartimento);
        }

        // GET: Compartimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compartimento = await _context.Compartimento.FindAsync(id);
            if (compartimento == null)
            {
                return NotFound();
            }
            ViewData["ArmarioId"] = new SelectList(_context.Armario, "ArmarioId", "Nome", compartimento.ArmarioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Cpf", compartimento.UsuarioId);
            return View(compartimento);
        }

        // POST: Compartimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompartimentoId,numero,Altura,Largura,IsDisponivel,ArmarioId,UsuarioId")] Compartimento compartimento)
        {
            if (id != compartimento.CompartimentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compartimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompartimentoExists(compartimento.CompartimentoId))
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
            ViewData["ArmarioId"] = new SelectList(_context.Armario, "ArmarioId", "Nome", compartimento.ArmarioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Cpf", compartimento.UsuarioId);
            return View(compartimento);
        }

        // GET: Compartimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compartimento = await _context.Compartimento
                .Include(c => c.Armario)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CompartimentoId == id);
            if (compartimento == null)
            {
                return NotFound();
            }

            return View(compartimento);
        }

        // POST: Compartimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compartimento = await _context.Compartimento.FindAsync(id);
            _context.Compartimento.Remove(compartimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompartimentoExists(int id)
        {
            return _context.Compartimento.Any(e => e.CompartimentoId == id);
        }
    }
}
