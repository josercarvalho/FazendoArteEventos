using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evento.Domain.Entity;
using Evento.Infra.Data;

namespace Evento.MVC.Controllers
{
    public class DependentesController : Controller
    {
        private readonly Contexto _context;

        public DependentesController(Contexto context)
        {
            _context = context;
        }

        // GET: Dependentes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Dependente.Include(d => d.Cliente);
            return View(await contexto.ToListAsync());
        }

        // GET: Dependentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependente
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.DependenteId == id);
            if (dependente == null)
            {
                return NotFound();
            }

            return View(dependente);
        }

        // GET: Dependentes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Bairro");
            return View();
        }

        // POST: Dependentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DependenteId,Nome,DataNascimento,Parente,Idade,Escola,PlanoSaude,GrupoSanguineo,EmergenciaHospital,Medico,FoneMedico,RestricaoMedicamento,QualMedicamento,RestricaoAlimentar,QualAlimento,PiscinaRestricao,AutorizaPasseio,Observacao,ClienteId")] Dependente dependente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dependente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Bairro", dependente.ClienteId);
            return View(dependente);
        }

        // GET: Dependentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependente.FindAsync(id);
            if (dependente == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Bairro", dependente.ClienteId);
            return View(dependente);
        }

        // POST: Dependentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DependenteId,Nome,DataNascimento,Parente,Idade,Escola,PlanoSaude,GrupoSanguineo,EmergenciaHospital,Medico,FoneMedico,RestricaoMedicamento,QualMedicamento,RestricaoAlimentar,QualAlimento,PiscinaRestricao,AutorizaPasseio,Observacao,ClienteId")] Dependente dependente)
        {
            if (id != dependente.DependenteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dependente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependenteExists(dependente.DependenteId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Bairro", dependente.ClienteId);
            return View(dependente);
        }

        // GET: Dependentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependente
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.DependenteId == id);
            if (dependente == null)
            {
                return NotFound();
            }

            return View(dependente);
        }

        // POST: Dependentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dependente = await _context.Dependente.FindAsync(id);
            _context.Dependente.Remove(dependente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DependenteExists(int id)
        {
            return _context.Dependente.Any(e => e.DependenteId == id);
        }
    }
}
