using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaRoupa.Core;
using LojaRoupa.Persistency;
using LojaRoupa.Application;

namespace LojaRoupa.WEB.Controllers
{
    public class TamanhosController : Controller
    {
        private readonly TamanhoHandler handler;

        public TamanhosController(TamanhoHandler handler) => this.handler = handler;

        // GET: Tamanhos
        public async Task<IActionResult> Index()
        {
            return View(await handler.Listar(null));
        }

        // GET: Tamanhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue) return NotFound();
            var tamanho = await handler.ObterUm(id.Value, null);
            if (tamanho == null) return NotFound();
            return View(tamanho);
        }

        // GET: Tamanhos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tamanhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome")] Tamanho tamanho)
        {
            if (ModelState.IsValid)
            {
                await handler.Inserir(tamanho, null);
                return RedirectToAction(nameof(Index));
            }
            return View(tamanho);
        }

        // GET: Tamanhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var tamanho = await handler.ObterUm(id.Value, null);
            if (tamanho == null) return NotFound();
            return View(tamanho);
        }

        // POST: Tamanhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome")] Tamanho tamanho)
        {
            if (id != tamanho.ID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await handler.Alterar(id, tamanho, null);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (handler.ObterUm(id,null) != null) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tamanho);
        }

        // GET: Tamanhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tamanho = await handler.ObterUm(id.Value, null);
            if (tamanho == null) return NotFound();
            
            return View(tamanho);
        }

        // POST: Tamanhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tamanho = await handler.Remover(id, null);
            return RedirectToAction(nameof(Index));
        }
    }
}