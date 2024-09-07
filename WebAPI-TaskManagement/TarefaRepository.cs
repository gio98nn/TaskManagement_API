using System.Security.Cryptography.X509Certificates;

namespace WebAPI_TaskManagement
{
    public class TarefaRepository
    {
        private readonly List<Tarefa> _tarefas;

        public TarefaRepository()
        {
            _tarefas = new List<Tarefa>();
        }
        public IEnumerable<Tarefa> GetAll()
        {
            return _tarefas;
        }
        public Tarefa GetById(int id)
        {
            return _tarefas.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Tarefa tarefa)
        {
            _tarefas.Add(tarefa);
        }

        public void Update(Tarefa tarefa)
        {
            var existingTarefa = GetById(tarefa.Id);
            if (existingTarefa != null)
            {
                existingTarefa.Titulo = tarefa.Titulo;
                existingTarefa.Descricao = tarefa.Descricao;
                existingTarefa.Status = tarefa.Status;
                existingTarefa.DateOfCreation = tarefa.DateOfCreation;
            }
        }

        public void Delete(int id)
        {
            var tarefa = GetById(id);
            if (tarefa != null)
            {
                _tarefas.Remove(tarefa);
            }
        }

    }
}
