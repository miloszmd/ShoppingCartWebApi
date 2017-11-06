﻿using ShoppingCart.Services.UserSession;
using ShoppingCart.Views;

namespace ShoppingCart.Pages.UserPage
{
    public class RegisterControllerIndexData : BaseControllerData
    {
        public Basket Basket { get; set; }
        public bool HasError { get; set; }
        public string Message { get; set; }
    }
}