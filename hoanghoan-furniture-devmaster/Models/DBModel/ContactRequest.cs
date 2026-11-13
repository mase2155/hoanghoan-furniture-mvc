using System;
using System.Collections.Generic;

namespace hoanghoan_furniture_devmaster.Models.DBModel;

public partial class ContactRequest
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public byte? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? Isdelete { get; set; }
}
