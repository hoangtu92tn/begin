(function() {
    angular.module('teduShop.products', ['tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("products", {
            url: "/products",
            templateUrl: "/app/components/product/productListView.html",
            controller: "productListCtrl"
        }).state("product_add", {
            url: "/product-add",
            templateUrl: "/app/components/product/productAddView.html",
            controller: "productAddCtrl"
        }).state("product_edit", {
            url: "/product-edit",
            templateUrl: "/app/components/product/productEditView.html",
            controller: "productAddCtrl"
        });
    }
})();