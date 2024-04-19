(function () {
    'use strict'
    angular.module('app').controller('user', ['$scope', 'UserService', Controller])
    function Controller($scope, UserService) {
        var vm = this
        vm.page = 'User Page'

        OnInit()

        async function OnInit() {
            debugger
            await getUser()
        }

        async function getUser() {
            debugger
            let res = await UserService.getList()
            debugger
        }

    }
})()