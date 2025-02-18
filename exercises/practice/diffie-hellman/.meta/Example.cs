using System;
using System.Numerics;

public static class DiffieHellman
{
    private static readonly Random Random = new Random();

    public static BigInteger PrivateKey(BigInteger primeP) => new BigInteger(Random.Next(1, (int) primeP - 1));

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey) => BigInteger.ModPow(primeG, privateKey, primeP);

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey) => BigInteger.ModPow(publicKey, privateKey, primeP);
}