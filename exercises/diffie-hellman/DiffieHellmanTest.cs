// This file was auto-generated based on version 1.0.0 of the canonical data.

using System.Linq;
using System.Numerics;
using Xunit;

public class DiffieHellmanTest
{
    [Fact]
    public void Private_key_is_in_range_1_p()
    {
        var p = new BigInteger(7919);
        var privateKeys = Enumerable.Range(0, 10).Select(_ => DiffieHellman.PrivateKey(p)).ToArray();
        foreach (var privateKey in privateKeys)
        {
            Assert.InRange(privateKey, new BigInteger(1), p);
        }
    }

    [Fact(Skip = "Remove to run test")]
    public void Private_key_is_random()
    {
        var p = new BigInteger(7919);
        var privateKeys = Enumerable.Range(0, 10).Select(_ => DiffieHellman.PrivateKey(p)).ToArray();
        Assert.Equal(privateKeys.Distinct().Count(), privateKeys.Length);
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_calculate_public_key_using_private_key()
    {
        var p = new BigInteger(23);
        var g = new BigInteger(5);
        var privateKey = new BigInteger(6);
        Assert.Equal(new BigInteger(8), DiffieHellman.PublicKey(p, g, privateKey));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_calculate_secret_using_other_partys_public_key()
    {
        var p = new BigInteger(23);
        var theirPublicKey = new BigInteger(19);
        var myPrivateKey = new BigInteger(6);
        Assert.Equal(new BigInteger(2), DiffieHellman.Secret(p, theirPublicKey, myPrivateKey));
    }

    [Fact(Skip = "Remove to run test")]
    public void Key_exchange()
    {
        var p = new BigInteger(23);
        var g = new BigInteger(5);
        var alicePrivateKey = DiffieHellman.PrivateKey(p);
        var bobPrivateKey = DiffieHellman.PrivateKey(p);
        var alicePublicKey = DiffieHellman.PublicKey(p, g, alicePrivateKey);
        var bobPublicKey = DiffieHellman.PublicKey(p, g, bobPrivateKey);
        var secretA = DiffieHellman.Secret(p, bobPublicKey, alicePrivateKey);
        var secretB = DiffieHellman.Secret(p, alicePublicKey, bobPrivateKey);
        Assert.Equal(secretA, secretB);
    }
}