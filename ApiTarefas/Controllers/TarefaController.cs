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

    [HttpGet("id")]
    public async Task<IActionResult> ListarPorId(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa == null)
        {
            return NotFound();
        }
        return Ok(tarefa);
    }

    [HttpDelete("id")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if(tarefa == null)
            {
                return NotFound();
            }
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return Ok();

        }catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut("id")]
    public async Task<IActionResult> Update(Tarefa tarefa)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var tarefaEditar = await _context.Tarefas.FindAsync(tarefa.Id);
                tarefaEditar.Status = tarefa.Status;
                tarefaEditar.Descricao = tarefa.Descricao;
                tarefaEditar.Prazo = tarefa.Prazo;
                tarefaEditar.Prioridade = tarefa.Prioridade;
                tarefaEditar.Finalizado = tarefa.Finalizado;
                tarefaEditar.Responsavel = tarefa.Responsavel;
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("Dados incorretos!");
            }
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}

