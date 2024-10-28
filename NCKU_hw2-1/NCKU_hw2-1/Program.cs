using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKU_hw2_1
{
    internal class Program
    {
        static void showOptionMessage()
        {
            Console.WriteLine("歡迎來到 NCKU 卡比商店交易系統");
            Console.WriteLine("======================================");
            Console.WriteLine("(1) 開店");
            Console.WriteLine("(2) 新增訂單");
            Console.WriteLine("(3) 查詢庫存");
            Console.WriteLine("(4) 查詢總收入");
            Console.WriteLine("(5) 計算人氣商品排名");
            Console.WriteLine("(6) 關店");
            Console.WriteLine("======================================");
        }
        
        static void Main(string[] args)
        {
            string action="";
            bool terminate = false;
            int numOfProd = 1,income=0;
            string[] items = new string[numOfProd];
            int[] price, numOfItems;
            int[] numOfBought= new int[numOfProd]; ;
            int[] indices= new int[numOfProd];

            price = new int[numOfProd];
            numOfItems = new int[numOfProd];

            while (!terminate)
            {
                showOptionMessage();
                Console.Write("請輸入您現在想要進行的操作: ");
                action = Console.ReadLine().Trim();
                switch (action)
                {
                    case "1":
                        //open the shop
                        string[] ipt;
                        Console.Write("請輸入今日總共有幾種商品要販售: ");
                        //using console.read() can cause the input not waiting
                        numOfProd = int.Parse(Console.ReadLine());
                        items = new string[numOfProd];
                        price = new int[numOfProd];
                        numOfItems = new int[numOfProd];
                        numOfBought = new int[numOfProd];
                        indices = new int[numOfProd];
                        for (int i = 0; i<numOfProd; i++)
                        {
                            indices[i] = i;
                        }

                        Console.Write("請依序輸入每一種商品的名稱: ");
                        //split the string
                        items = Console.ReadLine().Trim().Split(new char[] {' '});
                        Console.Write("接下來，請你依序輸入每一個商品的價格: ");
                        //split the stringd
                        ipt = Console.ReadLine().Trim().Split(new char[] { ' ' });
                        price =Array.ConvertAll(ipt, s => int.Parse(s));

                        Console.Write("\n輸入完成! 每一種商品的價格依序為: \n");
                        for( int i = 0;i< price.Count(); i++)
                        {
                            Console.WriteLine("{0}: {1}", items[i], price[i]);
                        }

                        Console.Write("\n最後，請你依序輸入每一個商品目前的庫存數量: ");
                        //split the string
                        ipt = Console.ReadLine().Trim().Split(new char[] { ' ' });
                        numOfItems =Array.ConvertAll(ipt, s => int.Parse(s));

                        Console.Write("\n輸入完成! 每一種商品的庫存數量依序為: \n");
                        for (int i = 0; i< numOfProd; i++)
                        {
                            Console.WriteLine("{0}: {1}", items[i], numOfItems[i]);
                        }

                        Console.WriteLine("\n開店程序完成，已開店\n");
                        break;

                    case "2":
                        //buy prods
                        int[] numOfBuy;
                        bool check = true;
                        Console.Write("請依序輸入此訂單每一種類的商品各需要買幾個: ");
                        ipt = Console.ReadLine().Trim().Split(new char[] {' '});
                        numOfBuy = Array.ConvertAll(ipt,s=> int.Parse(s));
                        for (int i = 0; i<numOfProd; i++)
                        {
                            if (numOfBuy[i]>numOfItems[i])
                            {
                                Console.WriteLine("\n庫存不足，此筆訂單不成立\n");
                                check =false;
                            }
                        }
                        if (check)
                        {
                            int total = 0,paid=0;
                            for (int i = 0; i<numOfProd; i++)
                            {
                                total += price[i]*numOfBuy[i];
                            }
                            Console.Write("\n訂單成立!，總金額為: {0} ",total.ToString());
                            Console.Write("請輸入消費者付款金額: ");
                            
                            while (true)
                            {
                                paid = int.Parse(Console.ReadLine());
                                if (paid==-1)
                                {
                                    Console.WriteLine("訂單取消\n");
                                    break;
                                }
                                if (paid<total)
                                {
                                    Console.Write("\n付款金額不足，請再輸入一次 (或輸入 -1 直接取消此筆訂單): ");
                                }
                                else
                                {
                                    Console.Write("\n付款完成! 請找零消費者共 {0} 元",(paid-total).ToString());
                                    for(int i = 0; i<numOfProd; i++)
                                    {
                                        numOfItems[i]-=numOfBuy[i];
                                    }
                                    for(int i = 0;i<numOfProd; i++)
                                    {
                                        for(int j = 0; j<numOfProd; j++)
                                        {
                                            if (indices[j]==i)
                                            {
                                                numOfBought[j]+=numOfBuy[i];
                                                break;
                                            }
                                        }
                                    }
                                    income+=total;
                                    break;
                                }
                            }
                            
                        }
                        break;

                    case "3":
                        //check num of prods remainning
                        bool insufficient = false;
                        for(int i = 0; i<numOfProd; i++)
                        {
                            if (numOfItems[i]<=5)
                            {
                                insufficient = true;
                            }
                            Console.WriteLine("{0}: {1}", items[i], numOfItems[i]);
                        }
                        if (insufficient)
                        {
                            Console.WriteLine("有商品的庫存數量不足!!!");
                        }
                            break;

                    case "4":
                        //show total income
                        Console.WriteLine("總收入為: {0}", income);
                        break;

                    case "5":
                        Array.Sort(numOfBought, (v1, v2) =>
                        {
                            // First compare the values of numOfBought
                            int comparison = v1.CompareTo(v2);

                            // If the values are equal, we assume that you want to break the tie using the "indices" array
                            if (comparison == 0)
                            {
                                // Here you need to access indices corresponding to v1 and v2
                                int index1 = Array.IndexOf(numOfBought, v1);
                                int index2 = Array.IndexOf(numOfBought, v2);

                                // Now compare the corresponding indices
                                comparison = indices[index1].CompareTo(indices[index2]);
                            }

                            return comparison;
                        });

                        Array.Reverse(numOfBought);
                        Array.Reverse(indices);
                        Console.Write("人氣商品排行榜:\n");
                        for(int i = 0; i<numOfProd; i++)
                        {
                            Console.WriteLine("第{0}名: {1}, 總購買數量共{2} 次", i+1, items[indices[i]], numOfBought[i]);
                        }
                        Console.Write("\n\n");
                        break;

                    case "6":
                        terminate=true;
                        break;

                    default:

                        break;
                }
            }
        }

    }
}
