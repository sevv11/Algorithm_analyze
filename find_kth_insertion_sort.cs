using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Farklı dizi boyutları
        int[] diziler = { 100, 500, 1000, 2000, 5000 };
        int k = 10; // k. en küçük elemanı bul

        foreach (int boyut in diziler)
        {
            // Rastgele sayılarla dolu bir dizi oluştur
            int[] dizi = new int[boyut];
            var r = new Random();
            for (int i = 0; i < boyut; i++)
            {
                dizi[i] = r.Next(1, 10000);
            }

            // Yöntem 1: Diziyi sıralayarak k. elemanı bul
            var diziKopya1 = (int[])dizi.Clone(); // Dizi kopyala
            var stopwatch1 = Stopwatch.StartNew();
            int kEnKucuk1 = KEnKucukSiralama(diziKopya1, k);
            stopwatch1.Stop();

            // Yöntem 2: İlk k elemanı sıralayarak k. elemanı bul
            var diziKopya2 = (int[])dizi.Clone(); // Dizi kopyala
            var stopwatch2 = Stopwatch.StartNew();
            int kEnKucuk2 = KEnKucukIlkKSiralama(diziKopya2, k);
            stopwatch2.Stop();

            Console.WriteLine($"Dizi Boyutu: {boyut}");
            Console.WriteLine($"Yöntem 1 (Tam Sıralama): {stopwatch1.ElapsedMilliseconds} ms, k. En Küçük: {kEnKucuk1}");
            Console.WriteLine($"Yöntem 2 (İlk k Sıralama): {stopwatch2.ElapsedMilliseconds} ms, k. En Küçük: {kEnKucuk2}");
            Console.WriteLine();
        }
    }

    static int KEnKucukSiralama(int[] dizi, int k)
    {
        Array.Sort(dizi);
        return dizi[k - 1];
    }

    static int KEnKucukIlkKSiralama(int[] dizi, int k)
    {
        // İlk k elemanı sırala
        for (int i = 0; i < k; i++)
        {
            for (int j = i + 1; j < dizi.Length; j++)
            {
                if (dizi[i] > dizi[j])
                {
                    // Swap
                    int temp = dizi[i];
                    dizi[i] = dizi[j];
                    dizi[j] = temp;
                }
            }
        }

        // Kalan elemanları karşılaştır
        for (int i = k; i < dizi.Length; i++)
        {
            if (dizi[i] < dizi[k - 1])
            {
                // k. elemanla swap
                int temp = dizi[i];
                dizi[i] = dizi[k - 1];
                dizi[k - 1] = temp;

                // İlk k elemanı yeniden sırala
                for (int j = 0; j < k - 1; j++)
                {
                    for (int l = j + 1; l < k; l++)
                    {
                        if (dizi[j] > dizi[l])
                        {
                            // Swap
                            temp = dizi[j];
                            dizi[j] = dizi[l];
                            dizi[l] = temp;
                        }
                    }
                }
            }
        }

        return dizi[k - 1];
    }
}
