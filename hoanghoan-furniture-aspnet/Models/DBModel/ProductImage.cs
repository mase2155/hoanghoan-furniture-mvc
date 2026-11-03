using System;
using System.Collections.Generic;

namespace hoanghoan_furniture_aspnet.Models.DBModel;

public partial class ProductImage
{
    public int Id { get; set; }

    public int? Pid { get; set; }

    public string? Image { get; set; }
}
