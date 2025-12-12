using ApiTarefas.Data;
using ApiTarefas.Tarefas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTarefas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefaController : Controller
{
    private readonly AppDbContext _context;
    public TarefaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(Tarefa tarefa)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                await _context.SaveChangesAsync();//Por usar o método assincrono ele espera salvar para prosseguir

                return Created();
            }
            else
            {
                return BadRequest("Dados incorretos!");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var tarefas = await _context.Tarefas.ToListAsync();
        if (tarefas == null)
        {
            return NotFound();
        }
        return Ok(tarefas);
    }
}

