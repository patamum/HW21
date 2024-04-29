namespace Task21_2
{
    internal class Program
    {
        const int n = 5;
        static int[,] land = new int[n, n];
        static void Main(string[] args)
        {
            FillPlan();
            Console.WriteLine();
            
            ThreadStart threadStart = new ThreadStart(Gardener1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardener2();
            GetPlan();
        }
    
        static void FillPlan()
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    land[i, j] = rnd.Next(0, 50);
                    Console.Write("{0:00 } ", land[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void GetPlan()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0} ", land[i, j]);
                }
                Console.WriteLine();
            }

        }
        static void Gardener1()
        {
            int row = 0;
            for (int i = 0; i < n; i++)
            {
                row++;
                if (row%2 == 0)
                {
                    for (int j = n-1; j >= 0; j--)
                    {
                        if (land[i, j] >= 0)
                        {
                            int delay = land[i, j];
                            land[i, j] = -1;
                            Thread.Sleep(delay);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (land[i, j] >= 0)
                        {
                            int delay = land[i, j];
                            land[i, j] = -1;
                            Thread.Sleep(delay);
                        }
                    }
                }
                
            }
        }
        static void Gardener2()
        {           
            int column = 0;
            for ( int i = n-1; i >= 0;  i--)
            {           
                column ++;
                if (column % 2 == 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (land[j, i] >= 0)
                        {
                            int delay = land[j, i];
                            land[j, i] = -2;
                            Thread.Sleep(delay);
                        }
                    }
                }
                else
                {
                    for (int j = n - 1; j >= 0; j--)
                    {
                        if (land[j, i] >= 0)
                        {
                            int delay = land[j, i];
                            land[j, i] = -2;
                            Thread.Sleep(delay);
                        }
                    }
                }               
            }
        }
    }
}