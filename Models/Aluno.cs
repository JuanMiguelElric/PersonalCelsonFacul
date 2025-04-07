using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalTrainer.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public string? Data_Nascimento { get; set; }

        public string? email { get; set; }

        public string? instagram { get; set; }

        public string? telefone { get; set; }

        public string? observacoes { get; set; }

        public int personalId { get; set; }

        [ForeignKey("personalId")]
        public virtual Personal? Personal { get; set; }

        public virtual ICollection<Treino> Treinos { get; set; } = new List<Treino>();


    }
}
