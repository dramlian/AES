namespace AES.Tests;

using AES;

// Test vector from NIST FIPS-197, Appendix B, AES-128 example, SubBytes
public class SubBytesTests
{
    [Fact]
    public void Row0Test()
    {
        byte[] input = new byte[]
        {
            0x19, 0xA0, 0x9A, 0xE9,
            0x3D, 0xF4, 0xC6, 0xF8,
            0xE3, 0xE2, 0x8D, 0x48,
            0xBE, 0x2B, 0x2A, 0x08
        };

        byte[] expectedOutput = new byte[]
        {
            0xD4, 0xE0, 0xB8, 0x1E,
            0x27, 0xBF, 0xB4, 0x41,
            0x11, 0x98, 0x5D, 0x52,
            0xAE, 0xF1, 0xE5, 0x30
        };

        SubBytes sb = new SubBytes();
        byte[] cyphered = sb.SubBytesTransform(input);
        Assert.Equal(expectedOutput, cyphered);

        byte[] plaintext = sb.InvSubBytesTransform(cyphered);
        Assert.Equal(input, plaintext);
    }

    [Fact]
    public void Row1Test()
    {
        byte[] input = new byte[]
        {
            0xA4, 0x68, 0x6B, 0x02,
            0x9C, 0x9F, 0x5B, 0x6A,
            0x7F, 0x35, 0xEA, 0x50,
            0xF2, 0x2B, 0x43, 0x49
        };

        byte[] expectedOutput = new byte[]
        {
            0x49, 0x45, 0x7F, 0x77,
            0xDE, 0xDB, 0x39, 0x02,
            0xD2, 0x96, 0x87, 0x53,
            0x89, 0xF1, 0x1A, 0x3B
        };

        SubBytes sb = new SubBytes();
        byte[] cyphered = sb.SubBytesTransform(input);
        Assert.Equal(expectedOutput, cyphered);

        byte[] plaintext = sb.InvSubBytesTransform(cyphered);
        Assert.Equal(input, plaintext);
    }

    [Fact]
    public void Row2Test()
    {
        byte[] input = new byte[]
        {
            0xAA, 0x61, 0x82, 0x68,
            0x8F, 0xDD, 0xD2, 0x32,
            0x5F, 0xE3, 0x4A, 0x46,
            0x03, 0xEF, 0xD2, 0x9A
        };

        byte[] expectedOutput = new byte[]
        {
            0xAC, 0xEF, 0x13, 0x45,
            0x73, 0xC1, 0xB5, 0x23,
            0xCF, 0x11, 0xD6, 0x5A,
            0x7B, 0xDF, 0xB5, 0xB8
        };

        SubBytes sb = new SubBytes();
        byte[] cyphered = sb.SubBytesTransform(input);
        Assert.Equal(expectedOutput, cyphered);

        byte[] plaintext = sb.InvSubBytesTransform(cyphered);
        Assert.Equal(input, plaintext);
    }

}
