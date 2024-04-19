(function () {
    'use strict'
    angular.module('app').factory('UserService', ['ApiService', function (ApiService) {
        var factory = {
            getList: getList,
            getById: getById
        }
        return factory

        function getList() {
            return ApiService.get({}, '/Users/GetUser')
        }

        function getById(id) {
            return ApiService.get({}, `https://reqres.in/api/users/${id}`)
        }
    }])
})()