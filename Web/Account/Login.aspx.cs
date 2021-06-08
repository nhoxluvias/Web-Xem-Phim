﻿using Data.BLL;
using Data.DTO;
using System;
using System.Threading.Tasks;
using Web.Common;
using Web.Models;
using Web.Validation;

namespace Web.Account
{
    public partial class Login : System.Web.UI.Page
    {
        private UserBLL userBLL;
        private CustomValidation customValidation;
        protected bool enableShowResult;
        protected string stateDetail;

        protected async void Page_Load(object sender, EventArgs e)
        {
            customValidation = new CustomValidation();
            InitHyperLink();
            InitValidation();
            enableShowResult = false;
            stateDetail = null;
            if (CheckLoggedIn())
            {
                Response.RedirectToRoute("Home");
            }
            else
            {
                userBLL = new UserBLL(DataAccessLevel.User);
                if (IsPostBack)
                {
                    await LoginToAccount();
                }
                userBLL.Dispose();
            }
        }

        private void InitHyperLink()
        {
            hylnkResetPassword.NavigateUrl = GetRouteUrl("ResetPassword", null);
            hylnkRegister.NavigateUrl = GetRouteUrl("Register", null);
            hylnkFeedback.NavigateUrl = "#";
            hylnkContact.NavigateUrl = "#";
            hylnkTermOfUse.NavigateUrl = "#";
        }

        private void InitValidation()
        {
            customValidation.Init(
                cvUsername,
                "txtUsername",
                "Không được trống, chỉ chứa a-z, 0-9, _ và -",
                true,
                null,
                customValidation.ValidateUsername
            );
            customValidation.Init(
                cvPassword,
                "txtPassword",
                "Tối thiểu 6 ký tự, tối đa 20 ký tự",
                true,
                null,
                customValidation.ValidatePassword
            );
        }

        private void ValidateData()
        {
            cvUsername.Validate();
            cvPassword.Validate();
        }

        private bool IsValidData()
        {
            ValidateData();
            return (cvUsername.IsValid && cvPassword.IsValid);
        }

        private bool CheckLoggedIn()
        {
            return (Session["userSession"] != null);
        }

        private UserLogin GetUserLogin()
        {
            return new UserLogin
            {
                userName = Request.Form["txtUsername"],
                password = Request.Form["txtPassword"]
            };
        }

        private async Task LoginToAccount()
        {
            if (IsValidData())
            {
                UserLogin userLogin = GetUserLogin();
                UserBLL.LoginState loginState = await userBLL.LoginAsync(userLogin);
                if(loginState == UserBLL.LoginState.NotExists || loginState == UserBLL.LoginState.WrongPassword)
                {
                    enableShowResult = true;
                    if (loginState == UserBLL.LoginState.NotExists)
                        stateDetail = "Không tồn tại tài khoản";
                    else
                        stateDetail = "Mật khẩu bạn nhập vào không đúng";
                }
                else
                {
                    UserInfo userInfo = await userBLL.GetUserByUserNameAsync(userLogin.userName);
                    if (loginState == UserBLL.LoginState.Success)
                    {
                        Session["userSession"] = new UserSession { username = userLogin.userName, role = userInfo.Role.name };
                        if (userInfo.Role.name == "User")
                            Response.RedirectToRoute("User_Home");
                        else
                            Response.RedirectToRoute("Admin_Overview");
                    }
                    else
                    {
                        ConfirmCode confirmCode = new ConfirmCode();
                        Session["confirmCode"] = confirmCode.Send(userInfo.email);
                        string confirmToken = confirmCode.CreateToken();
                        Session["confirmToken"] = confirmToken;

                        Response.RedirectToRoute("Confirm", new
                        {
                            userId = userInfo.ID,
                            confirmToken = confirmToken,
                            type = "login"
                        });
                    }
                }
            }
        }

    }
}