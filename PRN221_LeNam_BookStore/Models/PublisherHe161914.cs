using System;
using System.Collections.Generic;

namespace PRN221_LeNam_BookStore.Models;

public partial class PublisherHe161914
{
    public string Pid { get; set; } = null!;

    public string Pname { get; set; } = null!;

    public virtual ICollection<BookHe161914> BookHe161914s { get; set; } = new List<BookHe161914>();
}
