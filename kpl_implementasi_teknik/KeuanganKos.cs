using System;
using System.Collections.Generic;
using System.Text;

namespace kpl_implementasi_teknik
{
        public class KeuanganKos
        {
            static Dictionary<string, Action> menuPemasukan = new Dictionary<string, Action>()
        {
            { "1", InputSewaKamar },
            { "2", InputListrik },
            { "3", InputAir },
            { "4", InputLainnya }
        };

            static List<string> catatan = new List<string>();

            public static void JalankanModul()
            {
                Console.WriteLine("=== Pemasukan Kos-Kosan ===");
                Console.WriteLine("1. Sewa Kamar");
                Console.WriteLine("2. Pembayaran Listrik");
                Console.WriteLine("3. Pembayaran Air");
                Console.WriteLine("4. Lainnya");
                Console.Write("Pilih menu: ");

                string pilihan = Console.ReadLine();

                if (menuPemasukan.ContainsKey(pilihan))
                {
                    menuPemasukan[pilihan](); // ambil dari tabel
                }
                else
                {
                    Console.WriteLine("Menu tidak valid!");
                }

                TampilkanSemua();
            }

            // ===== INPUT DATA =====
            static void InputSewaKamar()
            {
                Console.Write("Nama penghuni: ");
                string nama = Console.ReadLine();

                Console.Write("Jumlah bayar: ");
                double jumlah = Convert.ToDouble(Console.ReadLine());

                catatan.Add($"Sewa Kamar - {nama}: {jumlah}");
            }

            static void InputListrik()
            {
                Console.Write("Nama penghuni: ");
                string nama = Console.ReadLine();

                Console.Write("Biaya listrik: ");
                double jumlah = Convert.ToDouble(Console.ReadLine());

                catatan.Add($"Listrik - {nama}: {jumlah}");
            }

            static void InputAir()
            {
                Console.Write("Nama penghuni: ");
                string nama = Console.ReadLine();

                Console.Write("Biaya air: ");
                double jumlah = Convert.ToDouble(Console.ReadLine());

                catatan.Add($"Air - {nama}: {jumlah}");
            }

            static void InputLainnya()
            {
                Console.Write("Keterangan: ");
                string ket = Console.ReadLine();

                Console.Write("Jumlah: ");
                double jumlah = Convert.ToDouble(Console.ReadLine());

                catatan.Add($"{ket}: {jumlah}");
            }

            // ===== TAMPILKAN DATA =====
            static void TampilkanSemua()
            {
                Console.WriteLine("\n=== Catatan Pemasukan ===");

                foreach (var item in catatan)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
