using System.Linq;
using System.Numerics;
using Xunit;

public class DiffieHellmanTest
{
    [Fact]
    public void Private_key_in_range()
    {
        var primeP = new BigInteger(23);
        var privateKeys = Enumerable.Range(0, 10).Select(_ => DiffieHellman.PrivateKey(primeP)).ToList();
        Assert.All(privateKeys, privateKey => 
        {
            Assert.InRange(privateKey, new BigInteger(1), primeP - new BigInteger(1));
        });
    }

    // Note: due to the nature of randomness, there is always a chance that this test fails
    // Be sure to check the actual generated values
    [Fact]
    public void Private_key_randomly_generated()
    {
        var primeP = new BigInteger(7919);
        var privateKeys = Enumerable.Range(0, 5).Select(_ => DiffieHellman.PrivateKey(primeP)).ToList();
        Assert.Equal(privateKeys.Distinct().Count(), privateKeys.Count);
    }

    [Fact]
    public void Public_key_correctly_calculated()
    {
        var primeP = new BigInteger(23);
        var primeG = new BigInteger(5);
        var privateKey = new BigInteger(6);

        var actual = DiffieHellman.PublicKey(primeP, primeG, privateKey);
        Assert.Equal(new BigInteger(8), actual);
    }

    [Fact]
    public void Secret_key_correctly_calculated()
    {
        var primeP = new BigInteger(23);
        var publicKey = new BigInteger(19);
        var privateKey = new BigInteger(6);

        var actual = DiffieHellman.Secret(primeP, publicKey, privateKey);
        Assert.Equal(new BigInteger(2), actual);
    }

    [Fact]
    public void Secret_key_correctly_calculated_when_using_large_primes()
    {
        var primeP = BigInteger.Parse("120227323036150778550155526710966921740030662694578947298423549235265759593711587341037426347114541533006628856300552706996143592240453345642869233562886752930249953227657883929905072620233073626594386072962776144691433658814261874113232461749035425712805067202910389407991986070558964461330091797026762932543");
        var publicKey = BigInteger.Parse("75205441154357919442925546169208711235485855904969178206313309299205868312399046149367516336607966149689640419216591714331722664409474612463910928128055994157922930443733535659848264364106037925315974095321112757711756912144137705613776063541350548911512715512539186192176020596861210448363099541947258202188");
        var privateKey = BigInteger.Parse("2483479393625932939911081304356888505153797135447327501792696199190469015215177630758617902200417377685436170904594686456961202706692908603181062371925882");
        var expected = BigInteger.Parse("70900735223964890815905879227737819348808518698920446491346508980461201746567735331455825644429877946556431095820785835497384849778344216981228226252639932672153547963980483673419756271345828771971984887453014488572245819864454136618980914729839523581263886740821363010486083940557620831348661126601106717071");
        var actual = DiffieHellman.Secret(primeP, publicKey, privateKey);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_exchange()
    {
        var primeP = new BigInteger(23);
        var primeG = new BigInteger(5);

        var privateKeyA = DiffieHellman.PrivateKey(primeP);
        var privateKeyB = DiffieHellman.PrivateKey(primeP);

        var publicKeyA = DiffieHellman.PublicKey(primeP, primeG, privateKeyA);
        var publicKeyB = DiffieHellman.PublicKey(primeP, primeG, privateKeyB);

        var secretA = DiffieHellman.Secret(primeP, publicKeyB, privateKeyA);
        var secretB = DiffieHellman.Secret(primeP, publicKeyA, privateKeyB);

        Assert.Equal(secretB, secretA);
    }
}
