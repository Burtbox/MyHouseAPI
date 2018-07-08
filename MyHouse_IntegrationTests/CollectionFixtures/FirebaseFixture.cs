using System;
using System.Threading.Tasks;
using MyHouseIntegrationTests.Helpers;
using MyHouseIntegrationTests.Shared;
using Xunit;

public class FirebaseFixture : IAsyncLifetime
{
    public string H1UserId { get; private set; }
    public string H1DisplayName { get; private set; }
    public string H1Token { get; private set; }
    public int H1OccupantId { get; private set; }
    public string H1Email { get; private set; }

    public string H2UserId { get; private set; }
    public string H2DisplayName { get; private set; }
    public string H2Token { get; private set; }
    public int H2OccupantId { get; private set; }
    public string H2Email { get; private set; }

    public string H3UserId { get; private set; }
    public string H3DisplayName { get; private set; }
    public string H3Token { get; private set; }
    public int H3OccupantId { get; private set; }
    public string H3Email { get; private set; }

    public FirebaseFixture()
    {
        TestSettings settings = TestSettingsHelper.TestSettings;

        this.H1UserId = settings.H1UserId;
        this.H1DisplayName = settings.H1DisplayName;
        this.H1OccupantId = settings.H1OccupantId;
        this.H1Email = settings.H1Email;

        this.H2UserId = settings.H2UserId;
        this.H2DisplayName = settings.H2DisplayName;
        this.H2OccupantId = settings.H2OccupantId;
        this.H2Email = settings.H2Email;

        this.H3UserId = settings.H3UserId;
        this.H3DisplayName = settings.H3DisplayName;
        this.H3OccupantId = settings.H3OccupantId;
        this.H3Email = settings.H3Email;
    }

    public async Task InitializeAsync()
    {
        TestSettings settings = TestSettingsHelper.TestSettings;
        TokenHelper tokenHelper = new TokenHelper();
        var tokens = await Task.WhenAll(
            tokenHelper.GenerateTokenAsync(settings.H1UserId),
            tokenHelper.GenerateTokenAsync(settings.H2UserId),
            tokenHelper.GenerateTokenAsync(settings.H3UserId)
        );

        this.H1Token = tokens[0];
        this.H2Token = tokens[1];
        this.H3Token = tokens[2];
    }

    public Task DisposeAsync()
    {
        throw new NotImplementedException();
    }
}
