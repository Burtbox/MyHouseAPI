using System;
using MyHouseIntegrationTests.Helpers;
using MyHouseIntegrationTests.Shared;

public class FirebaseFixture : IDisposable
{
    public FirebaseFixture()
    {
        TestSettings settings = TestSettingsHelper.TestSettings;
        this.H1UserId = settings.H1UserId;
        this.H1Token = TokenHelper.GenerateToken(settings.H1UserId);
        this.H2UserId = settings.H2UserId;
        this.H2Token = TokenHelper.GenerateToken(settings.H2UserId);

        // ... initialize data in the test database ...
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...
    }

    public string H1UserId { get; private set; }
    public string H1Token { get; private set; }
    public string H2UserId { get; private set; }
    public string H2Token { get; private set; }
}