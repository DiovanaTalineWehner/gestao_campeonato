using System.ComponentModel.DataAnnotations;

namespace gestao_campeonato.Models;
public class LoginModel
{
    [Required(ErrorMessage = "User Name é obrigatório!")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Password é obrigatório!")]
    public string? Password { get; set; }
}   