using Xunit.FixtureInjection;

public class FirebaseFixtureWithInjectionSupport : ICreateClassFixtures
{
    FirebaseFixture ICreateClassFixtures.CreateClassFixture<FirebaseFixture>()
    {
        return null; //TODO: This is probably wrong but wtf is it???
    }
}