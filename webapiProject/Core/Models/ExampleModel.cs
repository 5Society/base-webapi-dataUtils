using System.ComponentModel.DataAnnotations;

namespace webapiProject.Core.Models;

public class ExampleModel
{
    public int Id {get;set;}
    public DateTime DateExample  { get; set; }

    public int IntExample { get; set; }

    public int PropertyExample => IntExample + 1000;

    public string? StringExample { get; set; }
}

public class ExampleCreateModel
{
    public int IntExample { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Name cannot be less than 2")]
    [MaxLength(1000, ErrorMessage = "Name cannot be greater than 1000")]
    public string? StringExample { get; set; }
}

public class ExampleUpdateModel
{
    [Required]
    public int Id { get; set; }

    public int IntExample { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Name cannot be less than 2")]
    [MaxLength(1000, ErrorMessage = "Name cannot be greater than 1000")]
    public string? StringExample { get; set; }
}
