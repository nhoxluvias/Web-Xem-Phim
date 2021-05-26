﻿<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Admin/Layout/AdminLayout.Master" AutoEventWireup="true" CodeBehind="LanguageDetail.aspx.cs" Inherits="Web.Admin.LanguageManagement.LanguageDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <% if (enableShowDetail)
        { %>
    <div class="row grid-responsive">
        <div class="column page-heading">
            <div class="large-card">
                <h1>Chi tiết ngôn ngữ: <% = languageInfo.name %></h1>
                <p>ID của ngôn ngữ: <% = languageInfo.ID %></p>
                <p>Tên của ngôn ngữ: <% = languageInfo.name %></p>
                <p>Mô tả của ngôn ngữ: <% = languageInfo.description %></p>
                <p>Ngày tạo của ngôn ngữ: <% = languageInfo.createAt %></p>
                <p>Ngày cập nhật của ngôn ngữ: <% = languageInfo.updateAt %></p>
                <asp:HyperLink ID="hyplnkList" CssClass="button button-blue" runat="server">Quay về trang danh sách</asp:HyperLink>
                <asp:HyperLink ID="hyplnkEdit" CssClass="button button-green" runat="server">Chỉnh sửa</asp:HyperLink>
                <asp:HyperLink ID="hyplnkDelete" CssClass="button button-red" runat="server">Xóa</asp:HyperLink>
            </div>
        </div>
    </div>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
