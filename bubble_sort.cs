using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Farklı dizi boyutları
        int[] diziler = { 100, 500, 1000, 2000, 5000 };

        foreach (int boyut in diziler)
        {
            // Rastgele sayılarla dolu bir dizi oluştur
            int[] dizi = new int[boyut];
            var r = new Random();
            for (int i = 0; i < boyut; i++)
            {
                dizi[i] = r.Next(1, 10000);
            }

            // Bubble Sort'u ölç
            var stopwatch = Stopwatch.StartNew();
            BubbleSort(dizi);
            stopwatch.Stop();

            Console.WriteLine($"Dizi Boyutu: {boyut}, Geçen Zaman: {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    static void BubbleSort(int[] dizi)
    {
        int n = dizi.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (dizi[j] > dizi[j + 1])
                {
                    // Swap
                    int temp = dizi[j];
                    dizi[j] = dizi[j + 1];
                    dizi[j + 1] = temp;
                }
            }
        }
    }
}
