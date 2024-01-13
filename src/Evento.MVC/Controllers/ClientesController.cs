using Evento.Domain.Entity;
using Evento.Infra.Data;
using Evento.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.MVC.Controllers
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
            var contexto = _context.Cliente;
            return View(await contexto.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FirstOrDefaultAsync(m => m.ClienteId == id);
            //.Include(c => c.Cidade)
            //.Include(c => c.Estado)

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            //ViewData["CidadeId"] = new SelectList(_context.Cidades.Where(c=>c.EstadoId.Equals(10)), "CidadeId", "Nome");
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nome");
            return View("Create");
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nome,CPF,DataNascimento,Sexo,Profissao,Telefone,Celular,Email,Escolaridade,Filhos,Logradouro,Bairro,CEP,Complemento,Referencia,CidadeId,EstadoId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.DataCadastro = DateTime.Now;
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", new { id = cliente.ClienteId }); // RedirectToAction(nameof(Index));
            }
            //ViewData["CidadeId"] = new SelectList(_context.Cidades, "CidadeId", "Nome", cliente.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nome", cliente.EstadoId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.Include(c => c.Dependentes).FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidades.Where(c => c.EstadoId.Equals(cliente.EstadoId)), "CidadeId", "Nome", cliente.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nome", cliente.EstadoId);
            ViewBag.ClienteId = cliente.ClienteId;

            var dependentes = cliente.Dependentes;
            var clienteVM = new ClienteViewModel
            {
                Cliente = cliente,
                Dependentes = dependentes.ToList<Dependente>()
            };

            return View(clienteVM);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nome,CPF,DataNascimento,Sexo,Profissao,Telefone,Celular,Email,Escolaridade,Filhos,Logradouro,Bairro,CEP,Complemento,Referencia,CidadeId,EstadoId")] Cliente cliente)
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
            ViewData["CidadeId"] = new SelectList(_context.Cidades.Where(c => c.EstadoId.Equals(cliente.EstadoId)), "CidadeId", "Nome", cliente.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nome", cliente.EstadoId);
            return View(cliente);
        }

        //CadastrarDependente
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Cadastrar(Dependente dependente)
        public async Task<IActionResult> Cadastrar(Dependente dependente)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Dependentes", dependente);
            }

            try
            {
                if (dependente.DependenteId <= 0)
                {
                    _context.Add(dependente);
                }
                else
                {
                    _context.Update(dependente);
                }
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
            
            List<Dependente> retorno = await _context.Dependente.Where(d => d.ClienteId.Equals(dependente.ClienteId)).ToListAsync();

            return PartialView("_TableView", retorno);
        }

        public async Task<IActionResult> Editar(int id)
        {
            try
            {
                var retorno = await _context.Dependente.FindAsync(id);
                var dependenteVM = new DependentesViewModel
                {
                    DependenteId = retorno.DependenteId,
                    ClienteId = retorno.ClienteId,
                    Nome = retorno.Nome,
                    DataNascimento = retorno.DataNascimento,
                    Parente = retorno.Parente,
                    Idade = retorno.Idade,
                    Escola = retorno.Escola,
                    PlanoSaude = retorno.PlanoSaude,
                    GrupoSanguineo = retorno.GrupoSanguineo,
                    EmergenciaHospital = retorno.EmergenciaHospital,
                    Medico = retorno.Medico,
                    FoneMedico = retorno.FoneMedico,
                    RestricaoMedicamento = retorno.RestricaoMedicamento,
                    QualAlimento = retorno.QualAlimento,
                    RestricaoAlimentar = retorno.RestricaoAlimentar,
                    QualMedicamento = retorno.QualMedicamento,
                    PiscinaRestricao = retorno.PiscinaRestricao,
                    AutorizaPasseio = retorno.AutorizaPasseio,
                    Observacao = retorno.Observacao
                };
                return PartialView("_Dependentes", dependenteVM);
                //return Json(dependente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> Listar(int id)
        {
            var retorno = await _context.Dependente.Where(d => d.ClienteId.Equals(id)).ToListAsync();
            //return PartialView("_IndexDepend", retorno);
            return Json(retorno);
        }

        public JsonResult DeleteCliente(int id)
        {
            var mensagemErro = "Excluído com sucesso...";
            try
            {
                var cliente = _context.Cliente.Find(id);
                if (cliente == null)
                {
                    mensagemErro = "Erro ao tentar excluir o registro!";
                }
                var dependentes = _context.Dependente.Where(x => x.ClienteId.Equals(id));
                if (dependentes.Count() > 0)
                {
                    _context.Dependente.RemoveRange(dependentes);
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

        public JsonResult DeleteDependente(int id)
        {
            var mensagemErro = "Excluído com sucesso...";
            try
            {
                var dependente = _context.Dependente.FirstOrDefault(m => m.DependenteId == id);
                if (dependente == null)
                {
                    mensagemErro = "Erro ao tentar excluir o registro!";
                }
                _context.Dependente.Remove(dependente);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return Json(mensagemErro);
        }
        
        [HttpGet]
        public JsonResult GetCityList(int id)
        {
            var cidadeList = GetCidades(id);

            var citylist = cidadeList.Select(m => new SelectListItem
            {
                Text = m.Nome,
                Value = m.CidadeId.ToString(CultureInfo.InvariantCulture),
            });

            return Json(citylist);
        }

        private IEnumerable<Cidade> GetCidades(int id)
        {
            return _context.Cidades.Where(c => c.EstadoId.Equals(id)).ToList();
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.ClienteId == id);
        }

        private bool DependenteExists(int id)
        {
            return _context.Dependente.Any(e => e.DependenteId == id);
        }
    }
}
