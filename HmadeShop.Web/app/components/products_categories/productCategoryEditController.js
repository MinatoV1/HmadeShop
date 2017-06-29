(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);
    productCategoryEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state','$stateParams','commonService'];
    function productCategoryEditController($scope, apiService, notificationService,$state, $stateParams,commonService) {
      
        //Khai báo hàm

        $scope.UpdateProductCategories = UpdateProductCategories;
        $scope.GetSeoTitle = GetSeoTitle;


        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
        }


        //Định nghĩa hàm
        function loadParentProductCategoriesDetail()
        {
            apiService.get('/api/productcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError("Cannot get list parent");
                console.log("", $stateParams.id);
            });
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


        //Định nghĩa hàm
         function UpdateProductCategories() {
            apiService.put('/api/productcategory/update', $scope.productCategory, function (result) {
                notificationService.displaySuccess("Cập nhật danh mục thành công");
                $state.go('product_categories')
                //console.log("Add ProductCategory Successfully");
            }, function () {

                notificationService.displayError("Cập nhật không thành công");

            })
        }
    
         getParentProductCategories();
         loadParentProductCategoriesDetail();
    }
})(angular.module('hmadeshop.product_categories'));