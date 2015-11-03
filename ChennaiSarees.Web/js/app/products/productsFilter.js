(function () {
    "use strict"
    angular.module("chennaiSarees").filter('productsFilter', function () {
        return function (items, filters) {
            var filtered = items;

            if (filters.unitPrice != 0) {
                filtered = [];
                angular.forEach(items, function (item) {
                    if (angular.equals(parseFloat(filters.unitPrice), parseFloat(item.UnitPrice)))
                            filtered.push(item);
                });
            }

            if (filters.productName != '') {
                var temp = filtered;
                filtered = [];
                angular.forEach(temp, function (item) {
                    if (item.ProductName.indexOf(filters.productName) > -1)
                        filtered.push(item);
                });
            }

            return filtered;
        };
    });

}());