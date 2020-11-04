using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] allBytes = new byte[9];

        byte[] bytes;
        if (reading > UInt32.MaxValue || reading < Int32.MinValue)
        {
            allBytes[0] = 0xf8;
            bytes = BitConverter.GetBytes(reading);
            bytes.CopyTo(allBytes, 1);
        }
        else if (reading > Int32.MaxValue)
        {
            allBytes[0] = 0x4;
            bytes = BitConverter.GetBytes((uint)reading);
            bytes.CopyTo(allBytes, 1);
        }
        else if (reading > UInt16.MaxValue || reading < Int16.MinValue)
        {
            allBytes[0] = 0xfc;
            bytes = BitConverter.GetBytes((int) reading);
            bytes.CopyTo(allBytes, 1);
        }
        else if (reading > Int16.MaxValue)
        {
            allBytes[0] = 0x2;
            bytes = BitConverter.GetBytes((ushort) reading);
            bytes.CopyTo(allBytes, 1);
        }
        else if (reading >= 0)
        {
            allBytes[0] = 0xfe;
            bytes = BitConverter.GetBytes((ushort) reading);
            bytes.CopyTo(allBytes, 1);
        }
        else
        {
            allBytes[0] = 0xfe;
            bytes = BitConverter.GetBytes((short) reading);
            bytes.CopyTo(allBytes, 1);
        }

        return allBytes;
    }

    public static long FromBuffer(byte[] buffer)
    {
        switch ((sbyte)buffer[0])
        {
            case -8:
                return BitConverter.ToInt64(buffer, 1);
            case 4:
                return BitConverter.ToUInt32(buffer, 1);
            case -4:
                return BitConverter.ToInt32(buffer, 1);
            case 2:
                return BitConverter.ToUInt16(buffer, 1);
            case -2:
                return BitConverter.ToInt16(buffer, 1);
            default:
                return 0;
        }
    }
}
