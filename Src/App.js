(function () {
    'use strict'
    angular.module('app').component('appRoot', {
        templateUrl: '/src/app.html',
        controller: Controller,
        controllerAs: 'vm',
    })

    function Controller($scope, $state, $location, CommonService, AuthenService) {
        var vm = this

        vm.IsAuthen = false
        vm.CurrentUser = {}
        vm.Menu = []

        OnInit()

        async function OnInit() {
            $.blockUI()
            vm.CurrentUser = CommonService.getLocalStorage('credential')
            vm.Menu = CommonService.getLocalStorage('menu')
            if (vm.CurrentUser) {
                vm.IsAuthen = true
                let current = $location.path().replace('/', '')
                if (current && vm.Menu.some(x => x.controllerPath == current)) {
                    $state.dispose()
                    $state.go(current)
                } else {
                    $state.dispose()
                    $state.go('home')
                }
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
            CommonService.removeLocalStorage('token')
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

        vm.TestAuthen = async () => {
            //let res = await AuthenService.testAuthen()
            //if (res.status == 200)
            //    alert(res.data)
            //else alert("fail")
            //$('#liveToast').toast({
            //    delay: 2000
            //}).show()

            const toastBootstrap = bootstrap.Toast.getOrCreateInstance($('#liveToast'), {
                delay: 2000,
                autohide: true,
                animation: true
            })
            toastBootstrap.show()
        }

        async function doLogin(model) {
            let res = await AuthenService.login(model)
            if (res.status == 200) {
                vm.CurrentUser = res.data.user
                vm.Menu = res.data.menu
                if (vm.CurrentUser) {
                    vm.IsAuthen = true
                    CommonService.setLocalStorage('credential', vm.CurrentUser)
                    CommonService.setLocalStorage('token', res.data.token)
                    CommonService.setLocalStorage('menu', vm.Menu)
                } else {
                    vm.IsAuthen = false
                    CommonService.removeLocalStorage('credential')
                    CommonService.removeLocalStorage('token')
                    CommonService.removeLocalStorage('menu')
                }
            } else {
                vm.CurrentUser = {}
                vm.Menu = []
                vm.IsAuthen = false
                CommonService.removeLocalStorage('credential')
                CommonService.removeLocalStorage('token')
                CommonService.removeLocalStorage('menu')
            }
        }
    }

    angular.module('app').factory('AuthenService', ['ApiService', function (ApiService) {
        var factory = {
            login: login,
            testAuthen: testAuthen
        }
        return factory

        function login(p) {
            return ApiService.post(p, '/api/Authen/Login')
        }

        function testAuthen() {
            return ApiService.post({}, '/api/Authen/Test')
        }
    }])
})()