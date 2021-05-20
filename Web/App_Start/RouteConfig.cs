﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Web.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Login", "account/login", "~/Account/Login.aspx");
            routes.MapPageRoute("Login_WithParam", "account/login/{loginStatus}", "~/Account/Login.aspx");
            routes.MapPageRoute("Logout", "account/logout", "~/Account/Logout.aspx");
            routes.MapPageRoute("Register", "account/register", "~/Account/Register.aspx");
            routes.MapPageRoute("Register_WithParam", "account/register/{registerStatus}", "~/Account/Register.aspx");
            routes.MapPageRoute("ResetPassword", "account/reset-password", "~/Account/ResetPassword.aspx");
            routes.MapPageRoute("Confirm", "account/confirm/{userId}/{confirmToken}/{status}", "~/Account/Confirm.aspx");
            routes.MapPageRoute("Error", "error", "~/Notification/Error.aspx");
            routes.MapPageRoute("Home", "home", "~/User/Home.aspx");

            routes.MapPageRoute("Admin_Overview", "admin/overview", "~/Admin/Index.aspx");
            routes.MapPageRoute("Admin_CategoryList", "admin/category/list", "~/Admin/CategoryList.aspx");
            routes.MapPageRoute("Admin_CreateCategory", "admin/category/create", "~/Admin/CreateCategory.aspx");
            routes.MapPageRoute("Admin_RoleList", "admin/role/list", "~/Admin/RoleList.aspx");
            routes.MapPageRoute("Admin_CreateRole", "admin/role/create", "~/Admin/CreateRole.aspx");
            routes.MapPageRoute("Admin_CreateCountry", "admin/country/create", "~/Admin/CreateCountry.aspx");
            routes.MapPageRoute("Admin_CreateLanguage", "admin/language/create", "~/Admin/CreateLanguage.aspx");
            routes.MapPageRoute("Admin_CreateDirector", "admin/director/create", "~/Admin/CreateDirector.aspx");

            routes.MapPageRoute("User_Home", "", "~/User/Index.aspx");
            routes.MapPageRoute("User_Category", "category/{id}", "~/User/Category.aspx");
            routes.MapPageRoute("User_FilmDetails", "film-details/{slug}/{id}", "~/User/FilmDetails.aspx");

            routes.MapPageRoute("Notification_Error", "notification/error", "~/Notification/Error.aspx");
        }
    }
}