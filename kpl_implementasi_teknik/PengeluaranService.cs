using System;
using System.Collections.Generic;

public class PengeluaranService
{
    private Dictionary<string, string> kategoriPengeluaran = new Dictionary<string, string>()
    {
        {"Listrik", "Listrik Bersama"},
        {"Gas", "Gas"},
        {"Tak Terduga", "Biaya Tidak Terduga"},
        {"AC", "Service AC"}

    };

    private List<Pengeluaran> daftarPengeluaran = new List<Pengeluaran>();

    public void InputPengeluaran()
    {
        Console.Write("\nMasukkan jenis pengeluaran (Listrik/Gas/TakTerduga/AC): ");
        string jenis = Console.ReadLine();

        if (!kategoriPengeluaran.ContainsKey(jenis))
        {
            Console.WriteLine("Jenis tidak valid!");
            return;
        }

        Console.Write("Masukkan jumlah biaya: ");
        if (!int.TryParse(Console.ReadLine(), out int jumlah))
        {
            Console.WriteLine("Input jumlah tidak valid!");
            return;
        }

        Console.Write("Masukkan tanggal (yyyy-mm-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime tanggal))
        {
            Console.WriteLine("Format tanggal salah!");
            return;
        }

        Pengeluaran p = new Pengeluaran(jenis, jumlah, tanggal);
        daftarPengeluaran.Add(p);

        Console.WriteLine("Data berhasil ditambahkan!");
    }

    public void LaporanBulanan()
    {
        Console.Write("\nMasukkan bulan (1-12): ");
        if (!int.TryParse(Console.ReadLine(), out int bulan))
        {
            Console.WriteLine("Input tidak valid!");
            return;
        }

        Console.Write("Masukkan tahun: ");
        if (!int.TryParse(Console.ReadLine(), out int tahun))
        {
            Console.WriteLine("Input tidak valid!");
            return;
        }

        int total = 0;
        Dictionary<string, int> rincian = new Dictionary<string, int>();

        foreach (var item in daftarPengeluaran)
        {
            if (item.Tanggal.Month == bulan && item.Tanggal.Year == tahun)
            {
                total += item.Jumlah;

                if (!rincian.ContainsKey(item.Jenis))
                {
                    rincian[item.Jenis] = 0;
                }

                rincian[item.Jenis] += item.Jumlah;
            }
        }

        Console.WriteLine($"\n=== Laporan Pengeluaran Bulan {bulan}/{tahun} ===");

        if (total == 0)
        {
            Console.WriteLine("Tidak ada data pengeluaran.");
            return;
        }

        Console.WriteLine("Total Pengeluaran: " + total);

        Console.WriteLine("\nRincian:");
        foreach (var r in rincian)
        {
            Console.WriteLine($"{kategoriPengeluaran[r.Key]} : {r.Value}");
        }
    }

    public void Menu()
    {
        int pilihan = 0;

        while (pilihan != 3)
        {
            Console.WriteLine("\n=== SISTEM PENGELOLAAN PENGELUARAN KOS ===");
            Console.WriteLine("1. Input Pengeluaran");
            Console.WriteLine("2. Lihat Laporan Bulanan");
            Console.WriteLine("3. Keluar");
            Console.Write("Pilih menu: ");

            if (!int.TryParse(Console.ReadLine(), out pilihan))
            {
                Console.WriteLine("Input tidak valid!");
                continue;
            }

            switch (pilihan)
            {
                case 1:
                    InputPengeluaran();
                    break;
                case 2:
                    LaporanBulanan();
                    break;
                case 3:
                    Console.WriteLine("Terima kasih!");
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid!");
                    break;
            }
        }
    }
}