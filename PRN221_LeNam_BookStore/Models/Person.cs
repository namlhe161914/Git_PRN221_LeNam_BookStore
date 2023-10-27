using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRN221_LeNam_BookStore.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string? Fullname { get; set; }

    public string? Gender { get; set; }
    [Required(ErrorMessage = "Email require")]
    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? Type { get; set; }

    public bool? IsActive { get; set; }
}
