using System;
using System.Collections.Generic;

namespace Divar.Dbs;

public partial class AdvertisementImage
{
    public int Id { get; set; }

    public byte[]? Image { get; set; }

    public string? Url { get; set; }

    public string Status { get; set; } = null!;

    public DateTime InsertDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public int AdvertisementId { get; set; }

    public virtual Advertisement Advertisement { get; set; } = null!;
}
