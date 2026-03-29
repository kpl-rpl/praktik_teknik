using System;
using System.Collections.Generic;

namespace kpl_implementasi_teknik
{
    public class KamarKosTableDriven
    {
        private enum StatusKamar { Kosong, Terisi, Perbaikan }

        private class Kamar
        {
            public int Nomor { get; set; }
            public StatusKamar Status { get; set; }
            public string Tipe { get; set; }
        }

        private static readonly Dictionary<string, int> HargaTipeKamar = new()
        {
            { "Standar", 500000 },
            { "Deluxe", 750000 },
            { "VIP", 1000000 }
        };

        private static readonly List<Kamar> DaftarKamar = new()
        {
            new Kamar { Nomor = 1, Status = StatusKamar.Kosong, Tipe = "Standar" },
            new Kamar { Nomor = 2, Status = StatusKamar.Terisi, Tipe = "Deluxe" },
            new Kamar { Nomor = 3, Status = StatusKamar.Kosong, Tipe = "VIP" },
            new Kamar { Nomor = 4, Status = StatusKamar.Perbaikan, Tipe = "Standar" }
        };

        public static void Run()
        {
            int pilihan = 0;
            while (pilihan != 3)
            {
                Console.WriteLine("\n=== Modul Kamar Kos (Table Driven) ===");
                Console.WriteLine("1. Lihat Daftar Kamar");
                Console.WriteLine("2. Update Status Kamar");
                Console.WriteLine("3. Kembali ke Menu Utama");
                Console.Write("Pilih menu: ");
                if (!int.TryParse(Console.ReadLine(), out pilihan))
                {
                    Console.WriteLine("Input tidak valid!");
                    continue;
                }
                switch (pilihan)
                {
                    case 1:
                        TampilkanKamar();
                        break;
                    case 2:
                        UpdateStatusKamar();
                        break;
                    case 3:
                        Console.WriteLine("Kembali ke menu utama...");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid!");
                        break;
                }
            }
        }

        private static void TampilkanKamar()
        {
            Console.WriteLine("\nNo\tTipe\tStatus\tHarga");
            foreach (var kamar in DaftarKamar)
            {
                Console.WriteLine($"{kamar.Nomor}\t{kamar.Tipe}\t{kamar.Status}\tRp{HargaTipeKamar[kamar.Tipe]}");
            }
        }

        private static void UpdateStatusKamar()
        {
            Console.Write("Masukkan nomor kamar: ");
            if (!int.TryParse(Console.ReadLine(), out int nomor))
            {
                Console.WriteLine("Input tidak valid!");
                return;
            }
            var kamar = DaftarKamar.Find(k => k.Nomor == nomor);
            if (kamar == null)
            {
                Console.WriteLine("Kamar tidak ditemukan!");
                return;
            }
            Console.WriteLine("Pilih status baru: 0=Kosong, 1=Terisi, 2=Perbaikan");
            if (!int.TryParse(Console.ReadLine(), out int status) || status < 0 || status > 2)
            {
                Console.WriteLine("Input status tidak valid!");
                return;
            }
            kamar.Status = (StatusKamar)status;
            Console.WriteLine("Status kamar berhasil diupdate!");
        }
    }
}
