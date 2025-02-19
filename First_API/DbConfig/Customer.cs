﻿using System;
using System.Collections.Generic;

namespace First_API.DbConfig;

public partial class Customer
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber1 { get; set; } = null!;

    public string PhoneNumber2 { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Deleted { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<CustomerRoleMapping> CustomerRoleMappings { get; set; } = new List<CustomerRoleMapping>();
}
