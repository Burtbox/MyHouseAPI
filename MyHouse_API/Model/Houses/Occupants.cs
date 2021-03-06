using System;

namespace MyHouseAPI.Model.Houses
{
    public abstract class OccupantDetails
    {
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public bool InviteAccepted { get; set; }
    }

    public abstract class Occupant : OccupantDetails
    {
        public int OccupantId { get; set; }
    }

    public class OccupantResponse : Occupant
    {

    }

    public class OccupantInsertRequest : OccupantDetails
    {
        public string EnteredBy { get; set; }
        public int InvitedByOccupantId { get; set; }
    }

    public class OccupantUpdateRequest : Occupant
    {

    }

    public class OccupantInviteRequest
    {
        public string Email { get; set; }
        public string InvitedByUserId { get; set; }
        public int InvitedByOccupantId { get; set; }
    }

    public class OccupantInviteRequestDetails { }

    public class OccupantInviteResponse
    {
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string Uid { get; set; }
        public string DisplayName { get; set; }
    }
}
