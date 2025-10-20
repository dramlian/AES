namespace AES.Tests;

using AES;
// Test vector from NIST FIPS-197, Appendix B, AES-128 example, MixColumns
public class MixColumnsTest
{
    [Fact]
    public void Row0Test()
    {
        byte[] input = {
            0xd4, 0xe0, 0xb8, 0x1e,
            0xbf, 0xb4, 0x41, 0x27,
            0x5d, 0x52, 0x11, 0x98,
            0x30, 0xae, 0xf1, 0xe5
        };

        byte[] expectedOutput = {
            0x04, 0xe0, 0x48, 0x28,
            0x66, 0xcb, 0xf8, 0x06,
            0x81, 0x19, 0xd3, 0x26,
            0xe5, 0x9a, 0x7a, 0x4c
        };

        MixColumnsTestAction(input, expectedOutput);
    }

    [Fact]
    public void Row1Test()
    {
        byte[] input = {
            0x49, 0x45, 0x7f, 0x77,
            0xdb, 0x39, 0x02, 0xde,
            0x87, 0x53, 0xd2, 0x96,
            0x3b, 0x89, 0xf1, 0x1a
        };

        byte[] expectedOutput = {
            0x58, 0x1b, 0xdb, 0x1b,
            0x4d, 0x4b, 0xe7, 0x6b,
            0xca, 0x5a, 0xca, 0xb0,
            0xf1, 0xac, 0xa8, 0xe5
        };

        MixColumnsTestAction(input, expectedOutput);
    }

    [Fact]
    public void Row2Test()
    {
        byte[] input = {
            0xac, 0xef, 0x13, 0x45,
            0xc1, 0xb5, 0x23, 0x73,
            0xd6, 0x5a, 0xcf, 0x11,
            0xb8, 0x7b, 0xdf, 0xb5
        };

        byte[] expectedOutput = {
                0x75, 0x20, 0x53, 0xbb,
                0xec, 0x0b, 0xc0, 0x25,
                0x09, 0x63, 0xcf, 0xd0,
                0x93, 0x33, 0x7c, 0xdc
        };

        MixColumnsTestAction(input, expectedOutput);
    }

    private void MixColumnsTestAction(byte[] input, byte[] expectedOutput)
    {
        byte[] inputOriginal = (byte[])input.Clone();
        MixColumns mixColumns = new MixColumns();
        mixColumns.MixColumnsTransform(input);
        Assert.Equal(expectedOutput, input);
        mixColumns.InvMixColumnsTransform(input);
        Assert.Equal(inputOriginal, input);
    }
}