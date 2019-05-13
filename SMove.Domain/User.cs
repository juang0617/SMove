namespace SMove.Domain
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es necesario.")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo puede contener un maximo de {1} caracteres.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo {0} es necesario.")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo puede contener un maximo de {1} caracteres.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario.")]
        [MaxLength(100, ErrorMessage = "El campo {0} solo puede contener un maximo de {1} caracteres.")]
        [Index("User_Email_Index", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} solo puede contener un maximo de {1} caracteres.")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Image")]
        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImagePath))
                {
                    return "noimage";
                }

                return string.Format(
                    "https://smoveapi.azurewebsites.net/{0}",
                    ImagePath.Substring(1));
            }
        }

        [Display(Name = "User")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }
    }
}
