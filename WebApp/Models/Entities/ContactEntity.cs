using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Entities;

[Table("contacts")]
public class ContactEntity
{
    public int Id { get; set; }
    [MaxLength(50)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(50)]
    [Required]
    
    public string LastName { get; set; }
    public string Email { get; set; }
    [MaxLength(12)]
    [MinLength(9)]
    public string PhoneNumber {  get; set; }
    [Column("birth_date")]
    public DateOnly BirthDate { get; set; }
    
    public Category Category { get; set; }
}