namespace AES.Tests;

using AES;

// Test vector from NIST FIPS-197, Appendix B, AES-128 example, ShiftRows
public class ShiftRowsTest
{

    [Fact]
    public void Row0Test()
    {
        byte[] input = new byte[]{
            0xd4, 0xe0, 0xb8, 0x1e,
            0x27, 0xbf, 0xb4, 0x41,
            0x11, 0x98, 0x5d, 0x52,
            0xae, 0xf1, 0xe5, 0x30
        };

        byte[] expectedOutput = new byte[]{
            0xd4, 0xe0, 0xb8, 0x1e,
            0xbf, 0xb4, 0x41, 0x27,
            0x5d, 0x52, 0x11, 0x98,
            0x30, 0xae, 0xf1, 0xe5
        };

        ShiftRowsTestAction(input, expectedOutput);
    }

    [Fact]
    public void Row1Test()
    {
        byte[] input = new byte[]{
            0x49, 0x45, 0x7f, 0x77,
            0xde, 0xdb, 0x39, 0x02,
            0xd2, 0x96, 0x87, 0x53,
            0x89, 0xf1, 0x1a, 0x3b
        };

        byte[] expectedOutput = new byte[]{
            0x49, 0x45, 0x7f, 0x77,
            0xdb, 0x39, 0x02, 0xde,
            0x87, 0x53, 0xd2, 0x96,
            0x3b, 0x89, 0xf1, 0x1a
        };

        ShiftRowsTestAction(input, expectedOutput);
    }

    [Fact]
    public void Row2Test()
    {
        byte[] input = new byte[]{
            0xac, 0xef, 0x13, 0x45,
            0x73, 0xc1, 0xb5, 0x23,
            0xcf, 0x11, 0xd6, 0x5a,
            0x7b, 0xdf, 0xb5, 0xb8
        };

        byte[] expectedOutput = new byte[]
        {
            0Xac, 0Xef, 0X13, 0X45,
            0Xc1, 0Xb5, 0X23, 0X73,
            0Xd6, 0X5a, 0Xcf, 0X11,
            0Xb8, 0X7b, 0Xdf, 0Xb5
        };

        ShiftRowsTestAction(input, expectedOutput);
    }

    private void ShiftRowsTestAction(byte[] input, byte[] expectedOutput)
    {
        var originalInput = (byte[])input.Clone();
        ShiftRows shiftRows = new ShiftRows();
        shiftRows.ShiftRowsTransform(input);
        Assert.Equal(expectedOutput, input);
        shiftRows.InvShiftRowsTransform(input);
        Assert.Equal(originalInput, input);
    }

}