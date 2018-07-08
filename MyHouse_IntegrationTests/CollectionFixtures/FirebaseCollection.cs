using Xunit;
using Xunit.FixtureInjection;

[CollectionDefinition(Name)]
public class FirebaseCollectionWithInjectionSupportDefinition : ICollectionFixture<FirebaseFixtureWithInjectionSupport>
{
    public const string Name = "FirebaseCollection";
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
