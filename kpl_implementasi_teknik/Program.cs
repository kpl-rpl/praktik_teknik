using System;

class Program
{
    static void Main(string[] args)
    {
        PengeluaranService service = new PengeluaranService();
        service.Menu();
        KeuanganKos.JalankanModul();
        TeknikStateBased.Run();
        TeknikGeneric.Run();
        Console.WriteLine("\nTekan tombol untuk keluar...");
            Console.ReadKey();
    }
}
