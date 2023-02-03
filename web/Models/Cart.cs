using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class Cart
    {
        private List<ItemDetail> items = new List<ItemDetail>();
        public int AddToCart(ItemDetail item) 
        {
            bool found = false;
            foreach (ItemDetail i in items)
            {
                if (i.productDetai.Product_ID == item.productDetai.Product_ID)
                {
                    i.Quantity += item.Quantity;
                    found = true;
                }
            }
            if (!found)
            {
                items.Add(item);
            }
            return items.Count;
        }

        //public int RemoveCart(ItemDetail item)
        //{
            
        //    if (item != null) 
        //    {
        //        item.productDetai.
        //    }
        //    return items.Count;
        //}
        public int? getTotal()
        {
            int? total = 0;
            foreach (ItemDetail i in items)
            {
                total += i.productDetai.Product_price * i.Quantity; 
            }
            return total;
        }
        public List<ItemDetail> getAllItems() 
        {
            return items;
        }
    }
}