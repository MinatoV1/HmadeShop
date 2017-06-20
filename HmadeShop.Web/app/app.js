/// <reference path="C:\Users\nguye\OneDrive\Documents\ASP.NET\HmadeShop\HmadeShop\HmadeShop.Web\Assets/Admin/libs/angular/angular.js" />

(function () {
    angular.module('hmadeshop', ['hmadeshop.common', 'hmadeshop.products']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });

        $urlRouterProvider.otherwise('/admin');
    }
})();