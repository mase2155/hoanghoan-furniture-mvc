using System;
using System.Collections.Generic;

namespace hoanghoan_furniture_devmaster.Models.DBModel;

public partial class SiteSetting
{
    public int Id { get; set; }

    public string? SettingKey { get; set; }

    public string? SettingValue { get; set; }

    public string? Description { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
