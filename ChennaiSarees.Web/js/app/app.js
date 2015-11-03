(function () {
    "use strict";

    var app = angular.module('chennaiSarees', ['ngRoute', 'ngResource']);
    app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider.when('/cart', { templateUrl: 'ShoppingCart/Index', controller: 'shoppingCartCtrl as vm' });
        $routeProvider.when('/products', { templateUrl: 'product/index', controller: 'productsCtrl as vm' });
        $routeProvider.otherwise({ redirectTo: '/cart' });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });

        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-bottom-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    }]);
})();


