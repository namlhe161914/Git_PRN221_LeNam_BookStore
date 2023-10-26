using System;
using System.Collections.Generic;

namespace PRN221_LeNam_BookStore.Models;

public partial class BookHe161914
{
    public int Bid { get; set; }

    public string Cid { get; set; } = null!;

    public string Bname { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? Image { get; set; }

    public string Pid { get; set; } = null!;

    public int? Quantity { get; set; }

    public string? Describe { get; set; }

    public double Price { get; set; }

    public virtual CategoryHe161914 CategoryHe161914 { get; set; } = null!;

    public virtual PublisherHe161914 PublisherHe161914 { get; set; } = null!;
}
