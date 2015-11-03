(function () {
    "use strict"
    angular.module("chennaiSarees")
        .factory("shoppingCartService", ['$http', '$q', 'apiPath', shoppingCartService]);

    function shoppingCartService($http, $q, apiPath) {
        return ({
            addShoppingCart: function addShoppingCart(cart) {
                var request = $http({
                    method: "post",
                    url: apiPath.addShoppingCartAPI,
                    data: cart,
                    dataType: 'json',
                    headers: {
                        "Content-Type": "application/json; charset=UTF-8"
                    }
                });
                return (request.then(handleSuccess, handleError));
            },
            getShoppingCartList: function getShoppingCartList(customerId) {
                var request = $http({
                    method: "get",
                    url: apiPath.getShoppingCartList + customerId,
                    params: {
                        action: "get"
                    }
                });
                return (request.then(handleSuccess, handleError));
            },
            updateShoppingCart: function updateShoppingCart(cartList) {
                var request = $http({
                    method: "put",
                    url: apiPath.updateShoppingCartListAPI,
                    data: cartList,
                    dataType: 'json',
                    headers: {
                        "Content-Type": "application/json; charset=UTF-8"
                    }
                });
                return (request.then(handleSuccess, handleError));
            }
        });
    }

    function handleSuccess(response) {
        return (response.data.ShoppingCartItems);
    }

    function handleError(response) {
        if (!angular.isObject(response.data) || !response.data.message) {
            return ($q.reject("An unknown error occurred."));
        }
        return ($q.reject(response.data.message));
    }
}());