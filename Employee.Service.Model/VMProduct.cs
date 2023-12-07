using Employee.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.Model;

public  class VMProduct :IVM
{
    public int Id { get; set; }
    public string? ProductName { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;


    public int CountryId { get; set; }
   

    public double Rating { get; set; }

    public double Price { get; set; }

    public string BarCode { get; set; } = string.Empty;

    public double SellPrice { get; set; }


}
