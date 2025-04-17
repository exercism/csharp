public class IntergalacticTransmissionTests
{
    [Fact]
    public void Calculate_transmit_sequences_empty_message()
    {
        Assert.Equal([], IntergalacticTransmission.GetTransmitSequence([]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_transmit_sequences_0x00_is_transmitted_as_0x0000()
    {
        Assert.Equal([0x00, 0x00], IntergalacticTransmission.GetTransmitSequence([0x00]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_transmit_sequences_0x02_is_transmitted_as_0x0300()
    {
        Assert.Equal([0x03, 0x00], IntergalacticTransmission.GetTransmitSequence([0x02]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_transmit_sequences_0x06_is_transmitted_as_0x0600()
    {
        Assert.Equal([0x06, 0x00], IntergalacticTransmission.GetTransmitSequence([0x06]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_transmit_sequences_0x05_is_transmitted_as_0x0581()
    {
        Assert.Equal([0x05, 0x81], IntergalacticTransmission.GetTransmitSequence([0x05]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_transmit_sequences_0x29_is_transmitted_as_0x2881()
    {
        Assert.Equal([0x28, 0x81], IntergalacticTransmission.GetTransmitSequence([0x29]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_transmit_sequences_0xc001c0de_is_transmitted_as_0xc000711be1()
    {
        Assert.Equal([0xc0, 0x00, 0x71, 0x1b, 0xe1], IntergalacticTransmission.GetTransmitSequence([0xc0, 0x01, 0xc0, 0xde]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_transmit_sequences_six_byte_message()
    {
        Assert.Equal([0x47, 0xb8, 0x99, 0xac, 0x17, 0xa0, 0x84], IntergalacticTransmission.GetTransmitSequence([0x47, 0x72, 0x65, 0x61, 0x74, 0x21]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_transmit_sequences_seven_byte_message()
    {
        Assert.Equal([0x47, 0xb8, 0x99, 0xac, 0x17, 0xa0, 0xc5, 0x42], IntergalacticTransmission.GetTransmitSequence([0x47, 0x72, 0x65, 0x61, 0x74, 0x31, 0x21]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_transmit_sequences_eight_byte_message()
    {
        Assert.Equal([0xc0, 0x00, 0x44, 0x66, 0x7d, 0x06, 0x78, 0x42, 0x21, 0x81], IntergalacticTransmission.GetTransmitSequence([0xc0, 0x01, 0x13, 0x37, 0xc0, 0xde, 0x21, 0x21]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_transmit_sequences_twenty_byte_message()
    {
        Assert.Equal([0x44, 0xbd, 0x18, 0xaf, 0x27, 0x1b, 0xa5, 0xe7, 0x6c, 0x90, 0x1b, 0x2e, 0x33, 0x03, 0x84, 0xee, 0x65, 0xb8, 0xdb, 0xed, 0xd7, 0x28, 0x84], IntergalacticTransmission.GetTransmitSequence([0x45, 0x78, 0x65, 0x72, 0x63, 0x69, 0x73, 0x6d, 0x20, 0x69, 0x73, 0x20, 0x61, 0x77, 0x65, 0x73, 0x6f, 0x6d, 0x65, 0x21]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_empty_message()
    {
        Assert.Equal([], IntergalacticTransmission.DecodeSequence([]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_zero_message()
    {
        Assert.Equal([0x00], IntergalacticTransmission.DecodeSequence([0x00, 0x00]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_0x0300_is_decoded_to_0x02()
    {
        Assert.Equal([0x02], IntergalacticTransmission.DecodeSequence([0x03, 0x00]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_0x0581_is_decoded_to_0x05()
    {
        Assert.Equal([0x05], IntergalacticTransmission.DecodeSequence([0x05, 0x81]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_0x2881_is_decoded_to_0x29()
    {
        Assert.Equal([0x29], IntergalacticTransmission.DecodeSequence([0x28, 0x81]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_first_byte_has_wrong_parity()
    {
        Assert.Throws<ArgumentException>(() => IntergalacticTransmission.DecodeSequence([0x07, 0x00]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_second_byte_has_wrong_parity()
    {
        Assert.Throws<ArgumentException>(() => IntergalacticTransmission.DecodeSequence([0x03, 0x68]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_0xcf4b00_is_decoded_to_0xce94()
    {
        Assert.Equal([0xce, 0x94], IntergalacticTransmission.DecodeSequence([0xcf, 0x4b, 0x00]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_0xe2566500_is_decoded_to_0xe2ad90()
    {
        Assert.Equal([0xe2, 0xad, 0x90], IntergalacticTransmission.DecodeSequence([0xe2, 0x56, 0x65, 0x00]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_six_byte_message()
    {
        Assert.Equal([0x47, 0x72, 0x65, 0x61, 0x74, 0x21], IntergalacticTransmission.DecodeSequence([0x47, 0xb8, 0x99, 0xac, 0x17, 0xa0, 0x84]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_seven_byte_message()
    {
        Assert.Equal([0x47, 0x72, 0x65, 0x61, 0x74, 0x31, 0x21], IntergalacticTransmission.DecodeSequence([0x47, 0xb8, 0x99, 0xac, 0x17, 0xa0, 0xc5, 0x42]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_last_byte_has_wrong_parity()
    {
        Assert.Throws<ArgumentException>(() => IntergalacticTransmission.DecodeSequence([0x47, 0xb8, 0x99, 0xac, 0x17, 0xa0, 0xc5, 0x43]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_eight_byte_message()
    {
        Assert.Equal([0xc0, 0x01, 0x13, 0x37, 0xc0, 0xde, 0x21, 0x21], IntergalacticTransmission.DecodeSequence([0xc0, 0x00, 0x44, 0x66, 0x7d, 0x06, 0x78, 0x42, 0x21, 0x81]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_twenty_byte_message()
    {
        Assert.Equal([0x45, 0x78, 0x65, 0x72, 0x63, 0x69, 0x73, 0x6d, 0x20, 0x69, 0x73, 0x20, 0x61, 0x77, 0x65, 0x73, 0x6f, 0x6d, 0x65, 0x21], IntergalacticTransmission.DecodeSequence([0x44, 0xbd, 0x18, 0xaf, 0x27, 0x1b, 0xa5, 0xe7, 0x6c, 0x90, 0x1b, 0x2e, 0x33, 0x03, 0x84, 0xee, 0x65, 0xb8, 0xdb, 0xed, 0xd7, 0x28, 0x84]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_received_messages_wrong_parity_on_16th_byte()
    {
        Assert.Throws<ArgumentException>(() => IntergalacticTransmission.DecodeSequence([0x44, 0xbd, 0x18, 0xaf, 0x27, 0x1b, 0xa5, 0xe7, 0x6c, 0x90, 0x1b, 0x2e, 0x33, 0x03, 0x84, 0xef, 0x65, 0xb8, 0xdb, 0xed, 0xd7, 0x28, 0x84]));
    }
}
