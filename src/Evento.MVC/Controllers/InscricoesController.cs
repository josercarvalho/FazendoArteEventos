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
    public class InscricoesController : Controller
    {
        private readonly Contexto _context;

        public InscricoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Inscricoes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Inscricao.Include(i => i.Clientes).Include(i => i.Eventos);
            return View(await contexto.ToListAsync());
        }

        // GET: Inscricoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricao
                .Include(i => i.Clientes)
                .Include(i => i.Eventos)
                .FirstOrDefaultAsync(m => m.InscricaoId == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // GET: Inscricoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Cliente");
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Evento");
            return View();
        }

        // POST: Inscricoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscricaoId,FicouSabendo,Socio,Matricula,Valor,Periodo,ValorPago,Status,EventoId,ClienteId")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Cliente", inscricao.ClienteId);
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Evento", inscricao.EventoId);
            return View(inscricao);
        }

        // GET: Inscricoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricao.FindAsync(id);
            if (inscricao == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Cliente", inscricao.ClienteId);
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Evento", inscricao.EventoId);
            return View(inscricao);
        }

        // POST: Inscricoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InscricaoId,FicouSabendo,Socio,Matricula,Valor,Periodo,ValorPago,Status,EventoId,ClienteId")] Inscricao inscricao)
        {
            if (id != inscricao.InscricaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscricao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscricaoExists(inscricao.InscricaoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Cliente", inscricao.ClienteId);
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Evento", inscricao.EventoId);
            return View(inscricao);
        }

        public JsonResult DeleteInscrito(int id)
        {
            var mensagemErro = "Excluído com sucesso...";
            try
            {
                var inscricao = _context.Inscricao
                .Include(i => i.Clientes)
                .Include(i => i.Eventos)
                .FirstOrDefault(m => m.InscricaoId == id);
                if (inscricao == null)
                {
                    mensagemErro = "Erro ao tentar excluir o registro!";
                }
                _context.Inscricao.Remove(inscricao);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return Json(mensagemErro);
        }
        
        private bool InscricaoExists(int id)
        {
            return _context.Inscricao.Any(e => e.InscricaoId == id);
        }
    }
}
