using System.Diagnostics;

namespace TaskTracker
{
    internal class Program
    {
        static string[] tasks = new string[100];
       static int taskIndex = 0;
        static void Main(string[] args)
        {
            // welcome the user
            // 2 ask for whick number want 
            // 1- add task 
            //2- view tasks 
            //3-remove tasks 
            //4- mark on task 
            //5 -exit 
            Console.WriteLine("welcome to task tracker ");
            Console.WriteLine("*******************************");
            while (true)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(" please choice number from 1 to 5");
                Console.WriteLine("1.add task");
                Console.WriteLine("2.view tasks");
                Console.WriteLine("3.remove task");
                Console.WriteLine("4.mark on task ");
                Console.WriteLine("5.to exit this program");
                int taskNumber = int.Parse(Console.ReadLine());
                switch (taskNumber)
                {
                    case 1:
                        addTask();
                        break;
                    case 2:
                        //view tasks ;
                        viewTask();
                        break;
                    case 3:
                        //remove task ;
                        removeTask();
                        break;
                    case 4:
                        //mark task ;
                        markTask();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("please enter number from 1 to 5 only");
                        break;

                }
            }
           
        }
        private static void addTask ()
        {
            Console.Write("please enter the task title :");
            string task =Console.ReadLine();
            tasks[taskIndex] = task;
            taskIndex++;
            Console.WriteLine("task added successfully");
        }
        private static void viewTask()
        {
            Console.WriteLine("all tasks list :");
            for (int i = 0; i < taskIndex; i++)
            {
                Console.WriteLine($"{i + 1} task title : {tasks[i]}");

            }
        }
        private static void removeTask()
        {
            Console.WriteLine("enter the task number u want to delete ");
            Console.WriteLine("there is all your tasks");
            viewTask();
            int ind = int.Parse(Console.ReadLine())-1;
            tasks[ind] = string.Empty;
            Console.WriteLine("task deleted successfully !");


        }
        private static void markTask()
        {
            Console.WriteLine("enter the task number that completed");
            Console.WriteLine("there is all your tasks");
            viewTask();
            int ind = int.Parse(Console.ReadLine()) - 1;
            tasks[ind] = tasks[ind] + " ---> completted ";
        }
    }
}
