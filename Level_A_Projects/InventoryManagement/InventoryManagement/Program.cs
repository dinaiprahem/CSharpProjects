namespace InventoryManagement
{
    internal class Program
    {
        static int productCount = 0;
        static string[,] inventory = new string[50, 3];
        static void Main(string[] args)
        {
            //add product
            //view products 
            //update product 
            //exit
            while (true) { 
            Console.WriteLine("welcome to inventory system,choose a number!!");
            Console.WriteLine("==================================================");
            Console.WriteLine("1. add product ");
            Console.WriteLine("2. view products");
            Console.WriteLine("3. update product");
            Console.WriteLine("4. exit the system");
            int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //add product
                        addProduct();
                        break;
                    case 2:
                        //view products
                        viewProducts();
                        break;
                    case 3:
                        //update product
                        updateProduct();
                        break;
                    case 4:
                        //exit the system
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("please enter number from 1 to 4");
                        break;
                }
      }
        }
        private static void addProduct()
        {
            Console.WriteLine("Enter The Product Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter The Product Quantity");
            string quant = Console.ReadLine();
            Console.WriteLine("Enter The Product Price");
            string price = Console.ReadLine();
            inventory[productCount, 0] = name;
            inventory[productCount,1] = quant;
            inventory[productCount, 2] = price;
            productCount++;
            Console.WriteLine("product Added Successfully!");
        }
        private static void viewProducts()
        {
            Console.WriteLine("the products list :");
            if (productCount < 0)
            {
                Console.WriteLine("There Is No Products Found");
            }
            else
            {
                for (int i = 0; i < productCount; i++)
                {
                    Console.WriteLine($"product id is : {i + 1} ,product name is : {inventory
               [i, 0]}, product Quantity is :{inventory[i, 1]} ,product price is :{inventory[i, 2]}");

                }
            }
        }
        private static void updateProduct()
        {
            Console.WriteLine("Enter THe Name Of Product U Want To Update");
            string name = Console.ReadLine();
            int id = -1;
            if (productCount < 0)
            {
                Console.WriteLine("There Is No Products Found");
            }
            else
            {
                for (int i = 0; i < productCount; i++)
                {
                    if (name == inventory[i, 0])
                    {
                        id = i;
                        break;
                    }
                }
                if (id < 0)
                {
                    Console.WriteLine("Product Not Found ! Please Make Sure From The Product Name");

                }
                else
                {
                    Console.Write("Enter THe New Quantity:");
                    string q = Console.ReadLine();
                    inventory[id, 1] = q;
                    Console.WriteLine("product updated successfully !");
                    Console.WriteLine("===================================");
                    Console.WriteLine("After Update :");
                    Console.WriteLine($"product id is : {id + 1} ,product name is : {inventory
                   [id, 0]}, product Quantity is :{inventory[id, 1]}, product price is :{inventory[id, 2]}");


                }
            }

        }
    }
}
