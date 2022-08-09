using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string AdminNotFound = "Admin is not found!";
        public static string PasswordError = "Invalid password.";
        public static string PasswordEmpty = "Password field is compulsory.";
        public static string SuccessfulLogin = "Logged in successfully.";
        public static string AdminAlreadyExists = "Admin already registered!";
        public static string AdminRegistered = "Admin registered successfully.";
        public static string AccessTokenCreated = "Access token created successfully.";
        public static string AuthorizationDenied = "You haven't authroity to do that!";

        public static string SaveChanges = "Change Saved";
        public static string WrongFilterType = "Wrong Filter Type";


        public static string ProductAdded = "Product is successfully added";
        public static string ProductDeleted = "Product is successfully deleted";
        public static string ProductUpdated = "Product is successfully updated";

        public static string OrderAdded = "Order is successfully added";
        public static string OrderDeleted = "Order is successfully deleted";
        public static string OrderUpdated = "Order is successfully updated";


        public static string ProductNameAlreadyExists = "Product name is already exists";


        public static string CategoryAdded = "Category is successfully added";
        public static string CategoryDeleted = "Category is successfully deleted";
        public static string CategoryUpdated = "Category is successfully updated";

        public static string OrderProductAdded = "OrderProduct is successfully added";
        public static string OrderProductDeleted  = "OrderProduct is successfully deleted";
        public static string OrderProductUpdated = "OrderProduct is successfully updated";
        public static string ProductListed = "Products are successfully listed!";
    }
}