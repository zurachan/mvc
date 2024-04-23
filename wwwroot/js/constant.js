(function () {
    angular.module('app').constant('Constant', Config())
    function Config() {
        var config = {}

        config.ERROR_TEMPLATE = [
            {
                key: 'NotFound',
                url: '/NotFound',
                templateUrl: '/src/page/notfound/notfound.html',
                controller: 'notfound as vm',
                lazyLoadFiles: [
                    "/src/page/notfound/notfound.js",
                ]
            },
            {
                key: 'NoPermission',
                url: '/NoPermission',
                templateUrl: '/src/page/nopermission/nopermission.html',
                controller: 'nopermission as vm',
                lazyLoadFiles: [
                    "/src/page/nopermission/nopermission.js",
                ]
            }
        ]

        config.TEMPLATE_URL = [
            //{
            //    key: 'login',
            //    url: '/login',
            //    templateUrl: '/src/page/login/login.html',
            //    controller: 'login as vm',
            //    lazyLoadFiles: [
            //        "/src/page/login/login.js",
            //    ]
            //},
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

        return config
    }
})()