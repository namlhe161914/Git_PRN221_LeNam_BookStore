using System;
using System.Collections.Generic;

namespace PRN221_LeNam_BookStore.Models;

public partial class OrderDetailHe161914
{
    public string Oid { get; set; } = null!;

    public int Bid { get; set; }

    public int Quanity { get; set; }

    public virtual BookHe161914 BidNavigation { get; set; } = null!;

    public virtual OrderHe161914 OidNavigation { get; set; } = null!;
}
