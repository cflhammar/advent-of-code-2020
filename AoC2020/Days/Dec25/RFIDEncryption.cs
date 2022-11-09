namespace AoC2020.Days.Dec25;

public class RFIDEncryption
{
    public long GetEncryptionKey(string[] publicKeys)
    {
        var cardPublicKey = Int32.Parse(publicKeys[0]);
        var doorPublicKey = Int32.Parse(publicKeys[1]);

        var cardLoopSize = RevereseTransform(cardPublicKey);
        var doorLoopSize = RevereseTransform(doorPublicKey);

        var encryptionKey = Transform(cardLoopSize, doorPublicKey);
        var encryptionKey2 = Transform(doorLoopSize, cardPublicKey);

        if (encryptionKey == encryptionKey2) return encryptionKey;
        
        return 0;
    }

    private long Transform(int loopSize, long subjectNumber)
    {
        long value = 1;

        for (int i = 1; i <= loopSize; i++)
        {
            value = value * subjectNumber;
            value = value % 20201227;
        }

        return value;
    }

    private int RevereseTransform(long result)
    {
        var subjectNumber = 7;
        long value = 1;
        int loopSize = 0;

        while (value != result)
        {
            value = value * subjectNumber;
            value = value % 20201227;
            
            loopSize++;
        }

        return loopSize;
    }
}