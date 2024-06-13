(function () {
    'use strict'
    angular.module('app').factory('PhanQuyenService', ['ApiService', function (ApiService) {
        var factory = {
            getList: getList,
            getById: getById
        }
        return factory

        function getList(p) {
            return ApiService.post(p, '/Users/GetUser')
        }

        function getById(id) {
            return ApiService.get({}, `https://reqres.in/api/users/${id}`)
        }
    }])
})()