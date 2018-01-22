using Xunit;

[CollectionDefinition("Firebase Collection")]
public class FirebaseCollection : ICollectionFixture<FirebaseFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
