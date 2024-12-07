using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS.Entity.Domain;

public class Report
{
    public Guid ReportId { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime GeneratedAt { get; set; }
    public string ReportData { get; set; } // JSON o altro formato
}

