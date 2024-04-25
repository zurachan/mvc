(function () {
    'use strict'
    angular.module('app').controller('controllerModal', ['$uibModalInstance', 'item', controller])
    function controller($uibModalInstance, item) {
        var vm = this

        vm.Controller = item

        vm.ok = () => {
            $uibModalInstance.close(vm.Controller)
        }
        vm.cancel = () => {
            $uibModalInstance.dismiss('cancel')
        }
    }
})()