namespace PersonalTrainer.Models
{
    public class Personal
    {
        public  int Id { get; set; }
        public string? Nome { get; set; }

        public string? Especialidade { get; set; }


        public virtual ICollection<Aluno>  Alunos { get; set; } = new List<Aluno>();

        public virtual ICollection<Treino> Treinos { get; set; } = new List<Treino>();
    }
}
