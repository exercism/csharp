public static class IntergalacticTransmission
{
    private const byte InitUpperMask = (byte)0xFE;

    public static byte[] GetTransmitSequence(byte[] message)
    {
        List<byte> transmitSeq = new List<byte>();
        byte carry = 0;
        byte upperMask = InitUpperMask;

        for (int i = 0; i < message.Length; i++)
        {
            if (upperMask == 0)
            {
                // The carry now contains 7 bits. Flush the carry out.
                transmitSeq.Add(AddParity(carry));
                carry = 0;
                upperMask = 0xFE;
            }

            int shiftPlaces = byte.TrailingZeroCount(upperMask);
            int current = (carry << (8 - shiftPlaces)) | (message[i] >>> shiftPlaces);
            transmitSeq.Add(AddParity((byte)current));

            // Update parameters for next round.
            carry = (byte)(message[i] & (~upperMask));

            // Shorten the upper mask.
            upperMask = (byte)(upperMask << 1);
        }

        if (upperMask != InitUpperMask)
        {
            byte lastGroup = (byte)(carry << byte.PopCount(upperMask));
            // We have left over carry data
            transmitSeq.Add(AddParity(lastGroup));
        }
        return transmitSeq.ToArray();
    }

    private static byte AddParity(byte source)
    {
        if (byte.PopCount((byte)(source & 0x7F)) % 2 == 0)
        {
            return (byte)(source << 1);
        }
        return (byte)((source << 1) | 1);
    }

    public static byte[] DecodeSequence(byte[] receivedSeq)
    {
        if (receivedSeq.Length == 0)
        {
            return [];
        }

        List<byte> decodedMessage = new List<byte>();
        byte byteToAdd = 0x00;
        byte upperMask = 0xFF;
        for (int i = 0; i < receivedSeq.Length; i++)
        {
            if (upperMask == 0xFF)
            {
                // We've completed a complete round.
                // Current byte too short.
                byteToAdd = GetByteData(receivedSeq[i]);
                upperMask = 0x80;
                continue;
            }

            byte currentByteData = GetByteData(receivedSeq[i]);
            byte contribution = (byte)(currentByteData >>> byte.TrailingZeroCount(upperMask));
            decodedMessage.Add((byte)(byteToAdd | contribution));

            // Update parameters for next round
            byteToAdd = (byte)((currentByteData & ~(upperMask | 0x01)) << byte.PopCount(upperMask));
            upperMask = (byte)((upperMask >> 1) | 0x80);
        }
        return decodedMessage.ToArray();
    }

    private static byte GetByteData(byte data)
    {
        if (byte.PopCount(data) % 2 != 0)
        {
            throw new ArgumentException("Byte has incorrect parity");
        }

        return (byte)(data & 0xFE);
    }
}
