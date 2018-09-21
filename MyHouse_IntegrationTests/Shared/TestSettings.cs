using System.Collections.Generic;

namespace MyHouseIntegrationTests.Shared
{
    public class TestSettings
    {
        public string BaseUrl { get; set; }
        public string NodeJsExe { get; set; }

        public string H1UserId { get; set; }
        public string H1DisplayName { get; set; }
        public int H1OccupantId { get; set; }
        public string H1Email { get; set; }

        public string H2UserId { get; set; }
        public string H2DisplayName { get; set; }
        public int H2OccupantId { get; set; }
        public string H2Email { get; set; }

        public string H3UserId { get; set; }
        public string H3DisplayName { get; set; }
        public int H3OccupantId { get; set; }
        public string H3Email { get; set; }

        public string FirebaseAdminConsolePath { get; set; }
    }
}
