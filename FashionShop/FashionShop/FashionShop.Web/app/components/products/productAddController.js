(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px'
        }
        $scope.AddProduct = AddProduct;
        $scope.getSeoTitle = getSeoTitle;

        function getSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.AddProductCategory.Name);
        }
        function AddProduct() {
            apiService.post('api/product/create', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + "Đã Được Thêm Mới");
                $state.go('product_categories')
            }, function (error) {
                notificationService.displayError("Thêm Mới Không Thành Công");
            });
        }

        function loadProductCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.Image = fileUrl;
            }
            finder.popup();
        }
        loadProductCategory();
    }

})(angular.module('fashionshop.product_categories'));