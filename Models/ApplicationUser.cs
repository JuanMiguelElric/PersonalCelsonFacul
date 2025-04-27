using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalTrainer.Models
{
    [Table("AspNetUsers")]  // Usar aspas duplas, não simples
    public class ApplicationUser : IdentityUser
    {
        // Você pode adicionar propriedades adicionais, se necessário
    }
}
