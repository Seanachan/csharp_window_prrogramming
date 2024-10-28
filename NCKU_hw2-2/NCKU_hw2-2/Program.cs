using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NCKU_hw2_2
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
            string action = "";
            bool terminate = false,open=false;
            int numOfProd = 1, income = 0;
            string[] items = new string[numOfProd];
            string ipt_string;
            int[] price, numOfItems;
            int[] numOfBought = new int[numOfProd]; ;
            int[] indices = new int[numOfProd];
            Dictionary<string, List<int>> client=new Dictionary<string,List<int>>();
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
                        ipt_string = Console.ReadLine().Trim();
                        if(!Regex.IsMatch(ipt_string, "^[0-9]+$"))
                        {
                            Console.Write("請確保輸入沒有空格或非法符號!\n");
                            Console.Write("請重新開店!\n\n");
                            break;
                        }
                        numOfProd = int.Parse(ipt_string);
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
                        items = Console.ReadLine().Trim().Split(new char[] { ' ' });
                        if (items.Length!=numOfProd)
                        {
                            Console.Write("輸入商品數量的序列長度不等於商品總數!\n");
                            Console.Write("請重新開店！\n\n");
                            break;
                        }
                        
                        
                        Console.Write("接下來，請你依序輸入每一個商品的價格: ");

                        //split the string
                        ipt_string = Console.ReadLine();

                        if (!Regex.IsMatch(ipt_string, "^([0-9]+[\\s]*)+$"))
                        {
                            Console.Write("請確保輸入的每一筆資料為正整數，且不含 + 號\n");
                            Console.Write("請重新開店！\n\n");
                            break;
                        }
                            
                        ipt = ipt_string.Trim().Split(new char[] { ' ' });
                        if (ipt.Length!=numOfProd)
                        {
                            Console.Write("輸入價格數量的序列長度不等於商品總數!\n");
                            Console.Write("請重新開店！\n\n");
                            break;
                        }
                        price =Array.ConvertAll(ipt, s => int.Parse(s));

                        Console.Write("\n輸入完成! 每一種商品的價格依序為: \n");
                        for (int i = 0; i< price.Count(); i++)
                        {
                            Console.WriteLine("{0}: {1}", items[i], price[i]);
                        }

                        Console.Write("\n最後，請你依序輸入每一個商品目前的庫存數量: ");
                        //split the string
                        
                        ipt_string = Console.ReadLine();

                        if (!Regex.IsMatch(ipt_string, "^([0-9]+[\\s]*)+$"))
                        {
                            Console.Write("請確保輸入的每一筆資料為正整數，且不含 + 號\n");
                            Console.Write("請重新開店！\n\n");
                            break;
                        }
                            
                        ipt = ipt_string.Trim().Split(new char[] { ' ' });
                        if (ipt.Length!=numOfProd)
                        {
                            Console.Write("輸入庫存數量的序列長度不等於商品總數!\n");
                            Console.Write("請重新開店！\n\n");
                            break;
                        }
                        numOfItems =Array.ConvertAll(ipt, s => int.Parse(s));

                        Console.Write("\n輸入完成! 每一種商品的庫存數量依序為: \n");
                        for (int i = 0; i< numOfProd; i++)
                        {
                            Console.WriteLine("{0}: {1}", items[i], numOfItems[i]);
                        }

                        Console.WriteLine("\n開店程序完成，已開店\n");
                        open = true;
                        break;

                    case "2":
                        if (!open)
                        {
                            Console.WriteLine("還沒開店，請勿使用除了關店以外的指令！\n");
                            break;
                        }
                        //buy prods
                        int[] numOfBuy;
                        bool check = true;
                        string name;
                        bool keep_input = false;
                        Console.Write("請依序輸入此訂單每一種類的商品各需要買幾個: ");
                        ipt = Console.ReadLine().Trim().Split(new char[] { ' ' });
                        if (ipt.Length!=numOfProd)
                        {
                            Console.Write("輸入商品購買數量的序列長度不等於商品總數!\n");
                            Console.Write("請重新輸入或是輸入 -1 取消訂單");
                            keep_input = true;
                        }
                        while (keep_input)
                        {
                            ipt = Console.ReadLine().Trim().Split(new char[] { ' ' });
                            if (ipt[0]=="-1" &&ipt.Length==1)
                            {
                                check=false;
                                keep_input=false;
                                break;
                            }
                            if (ipt.Length==numOfProd) {  break; }

                            Console.Write("輸入商品購買數量的序列長度不等於商品總數!\n");
                            Console.Write("請重新輸入或是輸入 -1 取消訂單");
                        }
                        if (!check) break;
                        numOfBuy = Array.ConvertAll(ipt, s => int.Parse(s));
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
                            int total = 0, paid = 0;
                            for (int i = 0; i<numOfProd; i++)
                            {
                                total += price[i]*numOfBuy[i];
                            }
                            Console.Write("\n訂單成立!，總金額為: {0} ", total.ToString());
                            if (total>=1000)
                            {
                                //discount
                                Random rnd = new Random();
                                int x = rnd.Next(1, 10);
                                total = (int)(total *0.1*x);
                                Console.Write("因訂單滿1000元，因此總金額打{0}折，打折後為{1}元 ", x, total);
                            }
                            Console.Write("請輸入消費者付款金額: ");
                            bool show_notice = false;
                            while (true)
                            {
                                //paid = int.Parse(Console.ReadLine());
                                ipt_string = Console.ReadLine();

                                if (ipt_string=="-1"&&show_notice)
                                {
                                    Console.WriteLine("訂單取消\n");
                                    break;
                                }

                                if (Regex.IsMatch(ipt_string, "^[-+]?[0-9]*\\.+[0-9]+$"))
                                {
                                    //invalid paid amount
                                    Console.Write("請確保輸入金額是正整數，請再輸入一次 （或輸入 -1 直接取消此筆訂單）: ");
                                    show_notice = true;
                                    continue;//keep input
                                }

                                paid = int.Parse(ipt_string);
                                if (paid<total)
                                {
                                    Console.Write("\n付款金額不足，請再輸入一次 (或輸入 -1 直接取消此筆訂單): ");
                                    show_notice = true;
                                }
                                else
                                {
                                    Console.Write("\n付款完成! 請找零消費者共 {0} 元\n", (paid-total).ToString());
                                    income+=total;
                                    //subtract the stock's amount
                                    for (int i = 0; i<numOfProd; i++)
                                    {
                                        numOfItems[i]-=numOfBuy[i];
                                    }
                                    //add the amount to ranking 
                                    for (int i = 0; i<numOfProd; i++)
                                    {
                                        for (int j = 0; j<numOfProd; j++)
                                        {
                                            if (indices[j]==i)
                                            {
                                                numOfBought[j]+=numOfBuy[i];
                                                break;
                                            }
                                        }
                                    }
                                    //client's info
                                    Console.Write("請輸入消費者的名字: ");
                                    
                                    while (true)
                                    {
                                        name = Console.ReadLine().Trim();
                                        if (!Regex.IsMatch(name, "^([a-zA-Z]+[\\s]*)+$"))
                                        {
                                            //invalid name
                                            Console.Write("請確保名字是由大寫或小寫英文字母組成（名字可以含有空格，如：Sean Pai是一組合法的名字）");

                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    if (!client.ContainsKey(name))
                                    {
                                        //new client, add it
                                        client.Add(name, new List<int>());   
                                    }

                                    client[name].Add(total);

                                    Console.Write("消費者{0} 歷史資訊: \n\n",name);
                                    Console.Write("此消費者歷史訂單中，最大的金額為: {0} 元\n", client[name].Max());

                                    int length = client[name].Count();
                                    for (int i = 0; i<3; i++)
                                    {
                                        if (length-i-1<0)
                                        {
                                            Console.Write("近期交易 {0}: {1}\n", i+1, 0);

                                        }
                                        else
                                        {
                                            Console.Write("近期交易 {0}: {1}\n", i+1, client[name][length-1-i]);
                                        }
                                    }
                                    Console.Write('\n');
                                    
                                    break;
                                }
                            }
                        }
                        break;

                    case "3":
                        if (!open)
                        {
                            Console.WriteLine("還沒開店，請勿使用除了關店以外的指令！\n");
                            break;
                        }
                        //check num of prods remainning
                        bool insufficient = false;
                        for (int i = 0; i<numOfProd; i++)
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
                        if (!open)
                        {
                            Console.WriteLine("還沒開店，請勿使用除了關店以外的指令！\n");
                            break;
                        }
                        //show total income
                        Console.WriteLine("總收入為: {0}", income);
                        break;

                    case "5":
                        if (!open)
                        {
                            Console.WriteLine("還沒開店，請勿使用除了關店以外的指令！\n");
                            break;
                        }
                        Array.Sort(numOfBought, (v1, v2) =>
                        {
                            // First compare the values of numOfBought
                            int comparison = v1.CompareTo(v2);

                            // If the values are equal
                            if (comparison == 0)
                            {
                                // Here access indices corresponding to v1 and v2
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
                        for (int i = 0; i<numOfProd; i++)
                        {
                            Console.WriteLine("第{0}名: {1}, 總購買數量共{2} 次", i+1, items[indices[i]], numOfBought[i]);
                        }
                        Console.Write("\n\n");
                        break;

                    case "6":
                        terminate=true;
                        break;

                    default:
                        Console.WriteLine("未有此指令，請重新輸入");
                        break;
                }
            }
        }

    }
}