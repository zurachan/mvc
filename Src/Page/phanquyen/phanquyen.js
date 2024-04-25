(function () {
    'use strict'
    angular.module('app').controller('phanquyen', ['$scope', 'PhanQuyenService', Controller])
    function Controller($scope, PhanQuyenService) {
        var vm = this
        vm.page = 'Phân quyền page'

    }
})()