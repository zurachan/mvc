(function () {
    'use strict'
    angular.module('app').component('appRoot', {
        templateUrl: '/src/app.html',
        controller: Controller,
        controllerAs: 'vm',
    })

    function Controller($scope) {
        var vm = this;
    }
})()