(function (app) {

    app.factory('notificationService', notificationService);

    function notificationService() {
        toastr.option= {
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "fadeIn": 300,
            "fadeOut": 1000,
            "timeOut": 3000,
            "extendedTimeOut":1000
        }
        return {
            displaySuccess: displaySuccess,
            displayError: displayError,
            displayWarning: displayWarning,
            displayInfo: displayInfo
        }

        function displaySuccess(message) {
            return toastr.success(message);
        }
        function displayError(message) {
            toastr.error(message);
        }
        function displayWarning(message) {
            toastr.warning(message);
        }
        function displayInfo(message) {
            toastr.info(message);
        }
    }


})(angular.module('tedushop.common'))