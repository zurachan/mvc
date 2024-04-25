(function () {
    'use strict'
    angular.module('app').controller('controller', ['$scope', 'ControllerService', 'CommonService', Controller])
    function Controller($scope, ControllerService, CommonService) {
        var vm = this
        vm.page = 'Danh sách menu'
        vm.Datasource = []

        OnInit()

        vm.onAddEdit = (item) => {
            let parentElem = angular.element('#controllerModal')
            let modalInstance = CommonService.createModal(
                true,
                '/src/page/controller/controllerModal.html',
                'controllerModal as vm',
                'lg',
                parentElem,
                ['/src/page/controller/controllerModal.js'],
                item
            )

            modalInstance.result.then((response) => {
                console.log(response)
            }).catch((response) => {
                console.log(response)
                console.log('Modal dismissed at: ' + new Date())
            })
            _.defer(() => { $scope.$apply() })
        }


        async function OnInit() {
            $.blockUI()
            await getMenu()
            $.unblockUI()
        }

        async function getMenu() {
            let res = await ControllerService.getMenu()
            if (res.status == 200)
                vm.Datasource = res.data.map((x, index) => {
                    x.stt = index + 1
                    return x
                })
            else {
                vm.Datasource = []
            }
            _.defer(() => { $scope.$apply() })
        }
    }
})()