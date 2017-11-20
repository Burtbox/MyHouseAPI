using System;
using System.ComponentModel.DataAnnotations;

namespace HouseMoneyAPI.Model
{
    public class Household
    {
        public int HouseholdId { get; set; }
        public string Name { get; set; }
    }

    public class HouseholdInsert : Household
    {
        public string EnteredBy { get; set; }
    }

    public class HouseholdUpdate : Household
    {
        public DateTime ModifiedBy { get; set; }
    }
}
