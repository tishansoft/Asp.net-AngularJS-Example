(function () {
    "use strict"
    angular.module("chennaiSarees")
        .factory("productsService", ['$http', '$q','apiPath', productsService]);

    function productsService($http, $q, apiPath) {
        return ({
            getProducts: function getProducts() {
                var request = $http({
                    method: "get",
                    url: apiPath.getProductsAPI,
                    params: {
                        action: "get"
                    }
                });
                return (request.then(handleSuccess, handleError));
            }
        });
    }

    function handleSuccess(response) {
        return (response.data.value);
    }

    function handleError(response) {
        if (!angular.isObject(response.data) || !response.data.message) {
            return ($q.reject("An unknown error occurred."));
        }
        return ($q.reject(response.data.message));
    }
}());