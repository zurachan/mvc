(function () {
    'use strict'
    angular.module('app').component('appHeader', {
        templateUrl: '/src/components/header/header.html',
        controller: Controller,
        controllerAs: 'vm',
        bindings: {
            logOut: '<',
            user: '='
        },
    })

    function Controller($scope, $location, $transitions, CommonService, $state) {
        var vm = this
        vm.menu = [
            { name: 'User', path: 'user' },
            { name: 'Department', path: 'department' },
        ]
        vm.Current;

        OnInit()

        $transitions.onSuccess({}, function () {
            vm.Current = $location.path().replace('/', '')
        })

        function OnInit() { }
    }
})()