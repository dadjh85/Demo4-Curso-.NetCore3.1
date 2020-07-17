using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.DtoModels
{
    public class DtoUserGet
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "el campo es requerido")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
