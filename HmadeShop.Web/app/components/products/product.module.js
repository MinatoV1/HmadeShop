/// <reference path="C:\Users\nguye\OneDrive\Documents\ASP.NET\HmadeShop\HmadeShop\HmadeShop.Web\Assets/Admin/libs/angular/angular.js" />
/// <reference path="productAddView.html" />

(function () {
    angular.module('hmadeshop.products', ['hmadeshop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('products', {
            url: "/products",
            templateUrl: "/app/components/products/productListView.html",
            controller: "productListController"
        });

        $stateProvider.state('product_add', {
            url: "/product_add",
            templateUrl: "/app/components/products/productAddView.html",
            controller: "productAddController"
     
        });


    }
})();