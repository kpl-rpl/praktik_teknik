class Program
{
    static void Main(string[] args)
    {
        KeuanganKos.JalankanModul();
        TeknikStateBased.Run();
        TeknikGeneric.Run();
        Console.WriteLine("\nTekan tombol untuk keluar...");
            Console.ReadKey();
    }
}
