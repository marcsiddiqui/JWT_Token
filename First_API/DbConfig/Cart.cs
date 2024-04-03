using System;
using System.Collections.Generic;

namespace First_API.DbConfig;

public partial class Cart
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int CustomerId { get; set; }
}
