using System;
using System.Collections.Generic;

namespace Autobus1_Burlakov.Models;

public partial class Urlsdatum
{
    public int Id { get; set; }

    public string FullUrl { get; set; } = null!;

    public int PassageCounter { get; set; }

    public string ShortUrl { get; set; } = null!;

    public DateOnly CreationDate { get; set; }
}
