using System;

namespace kpl_implementasi_teknik
{
    internal class TeknikStateBased
    {
        enum StateKamar
        {
            KOSONG,
            DIPESAN,
            TERISI,
            PERBAIKAN
        }

        public static void Run()
        {
            AutomataKamar();
        }

        public static void AutomataKamar()
        {
            StateKamar state = StateKamar.KOSONG;

            while (true)
            {
                Console.WriteLine("\n=== STATUS KAMAR: " + state + " ===");

                switch (state)
                {
                    case StateKamar.KOSONG:
                        Console.Write("Perintah (PESAN / PERBAIKI / EXIT): ");
                        string cmdKosong = Console.ReadLine().ToUpper();

                        if (cmdKosong == "PESAN")
                            state = StateKamar.DIPESAN;
                        else if (cmdKosong == "PERBAIKI")
                            state = StateKamar.PERBAIKAN;
                        else if (cmdKosong == "EXIT")
                            return;
                        break;

                    case StateKamar.DIPESAN:
                        Console.Write("Perintah (CHECKIN / BATAL / EXIT): ");
                        string cmdPesan = Console.ReadLine().ToUpper();

                        if (cmdPesan == "CHECKIN")
                            state = StateKamar.TERISI;
                        else if (cmdPesan == "BATAL")
                            state = StateKamar.KOSONG;
                        else if (cmdPesan == "EXIT")
                            return;
                        break;

                    case StateKamar.TERISI:
                        Console.Write("Perintah (CHECKOUT / EXIT): ");
                        string cmdIsi = Console.ReadLine().ToUpper();

                        if (cmdIsi == "CHECKOUT")
                            state = StateKamar.KOSONG;
                        else if (cmdIsi == "EXIT")
                            return;
                        break;

                    case StateKamar.PERBAIKAN:
                        Console.Write("Perintah (SELESAI / EXIT): ");
                        string cmdPerbaikan = Console.ReadLine().ToUpper();

                        if (cmdPerbaikan == "SELESAI")
                            state = StateKamar.KOSONG;
                        else if (cmdPerbaikan == "EXIT")
                            return;
                        break;
                }
            }
        }
    }
}