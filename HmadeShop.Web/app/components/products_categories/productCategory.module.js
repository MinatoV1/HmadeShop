﻿/// <reference path="C:\Users\nguye\OneDrive\Documents\ASP.NET\HmadeShop\HmadeShop\HmadeShop.Web\Assets/Admin/libs/angular/angular.js" />
/// <reference path="productAddView.html" />

(function () {
    angular.module('hmadeshop.product_categories', ['hmadeshop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('product_categories', {
            url: "/product_categories",
            templateUrl: "/app/components/products_categories/productCategoryListView.html",
            controller: "productCategoryListController"
        });

        $stateProvider.state('product_categories_add', {
            url: "/product_categories_add",
            templateUrl: "/app/components/products_categories/productCategoryAddView.html",
            controller: "productCategoryAddController"

        });
        $stateProvider.state('product_categories_edit', {
            url: "/product_categories_edit/:id",
            templateUrl: "/app/components/products_categories/productCategoryEditView.html",
            controller: "productCategoryEditController"

        });

    }
})();