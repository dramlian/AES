namespace AES;

public class ShiftRows
{

    public ShiftRows()
    {

    }

    public void ShiftRowsTransform(byte[] input)
    {
        var b4 = input[4]; var b5 = input[5]; var b6 = input[6]; var b7 = input[7];
        var b8 = input[8]; var b9 = input[9]; var b10 = input[10]; var b11 = input[11];
        var b12 = input[12]; var b13 = input[13]; var b14 = input[14]; var b15 = input[15];

        input[4] = b5;
        input[5] = b6;
        input[6] = b7;
        input[7] = b4;

        input[8] = b10;
        input[9] = b11;
        input[10] = b8;
        input[11] = b9;

        input[12] = b15;
        input[13] = b12;
        input[14] = b13;
        input[15] = b14;
    }

    public void InvShiftRowsTransform(byte[] input)
    {
        var b4 = input[4]; var b5 = input[5]; var b6 = input[6]; var b7 = input[7];
        var b8 = input[8]; var b9 = input[9]; var b10 = input[10]; var b11 = input[11];
        var b12 = input[12]; var b13 = input[13]; var b14 = input[14]; var b15 = input[15];

        input[4] = b7;
        input[5] = b4;
        input[6] = b5;
        input[7] = b6;

        input[8] = b10;
        input[9] = b11;
        input[10] = b8;
        input[11] = b9;

        input[12] = b13;
        input[13] = b14;
        input[14] = b15;
        input[15] = b12;
    }
}