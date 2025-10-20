public class MixColumns
{
    private byte GFMul(byte a, byte b)
    {
        byte result = 0;
        for (int i = 0; i < 8; i++)
        {
            if ((b & 1) != 0) result ^= a;
            bool hi = (a & 0x80) != 0;
            a <<= 1;
            if (hi) a ^= 0x1B;
            b >>= 1;
        }
        return result;
    }

    public void MixColumnsTransform(byte[] state)
    {
        if (state == null || state.Length != 16) throw new ArgumentException("State must be 16 bytes.");

        for (int c = 0; c < 4; c++)
        {
            byte s0 = state[c + 4 * 0];
            byte s1 = state[c + 4 * 1];
            byte s2 = state[c + 4 * 2];
            byte s3 = state[c + 4 * 3];

            state[c + 4 * 0] = (byte)(GFMul(0x02, s0) ^ GFMul(0x03, s1) ^ s2 ^ s3);
            state[c + 4 * 1] = (byte)(s0 ^ GFMul(0x02, s1) ^ GFMul(0x03, s2) ^ s3);
            state[c + 4 * 2] = (byte)(s0 ^ s1 ^ GFMul(0x02, s2) ^ GFMul(0x03, s3));
            state[c + 4 * 3] = (byte)(GFMul(0x03, s0) ^ s1 ^ s2 ^ GFMul(0x02, s3));
        }
    }

    public void InvMixColumnsTransform(byte[] state)
    {
        if (state == null || state.Length != 16) throw new ArgumentException("State must be 16 bytes.");

        for (int c = 0; c < 4; c++)
        {
            byte s0 = state[c + 4 * 0];
            byte s1 = state[c + 4 * 1];
            byte s2 = state[c + 4 * 2];
            byte s3 = state[c + 4 * 3];

            state[c + 4 * 0] = (byte)(GFMul(0x0E, s0) ^ GFMul(0x0B, s1) ^ GFMul(0x0D, s2) ^ GFMul(0x09, s3));
            state[c + 4 * 1] = (byte)(GFMul(0x09, s0) ^ GFMul(0x0E, s1) ^ GFMul(0x0B, s2) ^ GFMul(0x0D, s3));
            state[c + 4 * 2] = (byte)(GFMul(0x0D, s0) ^ GFMul(0x09, s1) ^ GFMul(0x0E, s2) ^ GFMul(0x0B, s3));
            state[c + 4 * 3] = (byte)(GFMul(0x0B, s0) ^ GFMul(0x0D, s1) ^ GFMul(0x09, s2) ^ GFMul(0x0E, s3));
        }
    }
}
