using System;
using System.Collections.Generic;

namespace PRN221_LeNam_BookStore.Models;

public partial class AccountHe161914
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public int Role { get; set; }

    public int? Phone { get; set; }

    public string? Address { get; set; }

    public string? Avatar { get; set; }

    public virtual ICollection<OrderHe161914> OrderHe161914s { get; set; } = new List<OrderHe161914>();
}
