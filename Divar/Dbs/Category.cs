using System;
using System.Collections.Generic;

namespace Divar.Dbs;

public partial class Category
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime InsertDate { get; set; }

    public byte[]? Icon { get; set; }

    public string Status { get; set; } = null!;

    public int? ParentId { get; set; }

    public virtual ICollection<Advertisement> Advertisements { get; set; } = new List<Advertisement>();
}
