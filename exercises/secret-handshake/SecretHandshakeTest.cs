﻿using Xunit;

public class SecretHandshakeTests
{
    [Fact]
    public void Test_1_handshake_to_wink()
    {
        Assert.That(SecretHandshake.Commands(1), Is.EqualTo(new[] { "wink" }));
    }

    [Fact(Skip="Remove to run test")]
    public void Test_10_handshake_to_double_blink()
    {
        Assert.That(SecretHandshake.Commands(2), Is.EqualTo(new[] { "double blink" }));
    }

    [Fact(Skip="Remove to run test")]
    public void Test_100_handshake_to_close_your_eyes()
    {
        Assert.That(SecretHandshake.Commands(4), Is.EqualTo(new[] { "close your eyes" }));
    }

    [Fact(Skip="Remove to run test")]
    public void Test_1000_handshake_to_close_your_eyes()
    {
        Assert.That(SecretHandshake.Commands(8), Is.EqualTo(new[] { "jump" }));
    }

    [Fact(Skip="Remove to run test")]
    public void Test_handshake_11_to_wink_and_double_blink()
    {
        Assert.That(SecretHandshake.Commands(3), Is.EqualTo(new[] { "wink", "double blink" }));
    }

    [Fact(Skip="Remove to run test")]
    public void Test_handshake_10011_to_double_blink_and_wink()
    {
        Assert.That(SecretHandshake.Commands(19), Is.EqualTo(new[] { "double blink", "wink" }));
    }

    [Fact(Skip="Remove to run test")]
    public void Test_handshake_11111_to_all_commands_reversed()
    {
        Assert.That(SecretHandshake.Commands(31), Is.EqualTo(new[] { "jump", "close your eyes", "double blink", "wink" }));
    }
}
