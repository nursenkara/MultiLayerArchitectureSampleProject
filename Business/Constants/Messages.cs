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
        public static string AdminsListed = "Admins are successfully listed";
        public static string AdminListed = "Admin is successfully listed";
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
        public static string ProductsListed = "Products are successfully listed";
        public static string ProductListed = "Product is successfully listed";
        public static string ProductNameAlreadyExists = "Product name is already exists";


        public static string OrderAdded = "Order is successfully added";
        public static string OrderDeleted = "Order is successfully deleted";
        public static string OrderUpdated = "Order is successfully updated";


        public static string CategoryAdded = "Category is successfully added";
        public static string CategoryDeleted = "Category is successfully deleted";
        public static string CategoryUpdated = "Category is successfully updated";
        public static string CategoryListed = "Category is successfully listed";
        public static string CategoriesListed = "Categories are successfully listed";


        public static string OrderProductAdded = "OrderProduct is successfully added";
        public static string OrderProductDeleted  = "OrderProduct is successfully deleted";
        public static string OrderProductUpdated = "OrderProduct is successfully updated";
        

        public static string OrderProductListed = "OrderModel is successfully listed";
        public static string OrderProductsListed = "OrderModels are successfully listed";

        public static string OrderListed = "Order is successfully listed!";
        public static string OrdersListed = "Orders are successfully listed!";

        public static string ProductsListedByCategory = "Products are successfully listed by category!";

        public static string BrandAdded = "Brand is successfully added";
        public static string BrandDeleted = "Brand is successfully deleted";
        public static string BrandListed = "Brand is successfully listed";
        public static string BrandsListed = "Brands are successfully listed";
        public static string BrandUpdated = "Brand is successfully updated";

        public static string ActiveAdminNotFound = "Active admin is not found";

        public static string InActiveAdminNotFound = "Inactive admin is not found";

        public static string AdminDeleted = "Admin is successfully deleted";

        public static string ActiveAdminsListed = "Active admins are successfully listed";
        public static string InactiveAdminsListed = "Inactive admins are successfully listed";
    }
}