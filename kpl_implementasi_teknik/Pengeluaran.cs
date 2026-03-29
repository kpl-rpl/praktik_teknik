using System;

public class Pengeluaran 
{
	public string Jenis { get; set; }
	public int Jumlah { get; set; }
	public DateTime Tanggal { get; set; }

    public Pengeluaran(string jenis, int jumlah, DateTime tanggal)
    {
        Jenis = jenis;
        Jumlah = jumlah;
        Tanggal = tanggal;
    }
}
