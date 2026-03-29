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
                Console.WriteLine("\n=== Modul Kamar Kos (Table Driven) ===");
                KamarKosTableDriven.Run();
            } }
        };

        int pilihan = 0;
        while (pilihan != 3)
        {
            Console.WriteLine("\n=== MENU UTAMA ===");
            Console.WriteLine("1. Pengeluaran (State Based)");
            Console.WriteLine("2. Kamar Kos (Table Driven)");
            Console.WriteLine("3. Keluar");
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
            else if (pilihan != 3)
            {
                Console.WriteLine("Pilihan tidak valid!");
            }
        }
        Console.WriteLine("\nTerima kasih!");
    }
}
