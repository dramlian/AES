using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using AES;

public class AESBench
{
    private readonly byte[] key = new byte[16];
    private readonly byte[] block = new byte[16];
    private AESEncrypt myAes;
    private AESDecrypt myAesDec;
    private Aes systemAes;

    public AESBench()
    {
        for (int i = 0; i < 16; i++)
        {
            key[i] = (byte)i;
            block[i] = (byte)(i * 2);
        }

        myAes = new AESEncrypt(new AddRoundKey(), new SubBytes(), new ShiftRows(), new MixColumns(), new KeySchedule());
        myAesDec = new AESDecrypt(new AddRoundKey(), new SubBytes(), new ShiftRows(), new MixColumns(), new KeySchedule());

        systemAes = Aes.Create();
        systemAes.KeySize = 128;
        systemAes.Mode = CipherMode.ECB;
        systemAes.Padding = PaddingMode.None;
    }

    [Benchmark]
    public void MyAesEncrypt()
    {
        byte[] temp = (byte[])block.Clone();
        byte[] k = (byte[])key.Clone();
        myAes.Encrypt(temp, k);
    }

    [Benchmark]
    public void MyAesDecrypt()
    {
        byte[] temp = (byte[])block.Clone();
        byte[] k = (byte[])key.Clone();
        myAesDec.Decrypt(temp, k);
    }

    [Benchmark]
    public void SystemAesEncrypt()
    {
        using var encryptor = systemAes.CreateEncryptor(key, null);
        byte[] output = new byte[16];
        encryptor.TransformBlock(block, 0, 16, output, 0);
    }

    [Benchmark]
    public void SystemAesDecrypt()
    {
        using var decryptor = systemAes.CreateDecryptor(key, null);
        byte[] output = new byte[16];
        decryptor.TransformBlock(block, 0, 16, output, 0);
    }
}

class Program
{
    static void Main()
    {
        BenchmarkRunner.Run<AESBench>();
    }
}
