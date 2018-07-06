using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDT_Test_Exercise
{
    public class Item
    {
        private string name;
        private int price;

        public Item(string name, int price)
        {
            //Constructor
            this.name = name;
            this.price = price;
        }

        public string getName()
        {
            return this.name;
        }
        public int getPrice()
        {
            return this.price;
        }
    }
}
