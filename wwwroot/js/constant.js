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
            {
                key: 'Users',
                url: '/Users',
                templateUrl: '/src/page/user/user.html',
                controller: 'user as vm',
                lazyLoadFiles: [
                    "/src/page/user/user.js",
                    "/src/page/user/user.service.js",
                    "/src/components/pagination/pagination.js"
                ]
            },
            {
                key: 'TaiChinh',
                url: '/TaiChinh',
                templateUrl: '/src/page/taichinh/taichinh.html',
                controller: 'taichinh as vm',
                lazyLoadFiles: [
                    "/src/page/taichinh/taichinh.js",
                    "/src/page/taichinh/taichinh.service.js",
                ]
            },
            {
                key: 'PhanQuyen',
                url: '/PhanQuyen',
                templateUrl: '/src/page/phanquyen/phanquyen.html',
                controller: 'phanquyen as vm',
                lazyLoadFiles: [
                    "/src/page/phanquyen/phanquyen.js",
                    "/src/page/phanquyen/phanquyen.service.js",
                ]
            },
            {
                key: 'AppControllers',
                url: '/AppControllers',
                templateUrl: '/src/page/controller/controller.html',
                controller: 'controller as vm',
                lazyLoadFiles: [
                    "/src/page/controller/controller.js",
                    "/src/page/controller/controller.service.js",
                ]
            },
            {
                key: 'AppRoles',
                url: '/AppRoles',
                templateUrl: '/src/page/role/role.html',
                controller: 'role as vm',
                lazyLoadFiles: [
                    "/src/page/role/role.js",
                    "/src/page/role/role.service.js",
                ]
            },
        ]

        return config
    }
})()