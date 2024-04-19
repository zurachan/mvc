(function () {
    'use strict'
    angular.module('app').component('pagination', {
        templateUrl: '/src/components/pagination/pagination.html',
        bindings: {
            paging: '=',
            pageChange: '<'
        },
        controller: Controller,
        controllerAs: 'vm',
    })

    function Controller($scope) {
        var vm = this;
        vm.$onInit = () => {
            vm.Pager = vm.paging
            _.defer(() => { $scope.$apply() })
        }
    }
})()