namespace PersonalTrainer.Models
{
    public class Treino
    {
        public int Id { get; set; }
        public int PersonalId { get; set; }

        public int AlunoId { get; set; }

        public string? Data { get; set; }

        public string? Hora { get; set; }

        public virtual Personal? Personal { get; set; }

        public virtual Aluno? Aluno { get; set; }
    }
}
