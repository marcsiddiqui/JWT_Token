using System;
using System.Collections.Generic;

namespace First_API.DbConfig;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }
}
