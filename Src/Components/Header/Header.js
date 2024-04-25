(function () {
    'use strict'
    angular.module('app').component('appHeader', {
        templateUrl: '/src/components/header/header.html',
        controller: Controller,
        controllerAs: 'vm',
        bindings: {
            logOut: '<',
            user: '=',
            menu: '=',
            test: '<'
        },
    })

    function Controller($location, $transitions) {
        var vm = this
        vm.Current;

        OnInit()

        $transitions.onSuccess({}, function () {
            vm.Current = $location.path().replace('/', '')
        })

        function OnInit() { }
    }
})()