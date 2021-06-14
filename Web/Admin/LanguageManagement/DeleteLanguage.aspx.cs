﻿using Data.BLL;
using Data.DTO;
using System;
using System.Threading.Tasks;
using System.Web.UI;
using Web.Models;

namespace Web.Admin.LanguageManagement
{
    public partial class DeleteLanguage : System.Web.UI.Page
    {
        private LanguageBLL languageBLL;
        protected LanguageInfo languageInfo;
        protected bool enableShowInfo;
        protected bool enableShowResult;
        protected string stateString;
        protected string stateDetail;

        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                languageBLL = new LanguageBLL(DataAccessLevel.Admin);
                enableShowInfo = false;
                enableShowResult = false;
                stateString = null;
                stateDetail = null;
                hyplnkList.NavigateUrl = GetRouteUrl("Admin_LanguageList", null);
                if (!IsPostBack)
                {
                    await GetLanguageInfo();
                    languageBLL.Dispose();
                }
            }
            catch (Exception ex)
            {
                Session["error"] = new ErrorModel { ErrorTitle = "Ngoại lệ", ErrorDetail = ex.Message };
                Response.RedirectToRoute("Notification_Error", null);
            }
        }

        private int GetLanguageId()
        {
            object obj = Page.RouteData.Values["id"];
            if (obj == null)
                return -1;
            return int.Parse(obj.ToString());
        }

        private async Task GetLanguageInfo()
        {
            int id = GetLanguageId();
            if (id <= 0)
            {
                Response.RedirectToRoute("Admin_LanguageList", null);
            }
            else
            {
                languageInfo = await languageBLL.GetLanguageAsync(id);
                if (languageInfo == null)
                {
                    enableShowInfo = false;
                    Response.RedirectToRoute("Admin_LanguageList", null);
                }
                else
                {
                    enableShowInfo = true;
                }
            }
        }

        private async Task DeleteCategoryInfo()
        {
            int id = GetLanguageId();
            StateOfDeletion state = await languageBLL.DeleteLanguageAsync(id);
            languageBLL.Dispose();
            enableShowResult = true;
            enableShowInfo = false;
            if (state == StateOfDeletion.Success)
            {
                stateString = "Success";
                stateDetail = "Đã xóa ngôn ngữ thành công";
            }
            else if (state == StateOfDeletion.Failed)
            {
                stateString = "Failed";
                stateDetail = "Xóa ngôn ngữ thất bại";
            }
            else
            {
                stateString = "ConstraintExists";
                stateDetail = "Không thể xóa ngôn ngữ. Lý do: Ngôn ngữ này đang được sử dụng!";
            }
        }

        protected async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                await DeleteCategoryInfo();
            }
            catch(Exception ex)
            {
                Session["error"] = new ErrorModel { ErrorTitle = "Ngoại lệ", ErrorDetail = ex.Message };
                Response.RedirectToRoute("Notification_Error", null);
            }
        }
    }
}