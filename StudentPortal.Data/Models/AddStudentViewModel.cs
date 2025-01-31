using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    public class AddStudentViewModel
    {
        public Guid Id { get; set; }
        [Required]

        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public bool Subscribed { get; set; } 
    }



}
