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
                params: p
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
                params: p
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
            createModal: createModal
        }
        return factory

        function createModal(animation, templateUrl, controller, size, parentElem, lazyFiles, item) {
            let instance = $uibModal.open({
                animation: animation,
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
    }])
})()