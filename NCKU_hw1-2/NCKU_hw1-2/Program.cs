using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NCKU_hw1_2
{
    internal class Program
    {
        static bool checkAcc(int[][] arr, int account)
        {
            for(int i = 0; i < 10; i++)
            {
                if (account == arr[i][0]) return false;

            }
            return true;
        }
        static void Main(string[] args)
        {
            string action = "";
            long balance = 10000;
            long amount;
            int my_account,heart = 0,account;
            string ipt;
            int[][] default_account = new int [10000][] ;
            int[][] history = new int[10000][];
            int history_idx = 0,account_idx = 10;

            for (int i = 0; i < 10000; i++)
            {
                default_account[i] = new int[3];
                history[i] = new int[3];
            }

            for (int i = 0; i < 10; i++)
            {
                
                default_account[i][0] = 10000 + 1000 * i;
                default_account[i][1] = 10000;
            }
            Console.WriteLine("Welcome to NiCKU ATM");
            
            //account info
            while (true)
            {
                Console.WriteLine("Enter your account");
                ipt = Console.ReadLine();
                if (!int.TryParse(ipt, out my_account))//input not a number
                {
                    Console.WriteLine("Please enter a number");
                }
                else if (my_account < 10000 || my_account > 99999)
                {
                    Console.WriteLine("Account should be five digits");
                }
                else
                {
                    if (!checkAcc(default_account, my_account))
                    {
                        //account exists
                        Console.WriteLine("Already have this account, please try another one");

                    }
                    else
                    {
                        default_account[account_idx][0] = my_account;
                        default_account[account_idx++][1] = 10000;
                        break;
                    }
                }
            }


            while (action != "8")
            {
                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("\t(0)Check balance");
                Console.WriteLine("\t(1)Withdraw money");
                Console.WriteLine("\t(2)Deposit money");
                Console.WriteLine("\t(3)Transfer money");
                Console.WriteLine("\t(4)Donate");
                Console.WriteLine("\t(5)History");
                Console.WriteLine("\t(8)Exit");

                action = Console.ReadLine();
                switch (action)
                {

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
                        else if (amount < 0 || amount > 100000)
                        {
                            Console.WriteLine("Exceed the valid amount 0~100000");
                        }
                        else if (amount > balance)
                        {
                            Console.WriteLine("Exceed the existing amount");
                        }
                        else
                        {
                            //output result
                            Console.WriteLine("Successfully withdraw");
                            balance -= amount;
                            Console.WriteLine("Balance : {0}", balance);
                            history[history_idx][0] = 1;
                            history[history_idx++][1] = (int) balance;
                            default_account[10][1] = (int)balance;
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
                        else if (amount < 0 || amount > 100000)
                        {
                            Console.WriteLine("Exceed the valid amount 0~100000");
                        }
                        else
                        {
                            //output result
                            balance += amount;
                            Console.WriteLine("Balance : {0}", balance);
                            history[history_idx][0] = 2;
                            history[history_idx++][1] = (int)balance;
                            default_account[10][1] = (int)balance;
                        }
                        break;

                    case "3"://take money out, required account
                        Console.Write("Enter trasfer account : ");
                        ipt = Console.ReadLine();
                        int transfered_account = 0,transfered_account_idx=-1;
                        //check if account is valid
                        if (!int.TryParse(ipt, out account))
                        {
                            Console.WriteLine("Account should be integer");
                            break;
                        }
                        if(account == my_account)
                        {
                            Console.WriteLine("You can't transfer to yourself");
                            break;
                        }
                        if(account <10000 || account> 99999)
                        {
                            Console.WriteLine("Account must be five digits");
                            break;
                        }
                        
                        //check if account exist
                        for(int i = 0; i < account_idx; i++)
                        {
                            if (default_account[i][0] == account)
                            {
                                transfered_account_idx = i;
                                break;
                            }
                        }
                        if (transfered_account_idx == -1)
                        {
                            int keep_going;
                            //account not found, add a new account
                            Console.WriteLine("This is not a exist account, press 1 if you want to open one and keep going");
                            if (int.TryParse(Console.ReadLine(), out keep_going) && keep_going == 1)
                            {
                                default_account[account_idx][0] = account;
                                default_account[account_idx][1] = 0;
                                transfered_account_idx = account_idx++;
                            }
                        }
                        Console.Write("Enter amount : ");
                        ipt = Console.ReadLine();
                        //check type
                        if (!long.TryParse(ipt, out amount))
                        {
                            Console.WriteLine("Amount should be integer");
                        }
                        //check range
                        else if (amount < 0 || amount > 100000)
                        {
                            Console.WriteLine("Exceed the valid amount 0~100000");
                        }
                        else if (amount > balance)
                        {
                            Console.WriteLine("Exceed existing amount");
                        }
                        else
                        {
                            //output
                            if(transfered_account_idx!=-1) default_account[transfered_account_idx][1] += (int) amount;
                            Console.WriteLine(amount);
                            Console.WriteLine(transfered_account_idx);
                            if (heart > 0)
                            {
                                int keep_going;
                                Console.WriteLine("You have {0} point, do you want to use 1 point to save handling fee?",heart);
                                Console.WriteLine("\tPress 1 if you want to use");
                                if (int.TryParse(Console.ReadLine(), out keep_going) && keep_going == 1)
                                {
                                    heart--;
                                    Console.WriteLine("Final cost (+0%) = {0:D}", amount);
                                    Console.WriteLine("Successfully withdraw");
                                }
                                else
                                {
                                    amount = Convert.ToInt16(amount * 1.1);
                                    if (amount > balance)
                                    {
                                        Console.WriteLine("Exceed existing amount");
                                        continue;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Final cost (+10%) = {0:D}", amount);
                                        Console.WriteLine("Successfully withdraw");
                                    }
                                    }
                            }
                            else
                            {
                                amount = Convert.ToInt16(amount * 1.1);
                                if (amount > balance)
                                {
                                    Console.WriteLine("Exceed existing amount");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("Final cost (+10%) = {0:D}", amount);
                                    Console.WriteLine("Successfully withdraw");

                                }
                            }
                            
                            balance -= amount;
                            Console.WriteLine("Balance : {0}", balance);
                            history[history_idx][0] = 3;
                            history[history_idx++][1] = (int) balance;
                            default_account[10][1] = (int)balance;
                        }
                        break;
                    case "4"://donate
                        Console.Write("Enter amount : ");
                        ipt = Console.ReadLine();
                        //check type
                        if (!long.TryParse(ipt, out amount))
                        {
                            Console.WriteLine("Amount should be integer");
                        }
                        //check range
                        else if (amount < 0 || amount > 100000)
                        {
                            Console.WriteLine("Exceed the valid amount 0~100000");
                        }
                        else if (amount > balance)
                        {
                            Console.WriteLine("Exceed existing amount");
                        }
                        else
                        {
                            Console.WriteLine("Successfully withdraw");
                            balance -= amount;
                            heart += (int) amount / 1000;
                            Console.WriteLine("Balance : {0}", balance);
                            history[history_idx][0] = 4;
                            history[history_idx++][1] = (int)balance;
                            default_account[10][1] = (int) balance;
                        }
                        break;
                    case "5"://show history
                        Console.WriteLine("transaction history");
                        for (int i = 0; i < history_idx; i++)
                        {
                            Console.WriteLine("\t{0} - {1}", history[i][0], history[i][1]);

                        }
                        break;
                    case "8":
                        // do nothing
                        break;

                    case "65304"://show every existing accounts' balance
                        Console.WriteLine("Welcome to the banking system");
                        Console.WriteLine("Below are the existing accounts and their balances");
                        for(int i = 0; i < account_idx; i++)
                        {
                            Console.WriteLine("Account : {0} - {1}", default_account[i][0], default_account[i][1]);
                        }
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
