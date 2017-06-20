(function (app) {
    app.controller('productCategoryListController', productCategoryListController)
    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService'];

    function productCategoryListController($scope, apiService, notificationService) {
        //Khai báo biến
        $scope.productCategory = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.totalCount = 0;
        $scope.keyword = "";

        //Khai báo hàm
        $scope.getListProductCategories = getListProductCategories;
        $scope.search = search;

        function search()
        {
            getListProductCategories();
        }


        //Định nghĩa hàm
        function getListProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword : $scope.keyword,
                    page : page,
                    pageSize: 2
                }
            }

            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0)
                {
                    notificationService.displayWarning("Đã tìm thấy " + result.data.TotalCount+" bản ghi");
                }

                $scope.productCategory = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pageCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load product category failed');

            })
        }
        $scope.getListProductCategories();

    }
})(angular.module('hmadeshop.product_categories'));