(function () {
    'use strict'
    angular.module('app').factory('ControllerService', ['ApiService', function (ApiService) {
        var factory = {
            getMenu: getMenu,
        }
        return factory

        function getMenu() {
            return ApiService.post({}, '/api/Menu/controller')
        }
    }])
})()