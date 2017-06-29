(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);
    productCategoryAddController.$inject = ['$scope', 'apiService', 'notificationService','$state'];
    function productCategoryAddController($scope, apiService, notificationService) {

     
        //Khai báo hàm
        $scope.getParentProductCategories = getParentProductCategories;
  
        console.log("Nó đã nhận");
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,


        }


        //Định nghĩa hàm
        function getParentProductCategories() {
            apiService.get('/api/productcategory/getallparent', null, function (result) {
                $scope.parentCategory = result.data;
                console.log("Successfully");
            }, function () {
                console.log("Cannot get list parent");

            })
        }
        $scope.getParentProductCategories();

        //Định nghĩa hàm
        $scope.AddProductCategories = function () {
            console.log("có gọi hàm");
            apiService.post('/api/productcategory/create', $scope.productCategory, function (result) {
                notificationService.displaySuccess("Thêm mới danh mục thành công");
                $state.go('product_categories')
                console.log("Add ProductCategory Successfully");
            }, function () {
               
                notificationService.displayError("Thêm mới không thành công");

            })
        }
      


    }
})(angular.module('hmadeshop.product_categories'));