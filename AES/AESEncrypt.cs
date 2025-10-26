using AES;

public class AESEncrypt
{
    private readonly AddRoundKey _addRoundKey;
    private readonly SubBytes _subBytes;
    private readonly ShiftRows _shiftRows;
    private readonly MixColumns _mixColumns;
    private readonly KeySchedule _keySchedule;

    public AESEncrypt(AddRoundKey addRoundKey, SubBytes subBytes, ShiftRows shiftRows, MixColumns mixColumns, KeySchedule keySchedule)
    {
        _addRoundKey = addRoundKey;
        _subBytes = subBytes;
        _shiftRows = shiftRows;
        _mixColumns = mixColumns;
        _keySchedule = keySchedule;
    }

    public void Encrypt(byte[] input, byte[] key)
    {
        _addRoundKey.AddRoundKeyTransform(input, key);

        for (int round = 0; round < 10; round++)
        {
            byte[] transformedInput = _subBytes.SubBytesTransform(input);
            Array.Copy(transformedInput, input, transformedInput.Length);
            _shiftRows.ShiftRowsTransform(input);
            if (round != 9)
            {
                _mixColumns.MixColumnsTransform(input);
            }
            key = _keySchedule.CreateRoundKey(key, round);
            _addRoundKey.AddRoundKeyTransform(input, key);
        }
    }

}