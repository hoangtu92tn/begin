(function(app) {
    app.filter('statusFilter', function() {
        return function(input) {
            return input ? "Hoạt động" : "Khóa";
        }
    });
})(angular.module('tedushop.common'));