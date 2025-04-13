using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalTrainer.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public string? Data_Nascimento { get; set; }

        public string? Email { get; set; }

        public string? Instagram { get; set; }

        public string? Telefone { get; set; }

        public string? Observacoes { get; set; }

        public int PersonalId { get; set; }

        public int? Userid { get; set; }

        [ForeignKey("PersonalId")]
        public virtual Personal? Personal { get; set; }

        public virtual ICollection<Treino> Treinos { get; set; } = new List<Treino>();


    }
}
