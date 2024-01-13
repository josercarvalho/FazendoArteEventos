using Evento.Domain.Entity;
using Evento.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.UI.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Contexto _context;

        public ClientesController(Contexto context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        #region Dados do Cliente

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Cliente cliente)
        public JsonResult Create([FromBody] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cliente.DataCadastro = DateTime.Now;
                    _context.Add(cliente);
                    _context.SaveChanges();
                    var retorno = cliente.ClienteId;
                    return Json(retorno);
                }
            }
            catch (Exception)
            {
                return Json(new { Success = false, Message = "Erro ao salvar registro!" });
            }

            return Json(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nome,CPF,DataNascimento,Sexo,Profissao,Telefone,Celular,Email,Escolaridade,Filhos,DataCadastro,Logradouro,Bairro,CEP,Complemento,Referencia")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public JsonResult DeleteCliente(int id)
        {
            var mensagemErro = "Excluído com sucesso...";
            try
            {
                var cliente = _context.Cliente.FirstOrDefault(m => m.ClienteId == id);
                if (cliente == null)
                {
                    mensagemErro = "Erro ao tentar excluir o registro!";
                }
                _context.Cliente.Remove(cliente);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return Json(mensagemErro);
        }
        
        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.ClienteId == id);
        }

        #endregion

        #region Dados do Dependente

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dependentes(int id, Dependente dependente)
        {
            var dependentes = await _context.Dependente.Where(x => x.ClienteId.Equals(id)).ToListAsync();
            return PartialView("_Dependentes", dependente);
        }

        #endregion
    }
}
