(function () {
    "use strict";
    angular.module("chennaiSarees").controller("shoppingCartCtrl", ["shoppingCartService", "$scope", "$interval", "globalObjects", shoppingCartCtrl]);

    function shoppingCartCtrl(shoppingCartService, $scope, $interval, globalObjects) {
        var vm = this;
        vm.buttonStyle = 'btn-default';
        vm.startAnimate = false;
        vm.error = "";

        vm.addToCart = function (cart) {

            var shoppingCart = {
                CustomerID: "ALFKI",
                EmployeeID: 1,
                ProductID: cart.ProductID,
                Quantity: 1,
                OrderDate: "2015/10/27"
            };

            shoppingCartService.addShoppingCart(shoppingCart).then(successFn, errorFn);
        }

        vm.updateCart = function (cart) {

            var shoppingCartList = {
                CustomerID: "ALFKI",
                UpdateShoppingCartList: []
            };

            angular.forEach(vm.shoppingCartItems, function (item) {
                shoppingCartList.UpdateShoppingCartList.push({ ShoppingCartId: item.ShoppingCartId, Quantity : item.Quantity});
            });

            shoppingCartService.updateShoppingCart(shoppingCartList).then(successFn, errorFn);
        }

        shoppingCartService.getShoppingCartList('ALFKI').then(successShoppingCartFn, errorFn);

        function successShoppingCartFn(response) {
            vm.shoppingCartItems = response;

            vm.grandTotal = function (index) {
                var total = 0;
                angular.forEach(vm.shoppingCartItems, function (item) {
                    total = total + item.Product.UnitPrice * item.Quantity;
                });
                return total;
            }
        }

        vm.increaseQuantityByOne = function (index) {
            vm.shoppingCartItems[index].Quantity = vm.shoppingCartItems[index].Quantity + 1;
            vm.startAnimate = true;
            globalObjects.toastr.info('Your shopping cart is changed. Please click Update to save your changes');
        }

        vm.decreaseQuantityByOne = function (index) {
            vm.shoppingCartItems[index].Quantity = vm.shoppingCartItems[index].Quantity - 1;
            vm.startAnimate = true;
            globalObjects.toastr.info('Your shopping cart is changed. Please click Update to save your changes');
        }


        vm.removeItem = function (index) {
            vm.shoppingCartItems.splice(index, 1);
            vm.startAnimate = true;
            globalObjects.toastr.info('Your shopping cart is changed. Please click Update to save your changes');
        }

        $scope.$watch('vm.shoppingCartItems', function (newValue, oldValue) {
            if (newValue != null)
            {
                angular.forEach(newValue, function (item,index) {
                    if (item.Quantity == 0)
                    {
                        vm.removeItem(index);
                    }
                    else if (newValue != oldValue && oldValue != null)
                    {
                        vm.startAnimate = true;
                    }
                });
            }
        },true);

        $interval(animateButton, 500);

        
        function successFn(response) {
            vm.startAnimate = true;
            globalObjects.toastr.info('Your item has been added to shopping Cart');
        }

        function errorFn(response) {
            vm.startAnimate = false;
            vm.error = response;
            globalObjects.toastr.error(response);
        }

        function animateButton() {
            if (vm.shoppingCartItems != null) {
                if (vm.shoppingCartItems.length > 0) {
                    if (vm.startAnimate) {
                        if (vm.buttonStyle == 'btn-default') {
                            vm.buttonStyle = 'btn-success';
                        }
                        else {
                            vm.buttonStyle = 'btn-default';
                        }
                    }
                    else {
                        vm.buttonStyle = 'btn-default';
                    }
                }
            }
        }
    };
})();