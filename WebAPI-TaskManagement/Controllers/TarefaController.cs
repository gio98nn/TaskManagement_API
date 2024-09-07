using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI_TaskManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : Controller
    {
        private readonly TarefaRepository _repository;

        public TarefaController(TarefaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tarefa>> GetAll()
        {
            var tarefas = _repository.GetAll();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public ActionResult<Tarefa> GetById(int id)
        {
            var tarefa = _repository.GetById(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpPost]
        public ActionResult Create(Tarefa tarefa)
        {
            _repository.Add(tarefa);
            return CreatedAtAction(nameof(GetById), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{Id}")]
        public ActionResult Update(int id, Tarefa tarefa)
        {
            var existingTarefa = _repository.GetById(id);
            if(existingTarefa == null)
            {
                return NotFound();
            }

            _repository.Update(tarefa);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var tarefa = _repository.GetById(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }
}
