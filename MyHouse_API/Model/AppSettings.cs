using System;

namespace MyHouseAPI.Model
{
    public class AppSettings
    {
        public FirebaseSettings Firebase { get; set; }
    }

    public class FirebaseSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}