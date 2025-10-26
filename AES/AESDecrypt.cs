using AES;

public class AESDecrypt
{
    private readonly AddRoundKey _addRoundKey;
    private readonly SubBytes _subBytes;
    private readonly ShiftRows _shiftRows;
    private readonly MixColumns _mixColumns;
    private readonly KeySchedule _keySchedule;

    public AESDecrypt(AddRoundKey addRoundKey, SubBytes subBytes, ShiftRows shiftRows, MixColumns mixColumns, KeySchedule keySchedule)
    {
        _addRoundKey = addRoundKey;
        _subBytes = subBytes;
        _shiftRows = shiftRows;
        _mixColumns = mixColumns;
        _keySchedule = keySchedule;
    }

    public void Decrypt(byte[] input, byte[] key)
    {
        var roundKeys = GenerateAllRoundKeys(key, 10);

        _addRoundKey.AddRoundKeyTransform(input, roundKeys[10]);

        for (int round = 9; round >= 0; round--)
        {
            _shiftRows.InvShiftRowsTransform(input);
            byte[] transformedInput = _subBytes.InvSubBytesTransform(input);
            Array.Copy(transformedInput, input, transformedInput.Length);
            _addRoundKey.AddRoundKeyTransform(input, roundKeys[round]);

            if (round != 0)
            {
                _mixColumns.InvMixColumnsTransform(input);
            }
        }
    }

    public byte[][] GenerateAllRoundKeys(byte[] key, int totalRounds)
    {
        byte[][] roundKeys = new byte[totalRounds + 1][];
        roundKeys[0] = key;

        for (int round = 1; round <= totalRounds; round++)
        {
            roundKeys[round] = _keySchedule.CreateRoundKey(roundKeys[round - 1], round - 1);
        }

        return roundKeys;
    }
}
