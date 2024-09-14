using EFCore_library.Models;
using System;
using System.Collections.Generic;

namespace EFCore_library.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
