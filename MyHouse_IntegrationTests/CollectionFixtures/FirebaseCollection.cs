using Xunit;
using Xunit.FixtureInjection;

[CollectionDefinition("Firebase Collection")]
public class FirebaseCollectionWithInjectionSupportDefinition : ICollectionFixture<FirebaseFixtureWithInjectionSupport>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
