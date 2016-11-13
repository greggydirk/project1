using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace project1.Models
{
   
    public class Pengguna
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Nama tidak boleh kosong")]
        public string Username { get; set; }
        [Required(ErrorMessage = "E-mail tidak boleh kosong")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password tidak boleh kosong")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password tidak cocok")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}