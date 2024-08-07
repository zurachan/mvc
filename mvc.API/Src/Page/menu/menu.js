﻿(function () {
    'use strict'
    angular.module('app').controller('menu', ['$scope', 'MenuService', 'CommonService', Controller])
    function Controller($scope, MenuService, CommonService) {
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
                }
            }
            openModal(vm.Detail, 'lg')
        }

        function openModal(item, size) {
            let parentElem = angular.element('#menuModal')
            let modalInstance = CommonService.createModal(
                '/src/page/menu/menupopup.html',
                'menupopup as vm',
                size,
                parentElem,
                ["/src/page/menu/menupopup.js"],
                item)

            modalInstance.result.then(async (response) => {
                await save(response)
                await getMenu()
            }).catch((response) => { })
        }

        vm.onSave = async () => {
            $.blockUI()
            await save(vm.Detail)
            await getMenu()
            $('#controllerModal').modal('hide')
            $.unblockUI()
        }

        vm.onDelete = async (item) => {
            if (!item || item.id == 0) return


        }

        async function OnInit() {
            $.blockUI()
            await getMenu()
            $.unblockUI()
        }
        async function getMenu() {
            let res = await MenuService.getMenu()
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
            debugger
            let res = await MenuService.saveMenu(model)
            if (res.status == 200) {

            }
        }
    }
})()