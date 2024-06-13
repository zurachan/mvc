(function () {
    'use strict'
    angular.module('app').controller('role', ['$scope', 'RoleService', Controller])
    function Controller($scope, RoleService) {
        var vm = this
        vm.page = 'Quyền page'

    }
})()