(function () {
    'use strict'
    angular.module('app').controller('controller', ['$scope', 'ControllerService', 'CommonService', Controller])
    function Controller($scope, ControllerService, CommonService) {
        var vm = this
        vm.page = 'Danh sách menu'
        vm.Datasource = []
        vm.Detail
        OnInit()

        vm.onAddEdit = (item) => {
            if (item) {
                vm.Detail = { ...item }
            } else {
                vm.Detail = {
                    id: 0,
                    controllerName: '',
                    controllerPath: '',
                }
            }
            $('#controllerModal').modal('show')
        }

        vm.onSave = async () => {
            $.blockUI()
            await save(vm.Detail)
            await getMenu()
            $('#controllerModal').modal('hide')
            $.unblockUI()
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
        async function save(model) {
            let res = await ControllerService.saveMenu(model)
            if (res.status == 200) {

            }
        }
        $("#controllerModal").on("hidden.bs.modal", function () {
            vm.Detail
        })
    }
})()