using System;
using MyHouseIntegrationTests.Helpers;
using MyHouseIntegrationTests.Shared;

public class FirebaseFixture : IDisposable
{
    public string H1UserId { get; private set; }
    public string H1DisplayName { get; private set; }
    public string H1Token { get; private set; }
    public int H1OccupantId { get; private set; }

    public string H2UserId { get; private set; }
    public string H2DisplayName { get; private set; }
    public string H2Token { get; private set; }
    public int H2OccupantId { get; private set; }

    public string H3UserId { get; private set; }
    public string H3DisplayName { get; private set; }
    public string H3Token { get; private set; }
    public int H3OccupantId { get; private set; }

    public FirebaseFixture()
    {
        TestSettings settings = TestSettingsHelper.TestSettings;
        this.H1UserId = settings.H1UserId;
        this.H1DisplayName = settings.H1DisplayName;
        this.H1Token = TokenHelper.GenerateToken(settings.H1UserId);
        this.H1OccupantId = settings.H1OccupantId;

        this.H2UserId = settings.H2UserId;
        this.H2DisplayName = settings.H2DisplayName;
        this.H2Token = TokenHelper.GenerateToken(settings.H2UserId);
        this.H2OccupantId = settings.H2OccupantId;

        this.H3UserId = settings.H3UserId;
        this.H3DisplayName = settings.H3DisplayName;
        this.H3Token = TokenHelper.GenerateToken(settings.H3UserId);
        this.H3OccupantId = settings.H3OccupantId;

        // ... initialize data in the test database ...
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...
    }
}
