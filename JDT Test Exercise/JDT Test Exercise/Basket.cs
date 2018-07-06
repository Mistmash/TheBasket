using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT_Test_Exercise
{
    public class Basket
    {
        private List<Item> contents;

        public Basket()
        {
            //Constructor
            this.contents = new List<Item>();
        }

        public List<Item> getContents()
        {
            return this.contents;
        }

        public double getTotal()
        {
            int total = 0;
            foreach (Item item in this.contents)
            {
                total += item.getPrice();
            }
            //add cost of each item in contents and return total
            return total;
        }

        public void addItem(string name, int price)
        {
            //Add item to list of array of items
            contents.Add(new Item(name, price));
        }

        public bool sameItem()
        {
            //Duplicate last item in array of items
            try
            {
                this.addItem(contents.Last().getName(), contents.Last().getPrice());
                return true;
            } catch
            {
                //If array is empty then return false
                return false;
            }
        }
    }
}
