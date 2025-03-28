public class IntergalacticTransmissionTests
{

    [Fact]
    public void TransmitEmpty()
    {
        Assert.Equal([], IntergalacticTransmission.GetTransmitSequence([]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TransmitZeroByte()
    {
        Assert.Equal([0x00, 0x00], IntergalacticTransmission.GetTransmitSequence([0x00]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TransmitOneByteWithOneBit()
    {
        Assert.Equal([0x03, 0x00], IntergalacticTransmission.GetTransmitSequence([0x02]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TransmitOneByteWithTwoBits()
    {
        Assert.Equal([0x06, 0x00], IntergalacticTransmission.GetTransmitSequence([0x06]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TransmitOneByteSplitToOddParities()
    {
        Assert.Equal([0x05, 0x81], IntergalacticTransmission.GetTransmitSequence([0x05]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TransmitOneByteSplitToEvenAndOddParities()
    {
        Assert.Equal([0x28, 0x81], IntergalacticTransmission.GetTransmitSequence([0x29]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TransmitFourBytes()
    {
        Assert.Equal([0xC0, 0x00, 0x71, 0x1B, 0xE1], IntergalacticTransmission.GetTransmitSequence([0xC0, 0x01, 0xC0, 0xDE]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TransmitSixBytes()
    {
        Assert.Equal([0x47, 0xB8, 0x99, 0xAC, 0x17, 0xA0, 0x84], IntergalacticTransmission.GetTransmitSequence([0x47, 0x72, 0x65, 0x61, 0x74, 0x21]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TransmitSevenBytes()
    {
        Assert.Equal([0x47, 0xB8, 0x99, 0xAC, 0x17, 0xA0, 0xC5, 0x42], IntergalacticTransmission.GetTransmitSequence([0x47, 0x72, 0x65, 0x61, 0x74, 0x31, 0x21]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TransmitEightBytes()
    {
        Assert.Equal([0xC0, 0x00, 0x44, 0x66, 0x7D, 0x06, 0x78, 0x42, 0x21, 0x81], IntergalacticTransmission.GetTransmitSequence([0xC0, 0x01, 0x13, 0x37, 0xC0, 0xDE, 0x21, 0x21]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TransmitTwentyBytes()
    {
        Assert.Equal([0x44, 0xBD, 0x18, 0xAF, 0x27, 0x1B, 0xA5, 0xE7, 0x6C, 0x90, 0x1B, 0x2E, 0x33, 0x03, 0x84, 0xEE, 0x65, 0xB8, 0xDB, 0xED, 0xD7, 0x28, 0x84],
            IntergalacticTransmission.GetTransmitSequence([0x45, 0x78, 0x65, 0x72, 0x63, 0x69, 0x73, 0x6D, 0x20, 0x69, 0x73, 0x20, 0x61, 0x77, 0x65, 0x73, 0x6F, 0x6D, 0x65, 0x21]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveEmpty()
    {
        Assert.Equal([], IntergalacticTransmission.DecodeSequence([]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveZeroByte()
    {
        Assert.Equal([0x00], IntergalacticTransmission.DecodeSequence([0x00, 0x00]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveOneByteWithOneBit()
    {
        Assert.Equal([0x02], IntergalacticTransmission.DecodeSequence([0x03, 0x00]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveOneByteFromTwoOddParities()
    {
        Assert.Equal([0x05], IntergalacticTransmission.DecodeSequence([0x05, 0x81]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveOneByteSplitFromEvenAndOddParities()
    {
        Assert.Equal([0x29], IntergalacticTransmission.DecodeSequence([0x28, 0x81]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveFirstByteWrongParity()
    {
        Assert.Throws<ArgumentException>(() => IntergalacticTransmission.DecodeSequence([0x07, 0x00]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveSecondByteWrongParity()
    {
        Assert.Throws<ArgumentException>(() => IntergalacticTransmission.DecodeSequence([0x03, 0x68]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveTwoByteMessage()
    {
        Assert.Equal([0xCE, 0x94], IntergalacticTransmission.DecodeSequence([0xCF, 0x4B, 0x00]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveThreeByteMessage()
    {
        Assert.Equal([0xE2, 0xAD, 0x90], IntergalacticTransmission.DecodeSequence([0xE2, 0x56, 0x65, 0x00]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveSixByteMessage()
    {
        Assert.Equal([0x47, 0x72, 0x65, 0x61, 0x74, 0x21], IntergalacticTransmission.DecodeSequence([0x47, 0xB8, 0x99, 0xAC, 0x17, 0xA0, 0x84]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveSevenByteMessage()
    {
        Assert.Equal([0x47, 0x72, 0x65, 0x61, 0x74, 0x31, 0x21], IntergalacticTransmission.DecodeSequence([0x47, 0xB8, 0x99, 0xAC, 0x17, 0xA0, 0xC5, 0x42]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveEightByteMessage()
    {
        Assert.Equal([0xC0, 0x01, 0x13, 0x37, 0xC0, 0xDE, 0x21, 0x21], IntergalacticTransmission.DecodeSequence([0xC0, 0x00, 0x44, 0x66, 0x7D, 0x06, 0x78, 0x42, 0x21, 0x81]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveSevenByteMessageWithWrongParity()
    {
        Assert.Throws<ArgumentException>(() => IntergalacticTransmission.DecodeSequence([0x47, 0xB8, 0x99, 0xAC, 0x17, 0xA0, 0xC5, 0x43]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveTwentyByteMessage()
    {
        Assert.Equal([0x45, 0x78, 0x65, 0x72, 0x63, 0x69, 0x73, 0x6d, 0x20, 0x69, 0x73, 0x20, 0x61, 0x77, 0x65, 0x73, 0x6f, 0x6d, 0x65, 0x21],
            IntergalacticTransmission.DecodeSequence([0x44, 0xbd, 0x18, 0xaf, 0x27, 0x1b, 0xa5, 0xe7, 0x6c, 0x90, 0x1b, 0x2e, 0x33, 0x03, 0x84, 0xee, 0x65, 0xb8, 0xdb, 0xed, 0xd7, 0x28, 0x84]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReceiveWrongParityOnByte16()
    {
        Assert.Throws<ArgumentException>(() => 
            IntergalacticTransmission.DecodeSequence([0x44, 0xbd, 0x18, 0xaf, 0x27, 0x1b, 0xa5, 0xe7, 0x6c, 0x90, 0x1b, 0x2e, 0x33, 0x03, 0x84, 0xef, 0x65, 0xb8, 0xdb, 0xed, 0xd7, 0x28, 0x84]));
    }
}
