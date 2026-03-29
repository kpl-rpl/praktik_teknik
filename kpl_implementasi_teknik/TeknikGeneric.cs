using System;
using System.Collections.Generic;

public class Kamar
{
    public int Nomor { get; set; }
    public string Tipe { get; set; }
    public int Harga { get; set; }
}

public class PenyimpananKos<T>
{
    private List<T> data = new List<T>();

    public void Tambah(T item)
    {
        data.Add(item);
    }

    public List<T> AmbilSemua()
    {
        return data;
    }
}

public class TeknikGeneric
{
    public static void Run()
    {
        PenyimpananKos<Kamar> repoKamar = new PenyimpananKos<Kamar>();

        Kamar kamar1 = new Kamar();
        kamar1.Nomor = 1;
        kamar1.Tipe = "AC";
        kamar1.Harga = 1500000;

        Kamar kamar2 = new Kamar();
        kamar2.Nomor = 2;
        kamar2.Tipe = "Kipas Angin";
        kamar2.Harga = 800000;

        repoKamar.Tambah(kamar1);
        repoKamar.Tambah(kamar2);

        Console.WriteLine("--- Daftar Kamar Kos ---");

        foreach (Kamar k in repoKamar.AmbilSemua())
        {
            Console.WriteLine("Kamar Nomor : " + k.Nomor);
            Console.WriteLine("Tipe Kamar  : " + k.Tipe);
            Console.WriteLine("Harga/Bulan : Rp" + k.Harga);
            Console.WriteLine("------------------------");
        }
    }
}