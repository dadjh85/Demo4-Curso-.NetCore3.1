using System.ComponentModel.DataAnnotations;

namespace Service.DtoModels
{
    public class DtoUserAdd
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "el campo es requerido")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
