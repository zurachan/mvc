(function () {
    'use strict'
    angular.module('app').controller('system', ['$scope', Controller])
    function Controller($scope) {
        var vm = this
        vm.page = 'System page'

    }
})()