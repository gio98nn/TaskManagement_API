namespace WebAPI_TaskManagement
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public StatusTarefa Status {  get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
