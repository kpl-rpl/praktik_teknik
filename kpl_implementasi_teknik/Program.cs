using System;
using kpl_implementasi_teknik;

class Program
{
    static void Main(string[] args)
    {
        var menu = new Dictionary<int, Action>
        {
            { 1, () => {
                Console.WriteLine("\n=== Modul Pengeluaran (State Based) ===");
                PengeluaranService service = new PengeluaranService();
                service.Menu();
            } },
            { 2, () => {
                Console.WriteLine("\n=== Modul Pemasukan (Table Driven) ===");
                KeuanganKos.JalankanModul();
            } },
            { 3, () => {
                Console.WriteLine("\n=== Modul Kamar Kos (State Based) ===");
                TeknikStateBased.Run();
            } },
            { 4, () => {
                Console.WriteLine("\n=== Modul Kamar Kos (Table Driven) ===");
                KamarKosTableDriven.Run();
            } },
            { 5, () => {
                Console.WriteLine("\n=== Modul Teknik Generic ===");
                // TeknikGeneric.Run();
            } }
        };

        int pilihan = 0;
        while (pilihan != 6)
        {
            Console.WriteLine("\n=== MENU UTAMA ===");
            Console.WriteLine("1. Pengeluaran (State Based)");
            Console.WriteLine("2. Pemasukan (Table Driven)");
            Console.WriteLine("3. Kamar Kos (State Based)");
            Console.WriteLine("4. Kamar Kos (Table Driven)");
            Console.WriteLine("5. Teknik Generic");
            Console.WriteLine("6. Keluar");
            Console.Write("Pilih menu: ");
            if (!int.TryParse(Console.ReadLine(), out pilihan))
            {
                Console.WriteLine("Input tidak valid!");
                continue;
            }
            if (menu.ContainsKey(pilihan))
            {
                menu[pilihan]();
            }
            else if (pilihan != 6)
            {
                Console.WriteLine("Pilihan tidak valid!");
            }
        }
        Console.WriteLine("\nTerima kasih!");
    }
}
