(function () {
    'use strict'
    angular.module('app').component('appLogin', {
        templateUrl: '/src/components/login/login.html',
        controller: Controller,
        controllerAs: 'vm',
        bindings: {
            logIn: '<'
        },
    })
    function Controller() {
        var vm = this
        vm.Login = {
            Username: "",
            Password: ""
        }
    }
})()