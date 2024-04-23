(function () {
    'use strict'
    angular.module('app').component('appRoot', {
        templateUrl: '/src/app.html',
        controller: Controller,
        controllerAs: 'vm',
    })

    function Controller($scope, $state, $timeout, CommonService) {
        var vm = this

        vm.IsAuthen = false
        vm.User = [
            { email: 'duong@gmail.com', password: '123456', fullName: 'Hoàng Thái Dương', role: 'Admin' },
            { email: 'thao@gmail.com', password: '123456', fullName: 'Trần Phương Thảo', role: 'Hr' }
        ]
        vm.CurrentUser = {}

        OnInit()
        async function OnInit() {
            $.blockUI()
            vm.CurrentUser = CommonService.getLocalStorage('credential')
            if (vm.CurrentUser) {
                vm.IsAuthen = true
                $state.dispose()
                $state.go('home')
            }
            else {
                vm.IsAuthen = false
                $state.dispose()
                $state.go('login')
            }
            _.defer(() => { $scope.$apply() })
            $.unblockUI()
        }

        vm.onLogOut = () => {
            CommonService.removeLocalStorage('credential')
            vm.CurrentUser = {}
            vm.IsAuthen = false
            $state.dispose()
            $state.go('login')
        }

        vm.onLogIn = async (model) => {
            $.blockUI()
            await doLogin(model)
            if (vm.IsAuthen) {
                $state.dispose()
                $state.go('home')
            }
            $.unblockUI()
        }

        function doLogin(model) {
            return $timeout(function () {
                vm.CurrentUser = vm.User.find(x => x.email == model.Email && x.password == model.Password)
                if (vm.CurrentUser) {
                    vm.IsAuthen = true
                    CommonService.setLocalStorage('credential', vm.CurrentUser)
                } else {
                    vm.IsAuthen = false
                    CommonService.removeLocalStorage('credential')
                }
            }, 2000)
        }
    }
})()