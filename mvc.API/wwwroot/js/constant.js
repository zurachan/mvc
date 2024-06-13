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
                key: 'menu',
                url: '/menu',
                templateUrl: '/src/page/menu/menu.html',
                controller: 'menu as vm',
                lazyLoadFiles: [
                    "/src/page/menu/menu.js",
                    "/src/page/menu/menu.service.js",
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
            {
                key: 'sale',
                url: '/sale',
                templateUrl: '/src/page/sale/sale.html',
                controller: 'sale as vm',
                lazyLoadFiles: [
                    "/src/page/sale/sale.js",
                    "/src/page/sale/sale.service.js",
                ]
            },
            {
                key: 'content',
                url: '/content',
                templateUrl: '/src/page/content/content.html',
                controller: 'content as vm',
                lazyLoadFiles: [
                    "/src/page/content/content.js",
                    "/src/page/content/content.service.js",
                ]
            },
            {
                key: 'hr',
                url: '/hr',
                templateUrl: '/src/page/hr/hr.html',
                controller: 'hr as vm',
                lazyLoadFiles: [
                    "/src/page/hr/hr.js",
                    "/src/page/hr/hr.service.js",
                ]
            },
            {
                key: 'system',
                url: '/system',
                templateUrl: '/src/page/system/system.html',
                controller: 'system as vm',
                lazyLoadFiles: [
                    "/src/page/system/system.js",
                    "/src/page/system/system.service.js",
                ]
            },
        ]

        return config
    }
})()