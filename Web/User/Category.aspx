﻿<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/User/Layout/UserLayout.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Web.User.Category" %>
<%@ Import Namespace="Web.Models.DTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero common-hero">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="hero-ct">
                        <h1><%= categoryName %></h1>
                        <ul class="breadcumb">
                            <li class="active"><a href="#">Home</a></li>
                            <li><span class="ion-ios-arrow-right"></span>movie listing</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="page-single">
        <div class="container">
            <div class="row ipad-width">
                <div class="col-md-8 col-sm-12 col-xs-12">
                    <div class="topbar-filter">
                        <p>Found <span>1,608 movies</span> in total</p>
                        <label>Sort by:</label>
                        <select>
                            <option value="popularity">Popularity Descending</option>
                            <option value="popularity">Popularity Ascending</option>
                            <option value="rating">Rating Descending</option>
                            <option value="rating">Rating Ascending</option>
                            <option value="date">Release date Descending</option>
                            <option value="date">Release date Ascending</option>
                        </select>
                        <a href="movielist.html" class="list"><i class="ion-ios-list-outline "></i></a>
                        <a href="moviegrid.html" class="grid"><i class="ion-grid active"></i></a>
                    </div>
                    <div class="flex-wrap-movielist">
                        <% foreach (FilmInfo film in films)
                            { %>
                            <div class="movie-item-style-2 movie-item-style-1">
                            <img src="<% = film.thumbnail %>" alt="">
                            <div class="hvr-inner">
                                <a href="moviesingle.html">Xem <i class="ion-android-arrow-dropright"></i></a>
                            </div>
                            <div class="mv-item-infor">
                                <h6><a href="#"><%= film.name %></a></h6>
                                <p class="rate"><i class="ion-android-star"></i><span>8.1</span> /10</p>
                            </div>
                        </div>
                        <%} %>
                    </div>
                    <div class="topbar-filter">
                        <label>Movies per page:</label>
                        <select>
                            <option value="range">20 Movies</option>
                            <option value="saab">10 Movies</option>
                        </select>

                        <div class="pagination2">
                            <span>Page 1 of 2:</span>
                            <a class="active" href="#">1</a>
                            <a href="#">2</a>
                            <a href="#">3</a>
                            <a href="#">...</a>
                            <a href="#">78</a>
                            <a href="#">79</a>
                            <a href="#"><i class="ion-arrow-right-b"></i></a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-sm-12 col-xs-12">
                    <div class="sidebar">
                        <div class="searh-form">
                            <h4 class="sb-title">Search for movie</h4>
                            <div class="form-style-1">
                                <div class="row">
                                    <div class="col-md-12 form-it">
                                        <label>Movie name</label>
                                        <input type="text" placeholder="Enter keywords">
                                    </div>
                                    <div class="col-md-12 form-it">
                                        <label>Genres & Subgenres</label>
                                        <div class="group-ip">
                                            <select
                                                name="skills" multiple="" class="ui fluid dropdown">
                                                <option value="">Enter to filter genres</option>
                                                <option value="Action1">Action 1</option>
                                                <option value="Action2">Action 2</option>
                                                <option value="Action3">Action 3</option>
                                                <option value="Action4">Action 4</option>
                                                <option value="Action5">Action 5</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-md-12 form-it">
                                        <label>Rating Range</label>
                                        <select>
                                            <option value="range">-- Select the rating range below --</option>
                                            <option value="saab">-- Select the rating range below --</option>
                                        </select>
                                    </div>
                                    <div class="col-md-12 form-it">
                                        <label>Release Year</label>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <select>
                                                    <option value="range">From</option>
                                                    <option value="number">10</option>
                                                </select>
                                            </div>
                                            <div class="col-md-6">
                                                <select>
                                                    <option value="range">To</option>
                                                    <option value="number">20</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 ">
                                        <input class="submit" type="submit" value="submit">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="ads">
                            <img src="images/uploads/ads1.png" alt="">
                        </div>
                        <div class="sb-facebook sb-it">
                            <h4 class="sb-title">Find us on Facebook</h4>
                            <iframe src="" data-src="https://www.facebook.com/plugins/page.php?href=https%3A%2F%2Fwww.facebook.com%2Fhaintheme%2F%3Ffref%3Dts&tabs=timeline&width=340&height=315px&small_header=true&adapt_container_width=false&hide_cover=false&show_facepile=true&appId" height="315" style="width: 100%; border: none; overflow: hidden"></iframe>
                        </div>
                        <div class="sb-twitter sb-it">
                            <h4 class="sb-title">Tweet to us</h4>
                            <div class="slick-tw">
                                <div class="tweet item" id="599202861751410688">
                                </div>
                                <div class="tweet item" id="297462728598122498">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
