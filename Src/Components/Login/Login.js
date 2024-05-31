(function () {
    'use strict'
    angular.module('app').component('appLogin', {
        templateUrl: '/src/components/login/login.html',
        controller: Controller,
        controllerAs: 'vm',
        bindings: {
            signIn: '<',
            signUp: '<'
        },
    })
    function Controller() {
        var vm = this
        vm.IsSignIn = true
        vm.SignIn = {
            Username: "",
            Password: ""
        }
        vm.SignUp = {
            Fullname: '',
            Username: '',
            Password: ''
        }
        vm.ChangeStateSignIn = (state) => {
            vm.IsSignIn = state
        }
    }
})()