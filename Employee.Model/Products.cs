using Employee.Shared;
using Employee.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employee.Model;

public class Products : BaseAuditableEntity, IEntity    
{
    public int Id { get; set; }

    public string? ProductName { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;


    public int CountryId { get; set; }
    public Country? Country { get; set; }

    public double Rating {get ; set;}

    public double Price { get ; set;}

    public string BarCode { get; set; } = string.Empty;

    public double SellPrice { get; set; }

   


}
