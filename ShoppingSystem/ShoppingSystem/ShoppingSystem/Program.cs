
using System.Xml.Xsl;

namespace ShoppingSystem
{
    internal class Program
    {
        static Dictionary<string, double> products = new Dictionary<string, double>()
        { { "tv",50000},
            {"table",20000 },
            {"Blouse",520 },
              {"Camera",1520 }
        };
        static List<string> cartItems=new List<string>();
        static Stack<string> actions = new Stack<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Shopping System!");

            while (true)
            {
                Console.WriteLine("\n======================\n");
                Console.WriteLine("Choose Option !");
                Console.WriteLine("1. Add Item To The Cart");
                Console.WriteLine("2. View Cart Items");
                Console.WriteLine("3. Remove Item From The Cart");
                Console.WriteLine("4. CheckOut");
                Console.WriteLine("5. Undo Action");
                Console.WriteLine("6. EXIT from the system");

                int x = int.Parse(Console.ReadLine());
                switch(x)
                {
                    case 1:
                        AddItem();
                        break;
                    case 2:
                        ViewCartItems();
                        break;
                    case 3:
                        RemoveItem();
                       
                        break;
                    case 4:
                       CheckOut();
                        break;
                    case 5:
                        UndoAction();
                        break;
                    case 6:
                        Environment.Exit(0); 
                        break;
                    default:
                        Console.WriteLine("Invalid Number ! Enter Number From 1 to 6");
                        break;

                }
            }
        }

        private static void AddItem()
        {
            Console.WriteLine("\nAll Available Items :");
            foreach (var item in products)
            {
                Console.WriteLine($"Item : {item.Key} , Price : {item.Value} ");
            }
            Console.WriteLine("\nEnter Item Name You Want To Add In Cart");
            string i = Console.ReadLine();

            if (products.ContainsKey(i))
            {
                cartItems.Add(i);
                actions.Push($"Item {i} Added To Cart");
                Console.WriteLine($"\nitem {i} added to your cart");

            }
            else
            {
                Console.WriteLine($"\nitem {i} is out of stoke or not available");

            }
            
        }
        private static void ViewCartItems()
        {
            var x = itemsPrice();
            if(cartItems.Any())// if cart contain any items
            {
                Console.WriteLine("\nYour Cart Items Are :");
                foreach (var item in x)
                {
                    Console.WriteLine($"Item : {item.Item1} Price : {item.Item2}");
                }

            }
            else
            {
                Console.WriteLine($"\nCart Is Empty");
            }
        }
        private static IEnumerable<Tuple<string, double>> itemsPrice()
        {
            List<Tuple<string,double>> tuples = new List<Tuple<string,double>>();
            if(cartItems.Any())
           { 
                foreach (var item in cartItems)
                {
                    double price = 0;
                    bool find=products.TryGetValue(item, out price) ; //return true if item found
                    if (find)
                    {
                        Tuple<string, double> t = new Tuple<string, double>(item, price);
                        tuples.Add(t); 
                    }
                }
            }
            return tuples;
        }
        private static void RemoveItem()
        {
            ViewCartItems();
            if (cartItems.Any())
            {
                Console.WriteLine("Select Product U Want To Remove From Your Shopping Cart");
                string item = Console.ReadLine();
                if (cartItems.Contains(item))
                {
                    cartItems.Remove(item);
                    actions.Push($"Item {item} Removed From Cart");
                    Console.WriteLine($"\n{item} removed from your shopping cart");
                }

            }
        }
        private static void CheckOut()
        {
            if (cartItems.Any())
            {
                
                var items = itemsPrice();
                double sum = 0;
                foreach (var v in items)
                {
                    sum += v.Item2;
                    Console.WriteLine(v.Item1 + " " + v.Item2);
                }
                Console.WriteLine($"Your Products Total Price :{sum}"); 
                 Console.WriteLine($"proceed to pay them ! THANK YOU FOR SHOPPING WITH US");
                cartItems.Clear();
                actions.Push($"Checkout");

            }
            else
            {
                Console.WriteLine("No Items Found In The Shopping Cart");
            }
        }
        private static void UndoAction()
        {
            if (actions.Count>0)
            {
                string ac= actions.Pop();
                Console.WriteLine($"Your Last Action Is {ac}");
                var actionsarray = ac.Split();
           
               if(ac.Contains("Added"))
                {

                    cartItems.Remove(actionsarray[1]);  // Remove item added in the last action
                    Console.WriteLine($"{actionsarray[1]} has been removed from the cart.");
                }
                else if (ac.Contains("Removed"))
                {
      
                    cartItems.Add(actionsarray[1]);  // Add back the item removed in the last action
                    Console.WriteLine($"{actionsarray[1]} has been added back to the cart.");
                }
                else
                {
                    Console.WriteLine("Checkout cant be undo , please ask for refund");
                }
            }
            else
            {
                Console.WriteLine("No actions to undo.");
            }
            
           
        }
       
        
    }
}
