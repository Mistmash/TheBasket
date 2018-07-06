using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDT_Test_Exercise
{


    class JDT_Test_Exercise
    {

        static void Main(string[] args)
        {   
            //Create global variables 
            bool quit = false;
            Basket basket = new Basket();
            String[] priceList;
            String[,] splitList;
            try
            {
                //Extract price list from .txt file
                //Possibly needs to be changed depending on the repository
                string path = System.AppDomain.CurrentDomain.BaseDirectory;
                path = (path + "Prices.txt");
                priceList = System.IO.File.ReadAllLines(path);
                //Build the two dimentional array allowing extraction of name and price seperately
                splitList = new String[priceList.Length, 2];
                for (int i = 0; i < priceList.Length; i++)
                {
                    splitList[i, 0] = priceList[i].Split(',')[0];
                    splitList[i, 1] = priceList[i].Split(',')[1];
                }
            }
            catch (Exception e)
            {
                //If price list .txt can't be found then quit the program
                Console.WriteLine("Error reading Prices.txt");
                Console.ReadKey();
                priceList = null;
                splitList = null;
                quit = true;
            }
            //Loop the main menu
            while (!quit)
            {
                //Take input from menu method switch on it
                int input = mainMenu();
                switch (input)
                {
                    case Constants.ADDITEM:
                        Console.Clear();
                        Console.WriteLine("1) Add item to Basket");
                        Console.WriteLine("Enter name of item");
                        string newItem = Console.ReadLine();
                        //Read an item name in through command line
                        int itemPrice;
                        //Check if the item name exists in the array and return/assign it's location
                        int itemLine = (inStock(newItem, splitList));
                        if(itemLine < (splitList.Length / 2))
                        {
                            if (Int32.TryParse(splitList[itemLine, 1], out itemPrice))
                            {
                                //Add the new item to the basket's list of items
                                basket.addItem(newItem, itemPrice);
                                Console.WriteLine("Item added to basket");
                            }
                            else
                            {
                                //Parse error from text file
                                Console.WriteLine("Error reading price");
                            }
                        } else {
                            //Cannot find the item in the text file
                            Console.WriteLine("This item is not available");
                        }
                        Console.ReadKey();
                        break;
                    case Constants.SAMEITEM:
                        //Add the last item added again
                        if (!basket.sameItem())
                        {
                            Console.WriteLine("Error: No items in Basket");
                        }
                        else
                        {
                            Console.WriteLine("Last Item in Basket has been added");
                        }
                        Console.ReadKey();
                        break;
                    case Constants.CONTENTS:
                        //Display all items in basket
                        Console.Clear();
                        Console.WriteLine("3) Get contents of Basket");
                        //Write to console each item in the basket
                        for (int i = 0; i < basket.getContents().Count; i++)
                        {
                            Console.WriteLine(basket.getContents()[i].getName());
                        }
                        Console.WriteLine("Press any key to return");
                        Console.ReadKey();
                        break;
                    case Constants.TOTAL:
                        //Display total cost of items in basket
                        Console.WriteLine("The total price of the basket is £" + (basket.getTotal() / 100).ToString("F"));
                        Console.WriteLine("Press any key to return");
                        Console.ReadKey();
                        break;
                    case Constants.QUIT:
                        //Break loop and quit program
                        quit = true;
                        break;
                }
            }
        }

        static int mainMenu()
        {
            int input;
            bool invalid = false;
            //Loop menu until a correct input is returned
            while (true)
            {
                //Display the main menu
                Console.Clear();
                Console.WriteLine("Shopping Basket Application Menu");
                Console.WriteLine("1) Add item to Basket");
                Console.WriteLine("2) Add same item to Basket");
                Console.WriteLine("3) Get contents of Basket");
                Console.WriteLine("4) Get total cost of Basket");
                Console.WriteLine("5) Quit");
                //If ivalid input entered, display error message
                if (invalid)
                {
                    Console.WriteLine("Invalid input, enter number 1-5");
                }
                //If input is correct then return it as an integer
                if(Int32.TryParse(Console.ReadLine(), out input))
                {
                    if (input == Constants.ADDITEM || input == Constants.SAMEITEM || input == Constants.CONTENTS || input == Constants.TOTAL || input == Constants.QUIT)
                    {
                        invalid = false;
                        return input;
                    }
                    else
                    {
                        //If input is not 1-5 then flag as invalid
                        invalid = true;
                    }
                }
                else
                {
                    //If string cannot be parsed as integer then flag as invalid
                    invalid = true;
                }
            }
        }

        static void displayContents(List<Item> contents)
        {
            Console.Clear();
            Console.WriteLine("Contents of Basket:");
           //Write to console each item in the basket
            for (int i = 0; i < contents.Count; i++)
            {
                Console.WriteLine(contents[i].getName());
            }
            Console.WriteLine("Pres any key to return");
            Console.ReadLine();
        }

        static int inStock(string newItem, string[,] splitList)
        {
            int i;
            //Search array for a specific item name and return the element it is found in or the length if it is not
            for (i = 0; i < (splitList.Length/2); i++)
            {
                if(newItem.ToLower().Equals((splitList[i,0]).ToLower()))
                {
                    return i;
                }
            }
            return i;
        }
    }

}
