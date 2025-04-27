using Microsoft.AspNetCore.Identity;

namespace PersonalTrainer.Role
{
    // Defina uma classe para o RoleSeeder
    public static class RoleSeeder
    {
        // Método assíncrono para criar roles, caso não existam
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Verifica se a role "Admin" já existe
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                // Se a role "Admin" não existir, cria a role
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Verifica se a role "User" já existe
            if (!await roleManager.RoleExistsAsync("User"))
            {
                // Se a role "User" não existir, cria a role
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
        }
    }
}
