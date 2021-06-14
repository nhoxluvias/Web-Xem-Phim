﻿using Data.BLL;
using Data.DTO;
using System;
using System.Threading.Tasks;
using System.Web.UI;
using Web.Models;

namespace Web.Admin.TagManagement
{
    public partial class DeleteTag : System.Web.UI.Page
    {
        private TagBLL tagBLL;
        protected TagInfo tagInfo;
        protected bool enableShowInfo;
        protected bool enableShowResult;
        protected string stateString;
        protected string stateDetail;

        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                tagBLL = new TagBLL(DataAccessLevel.Admin);
                enableShowInfo = false;
                enableShowResult = false;
                stateString = null;
                stateDetail = null;
                hyplnkList.NavigateUrl = GetRouteUrl("Admin_TagList", null);
                if (!IsPostBack)
                {
                    await GetTagInfo();
                    tagBLL.Dispose();
                }

            }
            catch (Exception ex)
            {
                Session["error"] = new ErrorModel { ErrorTitle = "Ngoại lệ", ErrorDetail = ex.Message };
                Response.RedirectToRoute("Notification_Error", null);
            }
        }

        private long GetTagId()
        {
            object obj = Page.RouteData.Values["id"];
            if (obj == null)
                return -1;
            return long.Parse(obj.ToString());
        }

        private async Task GetTagInfo()
        {
            long id = GetTagId();
            if (id <= 0)
            {
                Response.RedirectToRoute("Admin_TagList", null);
            }
            else
            {
                tagInfo = await tagBLL.GetTagAsync(id);
                if (tagInfo == null)
                {
                    enableShowInfo = false;
                    Response.RedirectToRoute("Admin_TagList", null);
                }
                else
                {
                    enableShowInfo = true;
                }
            }
        }

        private async Task DeleteTagInfo()
        {
            long id = GetTagId();
            StateOfDeletion state = await tagBLL.DeleteTagAsync(id);
            tagBLL.Dispose();
            enableShowResult = true;
            enableShowInfo = false;
            if (state == StateOfDeletion.Success)
            {
                stateString = "Success";
                stateDetail = "Đã xóa thẻ tag thành công";
            }
            else if (state == StateOfDeletion.Failed)
            {
                stateString = "Failed";
                stateDetail = "Xóa thẻ tag thất bại";
            }
            else
            {
                stateString = "ConstraintExists";
                stateDetail = "Không thể xóa thẻ tag. Lý do: Thẻ tag này đang được sử dụng!";
            }
        }

        protected async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                await DeleteTagInfo();
            }
            catch (Exception ex)
            {
                Session["error"] = new ErrorModel { ErrorTitle = "Ngoại lệ", ErrorDetail = ex.Message };
                Response.RedirectToRoute("Notification_Error", null);
            }
        }
    }
}