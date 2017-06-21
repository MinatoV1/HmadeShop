/// <reference path="C:\Users\nguye\OneDrive\Documents\ASP.NET\HmadeShop\HmadeShop\HmadeShop.Web\Assets/Admin/libs/angular/angular.js" />

(function (app) {
    app.service('apiService', apiService);
    apiService.$inject = ['$http', 'notificationService'];

    function apiService($http)
    {
        return {
            get: get,
            post: post
        }
        function get(url, params, success, failure) {
            $http.get(url,params).then(function(result)
            {
                success(result);
            }, function (error) {
                if (error.status === 401)
                {
                    notificationService.displayError('Yêu cầu phải đăng nhập');
                }
                else if (failure != null)
                {
                    failure(error);
                }

            })
        }

        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            })
        }

    }

})(angular.module('hmadeshop.common'));