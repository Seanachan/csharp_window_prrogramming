using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NCKU_hw1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string action = "";
            long balance = 10000;
            long amount, account;
            string ipt; 
            Console.WriteLine("Welcome to NiCKU ATM\n\nWhat do you want to do?");
            

            while(action != "8")
            {
                Console.WriteLine("\t(0)Check balance");
                Console.WriteLine("\t(1)Withdraw money");
                Console.WriteLine("\t(2)Deposit money");
                Console.WriteLine("\t(3)Trasfer money");
                Console.WriteLine("\t(8)Exit");

                action = Console.ReadLine();
                switch (action) {
                    
                    case "0"://show balance
                        Console.WriteLine("Balance : {0}", balance);
                        break;

                    case "1"://take money out
                        Console.Write("Enter amount : ");
                        ipt = Console.ReadLine();
                        //check type
                        if (!long.TryParse(ipt, out amount))
                        {
                            Console.WriteLine("Amount should be integer");
                        }
                        //check range
                        else if (amount<0 ||  amount>100000)
                        {
                            Console.WriteLine("Exceed the valid amount 0~100000");
                        }
                        else if(amount>balance){
                            Console.WriteLine("Exceed the existing amount");
                        }
                        else
                        {
                            //output result
                            Console.WriteLine("Successfully withdraw");
                            balance -= amount;
                            Console.WriteLine("Balance : {0}", balance);

                        }
                        break;

                    case "2"://deposit
                        Console.Write("Enter amount : ");
                        ipt = Console.ReadLine();
                        //check type
                        
                        if (!long.TryParse(ipt, out amount))
                        {
                            Console.WriteLine("Amount should be integer");
                        }
                        //check range
                        else if (amount<0 ||  amount>100000)
                        {
                            Console.WriteLine("Exceed the valid amount 0~100000");
                        }
                        else
                        {
                            //okutput result
                            balance += amount;
                            Console.WriteLine("Balance : {0}", balance);

                        }
                        break;
                        
                    case "3"://take money out, required account
                        Console.Write("Enter trasfer account : ");
                        ipt = Console.ReadLine();
                        //check if account is valid
                        if (!long.TryParse(ipt, out account))
                        {
                            Console.WriteLine("Account should be integer");
                            break;
                        }

                        Console.Write("Enter amount : ");
                        ipt = Console.ReadLine();
                        //check type
                        if (!long.TryParse(ipt, out amount))
                        {
                            Console.WriteLine("Amount should be integer");
                        }
                        //check range
                        else if (amount<0 ||  amount>100000)
                        {
                            Console.WriteLine("Exceed the valid amount 0~100000");
                        }
                        else if (amount> balance)
                        {
                            Console.WriteLine("Exceed existing amount");
                        }
                        else
                        {
                            //output'
                            amount  = Convert.ToInt16(amount*1.1);
                            Console.WriteLine("Final cost (+10%) = {0:D}", amount);
                            Console.WriteLine("Successfully withdraw");
                            Console.WriteLine("Balance : {0}", balance-amount);
                        }
                        break;

                    case "8":
                        // do nothing
                        break;

                    default:
                        if (long.TryParse(action, out amount)) Console.WriteLine("There's no option");
                        else Console.WriteLine("Please enter a number");
                        break;
                }
                
            }
        }
    }
}
