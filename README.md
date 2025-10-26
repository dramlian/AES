# AES Implementation in C#

A simple, educational implementation of the Advanced Encryption Standard (AES) algorithm in C#. This project demonstrates the core AES encryption and decryption processes with a focus on clarity and learning.

⚠️ **Educational Purpose Only**: This implementation is intended for learning and educational purposes. Do NOT use this in production environments or for securing sensitive data.

## 🚀 Quick Start

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later

### Supported Features

- ✅ AES-128 encryption and decryption
- ✅ Single block operations (16 bytes)
- ✅ Row-based state representation
- ✅ NIST SP 800-38A test vector compliance

### Limitations

- ❌ Only supports 128-bit keys
- ❌ Single block only (no chaining modes like ECB, CBC)
- ❌ No initialization vectors (IV)
- ❌ Not optimized for production use

## 📊 Performance Benchmarks

Latest benchmark results on Ubuntu 24.04.3 LTS with Intel Core i5-12450H:

| Method                 | Mean       | Error    | StdDev   | Ratio |
| ---------------------- | ---------- | -------- | -------- | ----- |
| **Custom AES Encrypt** | 4,048.8 ns | 74.34 ns | 62.07 ns | ~4.9x |
| **Custom AES Decrypt** | 7,394.6 ns | 31.49 ns | 29.46 ns | ~8.7x |
| **.NET AES Encrypt**   | 832.0 ns   | 3.82 ns  | 3.58 ns  | 1.0x  |
| **.NET AES Decrypt**   | 847.2 ns   | 5.56 ns  | 4.64 ns  | 1.0x  |

## 🧪 Testing

The implementation is thoroughly tested against NIST Special Publication 800-38A and FIPS 197 test vectors:

```bash
dotnet test --verbosity normal
```

All tests validate:

- Correct encryption of known plaintext/key pairs
- Proper decryption back to original plaintext
- Compliance with NIST standards

## 📚 Learning Resources

- [NIST SP 800-38A](https://nvlpubs.nist.gov/nistpubs/legacy/sp/nistspecialpublication800-38a.pdf) - AES Test Vectors
- [FIPS 197](https://nvlpubs.nist.gov/nistpubs/FIPS/NIST.FIPS.197-upd1.pdf) - AES Standard

## ⚖️ License

This project is for educational purposes only. Please refer to the license file for details.

## 🤝 Contributing

This is an educational project. Feel free to fork and experiment, but remember this is not intended for production use.
