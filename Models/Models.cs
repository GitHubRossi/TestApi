using System;
using System.ComponentModel.DataAnnotations;

namespace TestApi.Models;

public class BodyInput
{
    [Required]
    public decimal Input { get; set; }
}

public class DicVal
{
    [Required]
    public DateTime DateTime { get; set; }
    public double Value { get; set; }
}
public class ResultModel
{
    public double Computed_value { get; set; }
    public decimal Input_value { get; set; }
    public double Previous_value { get; set; }
}

public class ResultModelWithDateTime:ResultModel
{
    public DateTime DateTime { get; set; }
}


