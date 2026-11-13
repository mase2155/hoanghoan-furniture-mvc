using System;
using System.Collections.Generic;

namespace hoanghoan_furniture_devmaster.Models.DBModel;

public partial class ContentBlock
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? KeyName { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }

    public byte? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? Isdelete { get; set; }
}
