(function () {
    var vmManagerApp = angular.module('vmManagerApp', ['ngRoute']);

    vmManagerApp.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '../html/index.html'
            }).otherwise({ redirectTo: '/' });
    }]);
}());