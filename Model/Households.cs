using System.ComponentModel.DataAnnotations;

public class Household {
    //TODO add validation here!
    [Key]
    public string HouseholdId { get; set; }
    public string Name { get; set; }
}
