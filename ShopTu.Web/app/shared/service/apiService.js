(function (app) {
    app.factory("apiService", apiService);

    apiService.$inject = ['$http'];

    function apiService($http) {
        return {
            get: get
        }

        function get(url,params,success,failure) {
            $http.get(url, params).then(function(res) {
                success(res);
            }, function(error) {
                failure(error);
            });
        }

    }
})(angular.module('tedushop.common'));