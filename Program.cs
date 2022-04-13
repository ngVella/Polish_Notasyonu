using System;
using System.Collections.Generic;

namespace Polish_Notasyonu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prefix İfadeyi Girin : ");
            string tempPrefix = Console.ReadLine();

            //stringi bosluga gore split ediyourz
            string[] prefix = tempPrefix.Split(' ');

            //srting stacki olusturuyoruz (Polish Notasyonunda Stack Kullanilir)
            Stack<string> charStack = new();

            //i = split dizimizin uzunlugu , sonuclari yazmak icin result
            //islem yapmak icinse num1 ve num2 olusturduk
            int i = prefix.Length - 1,
                    result, num1, num2;

            //yazim kolayligi olmasi icin dizi elemanlarini tempe atama yapiyorum
            string temp;

            while (true)
            {
                //splitledigimiz elemanları sirasi geldikce tempe atama yapiyoruz
                // ve tempi stacke push ediyoruz
                temp = prefix[i];
                charStack.Push(temp);

                //eger push edilen ifade bir operatorse islem yapmak icin kontroller baslıyor
                if (string.Equals(temp, "+") || string.Equals(temp, "-") || string.Equals(temp, "*") || string.Equals(temp, "/"))
                {
                    switch (temp)
                    {
                        //TOPLAMA  
                        //---Alt Casede yapilan tum aciklamalar diger caseler icin de gecerli---
                        case "+":
                            //once push ettigimiz operatoru stackten cikariyoruz
                            charStack.Pop();

                            //daha sonra stackten sayileri cikarip inte donustuyoruz
                            num1 = Int32.Parse(charStack.Pop());
                            num2 = Int32.Parse(charStack.Pop());

                            //Polis notasyonunda istedigi gibi direk hangi islem
                            //gerekli ise hesapliyoruz
                            result = num1 + num2;

                            //stacke geri push ediyoruz
                            temp = result.ToString();
                            charStack.Push(temp);
                            break;

                        //CIKARMA
                        case "-":
                            charStack.Pop();
                            num1 = Int32.Parse(charStack.Pop());
                            num2 = Int32.Parse(charStack.Pop());
                            result = num1 - num2;
                            temp = result.ToString();
                            charStack.Push(temp);
                            break;

                        //CARPMA
                        case "*":
                            charStack.Pop();
                            num1 = Int32.Parse(charStack.Pop());
                            num2 = Int32.Parse(charStack.Pop());
                            result = num1 * num2;
                            temp = result.ToString();
                            charStack.Push(temp);
                            break;

                        //BOLME
                        case "/":
                            charStack.Pop();
                            num1 = Int32.Parse(charStack.Pop());
                            num2 = Int32.Parse(charStack.Pop());
                            result = num1 / num2;
                            temp = result.ToString();
                            charStack.Push(temp);
                            break;
                    }
                }

                // dizide bir geri gidip siradaki indexi inceliyoruz
                i--;

                // i -1 olduysa eger index 0'ı da incelemis bulunmaktayiz
                // dolayısıyla artık sonucu stackten cikarip
                //ekrana bastirabiliriz
                if (i == -1)
                {
                    result = Int32.Parse(charStack.Pop());
                    Console.WriteLine($"Sonuc: {result}");
                    break;
                }
            }

        }
    }
}
