(function () {
    'use strict'
    angular.module('app').factory('ControllerService', ['ApiService', function (ApiService) {
        var factory = {
            getMenu: getMenu,
            saveMenu: saveMenu,
        }
        return factory

        function getMenu() { return ApiService.post({}, '/api/Menu/getmenu') }

        function saveMenu(p) { return ApiService.post(p, '/api/Menu/savemenu') }
    }])
})()