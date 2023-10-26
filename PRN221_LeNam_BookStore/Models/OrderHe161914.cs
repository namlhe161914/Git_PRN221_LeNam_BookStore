using System;
using System.Collections.Generic;

namespace PRN221_LeNam_BookStore.Models;

public partial class OrderHe161914
{
    public string Oid { get; set; } = null!;

    public int Aid { get; set; }

    public DateTime Date { get; set; }

    public double Total { get; set; }

    public virtual AccountHe161914 AidNavigation { get; set; } = null!;
}
