(function () {
    'use strict'
    angular.module('app').controller('user', ['$scope', Controller])
    function Controller($scope) {
        var vm = this
        vm.page = 'User Page'

    }
})()