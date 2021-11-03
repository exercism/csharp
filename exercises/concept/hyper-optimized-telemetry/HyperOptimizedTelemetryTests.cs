using System;
using Xunit;
using Exercism.Tests;

public class HyperOptimizedTelemetryTests
{
    [Fact]
    [Task(1)]
    public void ToBuffer_upper_long()
    {
        var bytes = TelemetryBuffer.ToBuffer(Int64.MaxValue);
        Assert.Equal(new byte[] { 0xf8, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_long()
    {
        var bytes = TelemetryBuffer.ToBuffer((long)UInt32.MaxValue + 1);
        Assert.Equal(new byte[] { 0xf8, 0x0, 0x0, 0x0, 0x0, 0x1, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_uint()
    {
        var bytes = TelemetryBuffer.ToBuffer(UInt32.MaxValue);
        Assert.Equal(new byte[] { 0x4, 0xff, 0xff, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_uint()
    {
        var bytes = TelemetryBuffer.ToBuffer((long)Int32.MaxValue + 1);
        Assert.Equal(new byte[] { 0x4, 0x0, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_int()
    {
        var bytes = TelemetryBuffer.ToBuffer(Int32.MaxValue);
        Assert.Equal(new byte[] { 0xfc, 0xff, 0xff, 0xff, 0x7f, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_int()
    {
        var bytes = TelemetryBuffer.ToBuffer((long)UInt16.MaxValue + 1);
        Assert.Equal(new byte[] { 0xfc, 0x0, 0x0, 0x1, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_ushort()
    {
        var bytes = TelemetryBuffer.ToBuffer(UInt16.MaxValue);
        Assert.Equal(new byte[] { 0x2, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_ushort()
    {
        var bytes = TelemetryBuffer.ToBuffer((long)Int16.MaxValue + 1);
        Assert.Equal(new byte[] { 0x2, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_short()
    {
        var bytes = TelemetryBuffer.ToBuffer(Int16.MaxValue);
        Assert.Equal(new byte[] { 0x2, 0xff, 0x7f, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_Zero()
    {
        var bytes = TelemetryBuffer.ToBuffer(0);
        Assert.Equal(new byte[] { 0x2, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_neg_short()
    {
        var bytes = TelemetryBuffer.ToBuffer(-1);
        Assert.Equal(new byte[] { 0xfe, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_neg_short()
    {
        var bytes = TelemetryBuffer.ToBuffer(Int16.MinValue);
        Assert.Equal(new byte[] { 0xfe, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_neg_int()
    {
        int n = Int16.MinValue - 1;
        var bytes = TelemetryBuffer.ToBuffer(n);
        Assert.Equal(new byte[] { 0xfc, 0xff, 0x7f, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_neg_int()
    {
        var bytes = TelemetryBuffer.ToBuffer(Int32.MinValue);
        Assert.Equal(new byte[] { 0xfc, 0x0, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_neg_long()
    {
        var bytes = TelemetryBuffer.ToBuffer((long)Int32.MinValue - 1);
        Assert.Equal(new byte[] { 0xf8, 0xff, 0xff, 0xff, 0x7f, 0xff, 0xff, 0xff, 0xff }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_neg_long()
    {
        var bytes = TelemetryBuffer.ToBuffer(Int64.MinValue);
        Assert.Equal(new byte[] { 0xf8, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x80 }, bytes);
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_Invalid()
    {
        Assert.Equal(0,
            TelemetryBuffer.FromBuffer(new byte[] { 22, 0xff, 0xff, 0xff, 0x7f, 0, 0, 0, 0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_long()
    {
        Assert.Equal(Int64.MaxValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0xf8, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_long()
    {
        Assert.Equal((long)UInt32.MaxValue + 1,
            TelemetryBuffer.FromBuffer(new byte[] { 0xf8, 0x0, 0x0, 0x0, 0x0, 0x1, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_uint()
    {
        Assert.Equal(UInt32.MaxValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0x4, 0xff, 0xff, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_uint()
    {
        Assert.Equal((long)Int32.MaxValue + 1,
            TelemetryBuffer.FromBuffer(new byte[] { 0x4, 0x0, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_int()
    {
        Assert.Equal(Int32.MaxValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfc, 0xff, 0xff, 0xff, 0x7f, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_int()
    {
        Assert.Equal(UInt16.MaxValue + 1,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfc, 0x0, 0x0, 0x1, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_ushort()
    {
        Assert.Equal(UInt16.MaxValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0x2, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_ushort()
    {
        Assert.Equal(Int16.MaxValue + 1,
            TelemetryBuffer.FromBuffer(new byte[] { 0x2, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_short()
    {
        Assert.Equal(Int16.MaxValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfe, 0xff, 0x7f, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_Zero()
    {
        Assert.Equal(0,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfe, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_neg_short()
    {
        Assert.Equal(-1,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfe, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_neg_short()
    {
        Assert.Equal(Int16.MinValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfe, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_neg_int()
    {
        Assert.Equal(Int16.MinValue - 1,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfc, 0xff, 0x7f, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_neg_int()
    {
        Assert.Equal(Int32.MinValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfc, 0x0, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_neg_long()
    {
        Assert.Equal((long)Int32.MinValue - 1,
            TelemetryBuffer.FromBuffer(new byte[] { 0xf8, 0xff, 0xff, 0xff, 0x7f, 0xff, 0xff, 0xff, 0xff }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_neg_long()
    {
        Assert.Equal(Int64.MinValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0xf8, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x80 }));
    }
}