using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitLessonsSharonSefi
{
    //Item class ד
    public class Item
    {
        // Item name
        public string itemName;
        // Item decsription
        public string itemDesc;
        // Item price
        public double itemPrice;
        // Item image URL
        public string itemImage;

        // Cart button - boolean, if true "Add to cart" should be clicked. if false, "Remove" button is there and should not be clicked.
        // Maybe future idea, not part of item constructor currently!
        public bool hasAddToCart;


        // Item constructor
        public Item(string itemName, string itemDesc, double itemPrice, string itemImage)
        {
            this.itemName = itemName;
            this.itemDesc = itemDesc;
            this.itemPrice = itemPrice;
            this.itemImage = itemImage;
        }

        // Add to cart logic idea, not relevant right now
        public void clickAddToCart()
        {
            if (hasAddToCart)
            {
                //click button
            }
            else { }
            //no click
        }
    }
}
