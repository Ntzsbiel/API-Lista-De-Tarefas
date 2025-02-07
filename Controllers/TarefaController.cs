using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id); //Buscar o Id no banco utilizando o EF

            if (tarefa == null)
            { // Valida o tipo de retorno. Se não encontrar a tarefa, retornar NotFound,
                return NotFound();
            }
            else
            {
                return Ok(tarefa);  // caso contrário retornar OK com a tarefa encontrada
            }

        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var tarefa = _context.Tarefas;
            // TODO: Buscar todas as tarefas no banco utilizando o EF
            return Ok(tarefa);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)  //  Busca as tarefas no banco utilizando o EF, que contenha o titulo recebido por parâmetro
        {
            var tarefa = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));
            return Ok(tarefa);
        }


        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefa = _context.Tarefas.Where(x => x.Data.Date == data.Date);
            return Ok(tarefa);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status) //Busca as tarefas no banco utilizando o EF, que contenha o status recebido por parâmetro
        {
            var tarefa = _context.Tarefas.Where(x => x.Status == status);
            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            _context.Add(tarefa);
            _context.SaveChanges(); //  Adiciona a tarefa recebida no EF e salva as mudanças    
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);  //Atualiza as informações da variável tarefaBanco com a tarefa recebida via parâmetro

            if (tarefaBanco == null)
                return NotFound();

            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco); //  Atualiza a variável tarefaBanco no EF e salva as mudanças 
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();

            // Remove a tarefa encontrada através do EF e salvar as mudanças 
            return NoContent();
        }
    }
}
