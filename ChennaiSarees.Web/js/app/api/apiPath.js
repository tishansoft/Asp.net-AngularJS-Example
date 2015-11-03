(function () {
    "use strict";
    angular.module("chennaiSarees").constant('apiPath', {
        'getCustomersAPI' : 'http://localhost:50000/odata/Customer/',
        'getProductsAPI' : 'http://localhost:50000/odata/Product/',
        'addShoppingCartAPI': 'http://localhost:50000/api/ShoppingCart/',
        'getShoppingCartList': 'http://localhost:50000/api/shoppingcart/',
        'updateShoppingCartListAPI': 'http://localhost:50000/api/shoppingcart/'
    })
})();

