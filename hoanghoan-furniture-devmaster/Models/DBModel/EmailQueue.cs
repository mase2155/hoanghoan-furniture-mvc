using System;
using System.Collections.Generic;

namespace hoanghoan_furniture_devmaster.Models.DBModel;

public partial class EmailQueue
{
    public int Id { get; set; }

    public string? ToEmail { get; set; }

    public string? Subject { get; set; }

    public string? Body { get; set; }

    public byte? Status { get; set; }

    public int? RetryCount { get; set; }

    public string? ErrorMsg { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? SentDate { get; set; }
}
