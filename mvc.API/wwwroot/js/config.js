(function () {
    'use strict'
    angular.module('app').config(
        function ($stateProvider, $locationProvider, $urlRouterProvider, Constant, $httpProvider) {
            $locationProvider.hashPrefix('')

            $stateProvider
                .state('home', {
                    url: '/'
                }).state('login', {
                    url: '/login'
                })

            let errorState = Constant.ERROR_TEMPLATE
            errorState.forEach((item) => {
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

            let state = Constant.TEMPLATE_URL
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

            $urlRouterProvider.otherwise('/NotFound')

            $httpProvider.interceptors.push(function () {
                return {
                    'request': function (config) {
                        let token = localStorage.getItem('token')
                        token = token ? JSON.parse(token) : token
                        config.headers['Authorization'] = "Bearer " + token
                        return config
                    }
                }
            })
        }
    )
})()