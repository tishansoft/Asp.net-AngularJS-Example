(function () {
    "use strict";
    angular.module("chennaiSarees").controller("productsCtrl", ["productsService", productsCtrl]);

    function productsCtrl(productsService) {
        var vm = this;
        vm.productNameFilter = '';
        vm.productUnitPriceFilter = 0;
        vm.filteredProducts = [];
        vm.Cart = {
            CustomerID: 'SHANN',
            EmployeeID: 5,
            ProductID: 0,
            Quantity: 0,
            OrderDate: new Date()
        };

        productsService.getProducts().then(successFn, errorFn);

        function successFn(response) {
            vm.products = response;
        }

        function errorFn(response) {
            vm.error = response;
        }

        vm.filterProducts = function (item) {
            if (vm.productNameFilter != '' && vm.productUnitPriceFilter != 0 && vm.productUnitPriceFilter != '')
                return (item.ProductName.indexOf(vm.productNameFilter) != -1 && item.UnitPrice === vm.productUnitPriceFilter);
            else if (vm.productNameFilter == '' && (vm.productUnitPriceFilter != 0 && vm.productUnitPriceFilter != ''))
                return (item.UnitPrice === vm.productUnitPriceFilter);
            else if (vm.productNameFilter != '' && (vm.productUnitPriceFilter == 0 || vm.productUnitPriceFilter == ''))
                return (item.ProductName.indexOf(vm.productNameFilter) != -1);
            else
                return true;
        };
    };

})();

