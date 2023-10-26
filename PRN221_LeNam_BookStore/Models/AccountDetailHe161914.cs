using System;
using System.Collections.Generic;

namespace PRN221_LeNam_BookStore.Models;

public partial class AccountDetailHe161914
{
    public int Aid { get; set; }

    public string Name { get; set; } = null!;

    public string? Avatar { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual AccountHe161914 AidNavigation { get; set; } = null!;
}
