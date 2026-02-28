using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace WebApplicationAPP.Models
{
    public enum UserType
    {
        Estudiante,
        Profesor
    }

    public class User
    {
        public int IdUser { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public UserType Type { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public User() { }

        public User(int id, string name, UserType type, string email)
        {
            IdUser = id;
            Name = name;
            Type = type;
            Email = email;
        }
    }
}