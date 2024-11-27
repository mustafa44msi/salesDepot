using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace salesDepot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("lütfen toplam sermayenizi girin: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            string selection;
            while (true)
            {
                GetMenu();
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        BuyProduct(ref balance);
                        break;
                    case "2":
                        AddToStock(ref balance);
                        break;
                    case "3":
                        ListProducts();
                        break;
                    case "4":
                        SellProduct(ref balance);
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Yanlış bir tuşa bastınız. Lütfen tekrar deneyiniz.");
                        Thread.Sleep(1000);
                        break;
                }

            }

            static string Menu(ref decimal balance) => $@"{new string('*', 5)}Ticaret Uygulamasına Hoşgeldiniz{new string('*', 5)}
        Toplam Bakiyeniz: {balance}

1 - Ürün Satın Al
2 - Ürün Ekle
3 - Ürünleri Listele
4 - Ürün Sat
5 - Uygulamadan Çıkış Yap";

            static void BuyProduct(ref decimal balance)
            {
                Console.Clear();
                var product = ProgramObjetcs.Products;
                Console.WriteLine("Lütfen ürünün ismini girin");
                string Name = Console.ReadLine();
                Console.WriteLine("Lütfen ürünün fiyatını girin");
                decimal Price = int.Parse(Console.ReadLine());
                Console.WriteLine("Lütfen ürünün miktarını girin");
                int Quantity = int.Parse(Console.ReadLine());

                var newProduct = new Product()
                {
                    Name = Name,
                    Price = Price,
                    Quantity = Quantity,
                };
                if (balance < Price * Quantity)
                {
                    Console.Clear();
                    Console.WriteLine("Yeterli bakiyeniz yok.");
                    Thread.Sleep(1000);
                    return;
                }
                else if (balance > Price * Quantity)
                {
                    Console.Clear();
                    balance -= Price * Quantity;
                    product.Add(newProduct);
                    Console.WriteLine($"Ürün başarıyla eklendi. Yeni Bakiyeniz: {balance}");
                    Thread.Sleep(1000);
                    
                }
            }

            static void ListProducts()
            {
                Console.Clear();
                var products = ProgramObjetcs.Products;
                Console.WriteLine($"{string.Join(new string('-', 20), ProgramObjetcs.Products.Select(p1 => ($"\n\nID: {p1.ID} \nÜrün İsmi: {p1.Name} \nÜrün Fiyatı: {p1.Price} \nÜrün Miktarı: {p1.Quantity}\n\n")))}\nMenüye dönmek için Enter tuşuna basın.\n");
                Console.ReadLine();

            }

            static void SellProduct(ref decimal balance)
            {
                Console.Clear();
                Console.WriteLine($"{string.Join(new string('-', 20), ProgramObjetcs.Products.Select(p1 => ($"\n\nID: {p1.ID} \nÜrün İsmi: {p1.Name} \nÜrün Fiyatı: {p1.Price} \nÜrün Miktarı: {p1.Quantity}\n\n")))}\n\n");
                Console.Write("Satmak istediğiniz ürünün ID'sini girin: ");
                int tempID = int.Parse(Console.ReadLine());
                var product = ProgramObjetcs.Products.FirstOrDefault(p1 => p1.ID == tempID);
                if (product != null)
                {
                    Console.Write("Kaç adet satmak istediğinizi girin: ");
                    int sellQuantity = int.Parse(Console.ReadLine());
                    if (product.Quantity >= sellQuantity)
                    {
                        Console.Clear();
                        product.Quantity -= sellQuantity;
                        balance += product.Price * sellQuantity;
                        Console.WriteLine($"Ürün başarıyla satıldı. Yeni bakiyeniz: {balance}");
                        Thread.Sleep(1000);

                    }
                    else if (product.Quantity < sellQuantity)
                    {
                        Console.Clear();
                        Console.WriteLine($"Malesef depoda bu üründen istediğiniz miktarda yok. Elimizdeki ürün sayısı: {product.Quantity}");
                        Thread.Sleep(1500);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Yanlış ID tuşladınız. Lütfen tekrar deneyiniz.");
                    Thread.Sleep(1000);
                }
            }

            static void AddToStock(ref decimal balance)
            {
                Console.Clear();
                Console.WriteLine($"{string.Join(new string('-', 20), ProgramObjetcs.Products.Select(p1 => ($"\n\nID: {p1.ID} \nÜrün İsmi: {p1.Name} \nÜrün Fiyatı: {p1.Price} \nÜrün Miktarı: {p1.Quantity}\n\n")))}\n\n");
                Console.Write("lütfen eklemek istediğiniz ürünün ID'sini giriniz:");
                int tempID = int.Parse(Console.ReadLine());
                var product = ProgramObjetcs.Products.FirstOrDefault(p1 => p1.ID == tempID);
                if (product != null)
                {
                    
                    Console.Write("Lütfen eklemek istediğiniz ürün miktarını giriniz:");
                    int addQuantity = int.Parse(Console.ReadLine());
                    if (balance >= addQuantity * product.Price)
                    {
                        Console.Clear();
                        product.Quantity += addQuantity;
                        balance -= addQuantity * product.Price;
                        Console.WriteLine($"Ürün başarıyla depoya eklendi. Yeni ürün miktarı: {product.Quantity}. Yeni Bakiye: {balance} ");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Yeterli bakiyeniz yok.");
                        Thread.Sleep(1000);
                        return;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Yanlış ID tuşladınız. Lütfen tekrar deneyiniz.");
                    Thread.Sleep(1000);
                }
            }

            void GetMenu()
            {
                Console.Clear();
                Console.WriteLine(Menu(ref balance));
                Console.Write("\nAna Sayfa>");

            }
        }
    }
}