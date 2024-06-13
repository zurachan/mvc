(function () {
    'use strict'
    angular.module('app').controller('menupopup', ['$uibModalInstance', 'item', 'MenuService', '$scope', Controller])
    function Controller($uibModalInstance, item, MenuService, $scope) {
        var vm = this
        vm.Detail = { ...item }
        vm.Menu

        OnInit()
        async function OnInit() {
            await getMenu()
            vm.Menu = vm.Menu.filter(x => { return !x.parentId && x.id !== vm.Detail.id })
        }

        vm.ok = () => {
            $uibModalInstance.close(vm.Detail)
        }
        vm.cancel = () => {
            $uibModalInstance.dismiss('cancel')
        }

        async function getMenu() {
            let res = await MenuService.getMenu()
            if (res.status == 200)
                vm.Menu = res.data.map((x, index) => {
                    x.stt = index + 1
                    return x
                })
            else {
                vm.Menu = []
            }
            _.defer(() => { $scope.$apply() })
        }
    }
})()