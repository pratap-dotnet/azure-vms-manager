(function () {
    'use strict';

    angular
        .module('vmManagerApp')
        .factory('dataService', dataService);

    dataService.$inject = ['$http'];

    function dataService($http) {

        function listVMs() {
            return $http.get('/api/vms').then(function (response) {
                console.log(response);
                return response.data;
            }, function (response) {
                return response;
            });
        };

        var service = {
            listVMs: listVMs
        };

        return service;
    }
})();