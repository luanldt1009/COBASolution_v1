using System;
using System.Collections.Generic;
using System.Text;

namespace COBAShop.Utilities.Exceptions
{
    public class COBAShopException : Exception
    {
        public COBAShopException()
        {
        }

        public COBAShopException(string message) : base(message)
        {
        }

        public COBAShopException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}