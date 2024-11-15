using System;
using System.Collections.Generic;

namespace Divar.Db;

public partial class AdvertisementImage
{
    public int Id { get; set; }

    public byte[] Image { get; set; } = null!;

    public string? Url { get; set; }

    public string Status { get; set; } = null!;

    public int AdvertisementId { get; set; }

    public virtual Advertisement Advertisement { get; set; } = null!;
}
