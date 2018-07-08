using System;
using Microsoft.AspNetCore.NodeServices;
using Serilog;
using Xunit.FixtureInjection;

public class FirebaseFixtureWithInjectionSupport : ICreateClassFixtures
{
    TFirebaseFixture ICreateClassFixtures.CreateClassFixture<TFirebaseFixture>()
    {
        var nodeServices = services.GetRequiredService<INodeServices>();
        var logger = services.GetRequiredService<ILogger>();
        if (typeof(TFirebaseFixture) != typeof(FirebaseFixture))
            throw new ArgumentException($"Stub Collection Fixture is not intended to create class fixtures of type {typeof(TFirebaseFixture)}");

        return (TFirebaseFixture)(object)new FirebaseFixture(nodeServices, logger);
    }
}