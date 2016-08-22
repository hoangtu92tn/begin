(function (app) {
    app.controller("productListCtrl", productListCtrl);
    productListCtrl.$inject = ['$scope', 'apiService', 'notificationService'];
    function productListCtrl($scope, apiService, notificationService) {
        $scope.listProduct = [];
        $scope.keywork = 0;
        $scope.getProduct = function (page) {
            page = page || 0;
            var config = {
                params: {
                    keywork: $scope.keywork,
                    page: page,
                    pagesize:2
                }
            }
            apiService.get('/api/product/get', config, function (res) {
                if (res.data.TotalCount == 0) {
                    notificationService.displayWarning("Không tìm thấy dữ liệu theo điều kiện tìm kiếm");
                }
                $scope.listProduct = res.data.items;
                $scope.page = res.data.Page;
                $scope.totalCount = res.data.TotalCount;
                $scope.pagesCount = res.data.TotalPages;
            }, function (error) {
                notificationService.displayError("Thất bại");
            });
        }
        $scope.getProduct();

    }
})(angular.module('teduShop.products'));