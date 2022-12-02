namespace H4ScrumBoardAPI
{
    public interface ICrypto
    {
        byte[] GenerateSalt();
        byte[] CreateHash(string password, byte[] salt);
        bool Verify(string passwordfromdb, string passwordprovided, byte[] salt);
    }
}
