namespace AES;

public class AddRoundKey
{
    public void AddRoundKeyTransform(byte[] state, byte[] roundKey)
    {
        for (int i = 0; i < 16; i++)
            state[i] ^= roundKey[i];
    }
}