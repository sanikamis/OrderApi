using OrderBusinessLogic.Models;
using System;

namespace OrderBusinessLogic
{
    public class ProductFunctions
    {
        internal static void SetWidth(ProductsModel p)
        {
            switch (p.ProductType)
            {
                case ProductTypes.photoBook:
                    p.Width = Constants.ProductWidth_PhotoBook * p.Quantity;
                    break;
                case ProductTypes.calendar:
                    p.Width = Constants.ProductWidth_Calendar * p.Quantity;
                    break;
                case ProductTypes.canvas:
                    p.Width = Constants.ProductWidth_Canvas * p.Quantity;
                    break;
                case ProductTypes.cards:
                    p.Width = Constants.ProductWidth_Cards * p.Quantity;
                    break;
                case ProductTypes.mug: //each 4 mugs are 94 mm
                    p.Width = Constants.ProductWidth_Mug * (p.Quantity / 4 + ((p.Quantity % 4 == 0) ? 0 : 1));
                    break;

                default:
                    break;
            }
        }
    }
}