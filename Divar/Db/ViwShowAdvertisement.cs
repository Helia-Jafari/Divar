using System;
using System.Collections.Generic;

namespace Divar.Db;

public partial class ViwShowAdvertisement
{
    public byte[] Image { get; set; } = null!;

    public int? Id { get; set; }

    public int? FunctionKilometers { get; set; }

    public decimal? BasePrice { get; set; }

    public string? Title { get; set; }

    public DateTime? InsertDate { get; set; }
}
