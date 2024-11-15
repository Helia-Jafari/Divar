using System;
using System.Collections.Generic;

namespace Divar.Db;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime InsertDate { get; set; }

    public virtual ICollection<Advertisement> Advertisements { get; set; } = new List<Advertisement>();
}
