(function () {
    'use strict'
    angular.module('app').config(function ($stateProvider, $locationProvider) {
        $locationProvider.hashPrefix('')
        let state = [
            {
                key: 'home',
                url: '/',
                templateUrl: '/src/page/home/home.html',
                controller: 'home as vm',
                lazyLoadFiles: [
                    "/src/page/home/home.js",
                ]
            },
            {
                key: 'user',
                url: '/user',
                templateUrl: '/src/page/user/user.html',
                controller: 'user as vm',
                lazyLoadFiles: [
                    "/src/page/user/user.service.js",
                    "/src/page/user/user.controller.js",
                    "/src/components/pagination/pagination.js"
                ]
            },
            {
                key: 'department',
                url: '/department',
                templateUrl: '/src/page/department/department.html',
                controller: 'department as vm',
                lazyLoadFiles: [
                    "/src/page/department/department.service.js",
                    "/src/page/department/department.controller.js",
                ]
            },
        ]

        state.forEach((item) => {
            $stateProvider.state(item.key, {
                url: item.url,
                templateUrl: item.templateUrl,
                controller: item.controller,
                resolve: {
                    lazy: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            files: item.lazyLoadFiles
                        })
                    }]
                }
            })
        })
    })
})()