using System;

class Dizi_Toplamı
{
    static void Main()
    {
        // Örnek dizi
        int[] dizi = { -2, -3, 4, -1, -2, 1, 5, -3 };

        Console.WriteLine("Dizi:");
        Yazdir(dizi);

        // En büyük ardışık alt dizi toplamı
        int enBuyukToplam = EnBuyukArdisikAltDiziToplami(dizi);

        Console.WriteLine($"En Büyük Ardışık Alt Dizi Toplamı: {enBuyukToplam}");
    }

    static int EnBuyukArdisikAltDiziToplami(int[] dizi)
    {
        int enBuyukToplam = int.MinValue;
        int geciciToplam = 0;

        for (int i = 0; i < dizi.Length; i++)
        {
            geciciToplam = 0;
            for (int j = i; j < dizi.Length; j++)
            {
                geciciToplam += dizi[j];
                if (geciciToplam > enBuyukToplam)
                {
                    enBuyukToplam = geciciToplam;
                }
            }
        }

        return enBuyukToplam;
    }

    static void Yazdir(int[] dizi)
    {
        foreach (var item in dizi)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
