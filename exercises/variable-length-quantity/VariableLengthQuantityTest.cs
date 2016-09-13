using NUnit.Framework;

public class VariableLengthQuantityTest
{
    [Test]
    public void To_single_byte()
    {
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x00u }), Is.EqualTo(new[] { 0x00u }));
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x40u }), Is.EqualTo(new[] { 0x40u }));
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x7fu }), Is.EqualTo(new[] { 0x7fu }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void To_double_byte()
    {
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x80u }),   Is.EqualTo(new[] { 0x81u, 0x00u }));
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x2000u }), Is.EqualTo(new[] { 0xc0u, 0x00u }));
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x3fffu }), Is.EqualTo(new[] { 0xffu, 0x7fu }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void To_triple_byte()
    {
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x4000u }),   Is.EqualTo(new[] { 0x81u, 0x80u, 0x00u }));
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x100000u }), Is.EqualTo(new[] { 0xc0u, 0x80u, 0x00u }));
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x1fffffu }), Is.EqualTo(new[] { 0xffu, 0xffu, 0x7fu }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void To_quadruple_byte()
    {
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x200000u }),   Is.EqualTo(new[] { 0x81u, 0x80u, 0x80u, 0x00u }));
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x08000000u }), Is.EqualTo(new[] { 0xc0u, 0x80u, 0x80u, 0x00u }));
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x0fffffffu }), Is.EqualTo(new[] { 0xffu, 0xffu, 0xffu, 0x7fu }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void To_quintuple_byte()
    {
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x10000000u }), Is.EqualTo(new[] { 0x81u, 0x80u, 0x80u, 0x80u, 0x00u }));
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0xff000000u }), Is.EqualTo(new[] { 0x8fu, 0xf8u, 0x80u, 0x80u, 0x00u }));
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0xffffffffu }), Is.EqualTo(new[] { 0x8fu, 0xffu, 0xffu, 0xffu, 0x7fu }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void From_bytes()
    {
        Assert.That(VariableLengthQuantity.FromBytes(new[] { 0x7fu }),                             Is.EqualTo(new[] { 0x7fu }));
        Assert.That(VariableLengthQuantity.FromBytes(new[] { 0xc0u, 0x00u }),                      Is.EqualTo(new[] { 0x2000u }));
        Assert.That(VariableLengthQuantity.FromBytes(new[] { 0xffu, 0xffu, 0x7fu }),               Is.EqualTo(new[] { 0x1fffffu }));
        Assert.That(VariableLengthQuantity.FromBytes(new[] { 0x81u, 0x80u, 0x80u, 0x00u }),        Is.EqualTo(new[] { 0x200000u }));
        Assert.That(VariableLengthQuantity.FromBytes(new[] { 0x8fu, 0xffu, 0xffu, 0xffu, 0x7fu }), Is.EqualTo(new[] { 0xffffffffu }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void To_bytes_multiple_values()
    {
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x40u, 0x7fu }), Is.EqualTo(new[] { 0x40u, 0x7fu }));
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x4000u, 0x123456u }), Is.EqualTo(new[] { 0x81u, 0x80u, 0x00u, 0xc8u, 0xe8u, 0x56u }));
        Assert.That(VariableLengthQuantity.ToBytes(new[] { 0x2000u, 0x123456u, 0x0fffffffu, 0x00u, 0x3fffu, 0x4000u }),
            Is.EqualTo(new[] { 0xc0u, 0x00u, 0xc8u, 0xe8u, 0x56u, 0xffu, 0xffu, 0xffu, 0x7fu, 0x00u, 0xffu, 0x7fu, 0x81u, 0x80u, 0x00u }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void From_bytes_multiple_values()
    {
        Assert.That(VariableLengthQuantity.FromBytes(new[] { 0xc0u, 0x00u, 0xc8u, 0xe8u, 0x56u, 0xffu, 0xffu, 0xffu, 0x7fu, 0x00u, 0xffu, 0x7fu, 0x81u, 0x80u, 0x00u }), 
            Is.EqualTo(new[] { 0x2000u, 0x123456u, 0x0fffffffu, 0x00u, 0x3fffu, 0x4000u }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Incomplete_byte_sequence()
    {
        Assert.That(() => VariableLengthQuantity.FromBytes(new[] { 0xffu }), Throws.Exception);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Overflow()
    {
        Assert.That(() => VariableLengthQuantity.FromBytes(new[] { 0xffu, 0xffu, 0xffu, 0xffu, 0x7fu }), Throws.Exception);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Chained_execution_is_identity()
    {
        var test = new[] { 0xf2u, 0xf6u, 0x96u, 0x9cu, 0x3bu, 0x39u, 0x2eu, 0x30u, 0xb3u, 0x24u };
        Assert.That(VariableLengthQuantity.FromBytes(VariableLengthQuantity.ToBytes(test)), Is.EquivalentTo(test));
    }
}