(function() {
    angular.module('teduShop', ['teduShop.products','tedushop.common']).config(config);

    config.$inject = ["$stateProvider", "$urlRouterProvider"];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("home", {
            url: "/home",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeCtrl"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();