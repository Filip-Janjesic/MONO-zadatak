using System;
using System.Collections.Generic;

namespace Mono.Models;

public partial class VehicleModel
{
    public int Id { get; set; }

    public int? MakeId { get; set; }

    public string? Name { get; set; }

    public string? Abrv { get; set; }

    public virtual VehicleMake? Make { get; set; }
}
