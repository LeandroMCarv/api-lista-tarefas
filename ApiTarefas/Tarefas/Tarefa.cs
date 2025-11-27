namespace ApiTarefas.Tarefas
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? Prazo { get; set; }
        public string Prioridade { get; set; }
        public string Responsavel { get; set; }
        public bool Finalizado { get; set; } = false;
    }
}
