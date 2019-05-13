namespace SMove.Backend.Models
{
    using Domain;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
    public class UserView : User
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo {0} es necesario.")]
        [StringLength(20, ErrorMessage = "El campo {0} debe contener entre {1} y {2} caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo {0} es necesario.")]
        [Compare("Password", ErrorMessage = "La contraseña y su confirmación no coinciden")]
        [Display(Name = "Password confirm")]
        public string PasswordConfirm { get; set; }
    }
}