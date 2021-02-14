using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment1_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:
            int[] arr = { -1, -2, -3 };
            Console.WriteLine("Q4 : Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine(n4);

            //Question 5:
            //string[] emails = { "dis.email+bull@usf.com", "dis.e.mail+bob.cathy@usf.com", "disemail+david@us.f.com" };
            List<string> emails = new List<string>();
            emails.Add("dis.email+bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is:" + ans5);


            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("The destination is "+destination);

        }

        public static void printTriangle(int n)
        {

            int spaces = 1;

            for (int i = 1; i < n; i++)
            {
                //print the spaces at the beginning of each row.
                for (int k = i; k < n; k++)
                {
                    Console.Write(" ");
                }
                //printing 1 at the beginning of every row.
                Console.Write("1");

                //printing the spaces after 1 in each row.
                for (int s = 1; s <= spaces && i > 1; s++)
                {
                    Console.Write(" ");
                }
                // printing spaces and last number for each row from row 2.
                if (i > 1)
                {
                    Console.Write(i);
                    spaces += 2;
                }

                Console.WriteLine();

            }
            //for the last row
            for (int num = 1; num < n; num++)
            {
                Console.Write(num);
                Console.Write(" ");
            }
            Console.Write(n);
        }

        public static void printPellSeries(int n2)
        {
            try
            {
                //method 1
                //int[] arr = new int[n2];
                //arr[0] = 0;
                //arr[1] = 1;
                //if (n2 >= 2)
                //{
                //    for (int i = 2; i < n2; i++)
                //    {
                //        arr[i] = arr[i - 1] * 2 + arr[i - 2];

                //    }
                //}

                //for (int i = 0; i < n2 - 1; i++)
                //{
                //    Console.Write(arr[i] + " ");
                //}
                //Console.Write(arr[n2 - 1]);
                int t1 = 0;
                int t2 = 1;
                int t3;
                Console.Write("0,1,");
                for (int i = 3; i <= n2; i++)
                {
                    t3 = 2 * t2 + t1;
                    if (i < n2)
                    {
                        Console.Write(t3 + ",");
                    }
                    else
                    {
                        Console.Write(t3);
                    }

                    t1 = t2;
                    t2 = t3;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static bool squareSums(int n3)
        {
            try
            {
                if (n3 == 1)
                {
                    return true;
                }
                for (int i = 0; i <= n3/2; i++)
                {
                    for (int j = i; j <= n3/2; j++)
                    {
                        if (i*i + j*j == n3)
                        {
                            Console.WriteLine(i+" "+j);
                            return true;
                        }
                      
                    }

                }
                return false;

            }
            catch (Exception)
            {
                throw;
                
            }
        }

        public static int diffPairs(int[] nums, int k)
        {
            try
            {
                //using a dictionary to remove duplicacy of pairs.
                Dictionary<int, int> dict = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (nums[i] - nums[j] == k && j != i)
                        {
                            dict[nums[i]] = nums[j];
                        }
                    }
                }
                //returning the number of key value pairs in the dictionary.
                return dict.Count;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: "+e.Message);
                throw;
            }
           
        }

        public static string DestCity(string[,] paths)
        {
            try
            {
                int rows = paths.GetLength(0);
                string[] origins = new string[rows];
                string[] destinations = new string[rows];
                for (int i = 0; i < rows; i++)
                {
                    origins[i] = paths[i, 0];
                    destinations[i] = paths[i, 1];

                }
                for (int i = 0; i < destinations.Length; i++)
                {
                    if (!origins.Contains(destinations[i]))
                    {
                        return destinations[i];
                    }
                }
                return "Invalid Input";
            }
            catch (Exception)
            {

                throw;
            }

        }


        public static int UniqueEmails(List<string> emails)
        {
            List<string> li = new List<string>();
            foreach (string email in emails)
            {
                string local = email.Split("@")[0];
                string domain = email.Split("@")[1];
                local = local.Split("+")[0];
                local = local.Replace(".", "");
                string emailId = local + "@" + domain;
                if (!li.Contains(emailId))
                {
                    li.Add(emailId);
                }

            }
            return li.Count;

        }


    }
}
