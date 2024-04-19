(function () {
    'use strict'
    angular.module('app').controller('home', ['$scope', Controller])
    function Controller($scope) {
        var vm = this
        vm.page = 'Home'

    }
})()