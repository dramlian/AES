namespace AES;

public class KeySchedule
{
    private SubBytes _subBytes;

    public KeySchedule()
    {
        _subBytes = new SubBytes();
    }

    public byte[] CreateRoundKey(byte[] input, int roundKey)
    {
        byte[] output = new byte[16];

        var firstColumn = CreateRotWord(input, roundKey);
        output = InsertColumn(output, firstColumn, 0, 4);

        for (int i = 0; i < 3; i++)
        {
            byte[] newColumn = new byte[4];
            firstColumn = GetColumn(output, i, 4);
            var nextColumn = GetColumn(input, i + 1, 4);
            for (int j = 0; j < 4; j++)
            {
                newColumn[j] = (byte)(firstColumn[j] ^ nextColumn[j]);
            }
            output = InsertColumn(output, newColumn, i + 1, 4);
        }
        return output;
    }

    private byte[] CreateRotWord(byte[] input, int roundKey)
    {
        var inputFirstColumn = GetColumn(input, 0, 4);
        var inputLastColumn = GetColumn(input, 3, 4);

        byte[] output = new byte[4];
        byte[] rconTable = new byte[]
        {
        0x01,0x02,0x04,0x08,0x10,0x20,0x40,0x80,0x1B,0x36,
        0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
        0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
        0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
        };

        byte[] switched = new byte[4];
        switched[0] = inputLastColumn[1];
        switched[1] = inputLastColumn[2];
        switched[2] = inputLastColumn[3];
        switched[3] = inputLastColumn[0];

        byte[] subbed = _subBytes.SubBytesTransform(switched);
        var rconRow = GetColumn(rconTable, roundKey, 10);

        for (int i = 0; i < 4; i++)
        {
            output[i] = (byte)(subbed[i] ^ rconRow[i] ^ inputFirstColumn[i]);
        }

        return output;
    }

    private byte[] GetColumn(byte[] table, int columnIndex, int totalColumns)
    {
        byte[] column = new byte[4];
        for (int row = 0; row < 4; row++)
        {
            column[row] = table[row * totalColumns + columnIndex];
        }
        return column;
    }

    private byte[] InsertColumn(byte[] table, byte[] column, int columnIndex, int totalColumns)
    {
        for (int row = 0; row < 4; row++)
        {
            table[row * totalColumns + columnIndex] = column[row];
        }
        return table;
    }
}