using System;
using System.Collections.Generic;

namespace hoanghoan_furniture_devmaster.Models.DBModel;

public partial class AuditLog
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Action { get; set; }

    public string? TableName { get; set; }

    public int? RecordId { get; set; }

    public string? Description { get; set; }

    public string? IpAddress { get; set; }

    public DateTime? CreatedDate { get; set; }
}
