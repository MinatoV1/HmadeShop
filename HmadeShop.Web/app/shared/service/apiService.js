/// <reference path="C:\Users\nguye\OneDrive\Documents\ASP.NET\HmadeShop\HmadeShop\HmadeShop.Web\Assets/Admin/libs/angular/angular.js" />

(function (app) {
    app.service('apiService', apiService);
    apiService.$inject = ['$http'];

    function apiService($http)
    {
        return {
            get: get
        }
        function get(url, params, success, failure) {
            $http.get(url,params).then(function(result)
            {
                success(result);
            }, function (error) {
                failure(error);
            })
        }

    }

})(angular.module('hmadeshop.common'));