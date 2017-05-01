(function () {
    angular
        .module('vmManagerApp')
        .controller('vmManagerController', vmManagerController);

    vmManagerController.$inject = ['$scope', 'dataService'];

    function vmManagerController($scope, dataService) {
        $scope.vmLoaded = false;

        var init = function () {
            dataService.listVMs()
                .then(function (vms) {
                    $scope.VMs = vms;
                    $scope.vmLoaded = true;
                }, function (error) {
                    $scope.error = error;
                    $scope.vmLoaded = true;
                });
        };

        init();
    }
}());