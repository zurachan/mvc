(function () {
    'use strict'
    angular.module('app').controller('taichinh', ['$scope', 'TaiChinhService', Controller])
    function Controller($scope, TaiChinhService) {
        var vm = this
        vm.page = 'Tài chính page'

    }
})()