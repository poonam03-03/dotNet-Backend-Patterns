using System;
using System.Collections.Generic;

namespace ProcedureCRUD.Models;

public partial class ClientMaster
{
    public int ClientId { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public long? ContactNo { get; set; }

    public string? Address { get; set; }

    public DateTime? AddedOn { get; set; }
}
