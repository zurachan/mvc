(function () {
    'use strict'
    angular.module('app').factory('ApiService', ['$http', function ($http) {
        var baseFactory = {
            get: get,
            post: post,
            put: put,
        }
        return baseFactory

        function get(p, url) {
            return $http({
                method: 'GET',
                url: url,
                data: p
            }).then((response) => {
                if (response.status != 200)
                    console.log(response)
                return response
            }).catch((error) => {
                console.log(error)
                return error
            })
        }

        function post(p, url) {
            return $http({
                method: 'POST',
                url: url,
                data: p
            }).then((response) => {
                if (response.status != 200)
                    console.log(response)
                return response
            }).catch((error) => {
                console.log(error)
                return error
            })
        }
        function put(p, url) { }
    }])

    angular.module('app').factory('CommonService', ['$uibModal', function ($uibModal) {
        var factory = {
            createModal: createModal,
            setLocalStorage: setLocalStorage,
            getLocalStorage: getLocalStorage,
            removeLocalStorage: removeLocalStorage,
            clearLocalStorage: clearLocalStorage
        }
        return factory

        function createModal(templateUrl, controller, size, parentElem, lazyFiles, item) {
            let instance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                templateUrl: templateUrl,
                controller: controller,
                size: size,
                appendTo: parentElem,
                resolve: {
                    lazy: ['$ocLazyLoad', ($ocLazyLoad) => {
                        return $ocLazyLoad.load({ files: lazyFiles })
                    }],
                    item: () => { return item }
                }
            })

            return instance
        }

        function setLocalStorage(key, value) {
            localStorage.setItem(key, JSON.stringify(value))
        }
        function getLocalStorage(key) {
            let local = localStorage.getItem(key)
            local = local ? JSON.parse(local) : local
            return local
        }
        function removeLocalStorage(key) {
            localStorage.removeItem(key)
        }
        function clearLocalStorage() {
            localStorage.clear()
        }
    }])
})()