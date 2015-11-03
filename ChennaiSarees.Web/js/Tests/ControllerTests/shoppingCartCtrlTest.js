describe("Controller: shoppingCartCtrl as ctrl", function () {
    var rootScope, scope, controller, shoppingCartService, q, interval, deferred, globalObjects;

    var shoppingCartItems = [
            {
                "ShoppingCartId": 1,
                "CustomerID": 'SHANN',
                "EmployeeID": 1,
                "ProductID": 1,
                "Quantity": 1,
                "OrderDate": new Date(),
                "Product": {
                    "ProductID": 1,
                    "UnitPrice": 10.11
                }
            },
            {
                "ShoppingCartId": 2,
                "CustomerID": 'SHANN',
                "EmployeeID": 1,
                "ProductID": 2,
                "Quantity": 1,
                "OrderDate": new Date(),
                "Product": {
                    "ProductID": 2,
                    "UnitPrice": 13.11
                }

            },
            {
                "ShoppingCartId": 3,
                "CustomerID": 'SHANN',
                "EmployeeID": 1,
                "ProductID": 3,
                "Quantity": 5,
                "OrderDate": new Date(),
                "Product": {
                    "ProductID": 3,
                    "UnitPrice": 43.14
                }
            }];

    beforeEach(angular.mock.module('chennaiSarees'))

    beforeEach(inject(function (_$rootScope_, _$controller_, $q, _$interval_, _shoppingCartService_, _globalObjects_) {
        scope = _$rootScope_.$new();
        q = $q;
        interval = _$interval_;
        deferred = q.defer();
        shoppingCartService = _shoppingCartService_
        globalObjects = _globalObjects_;

        spyOn(shoppingCartService, 'addShoppingCart').and.returnValue(deferred.promise);
        spyOn(shoppingCartService, 'getShoppingCartList').and.returnValue(deferred.promise);
        spyOn(shoppingCartService, 'updateShoppingCart').and.returnValue(deferred.promise);
        spyOn(globalObjects.toastr, 'info').and.returnValue('info');
        spyOn(globalObjects.toastr, 'error').and.returnValue('error');
        spyOn(globalObjects.toastr, 'success').and.returnValue('success');

        controller = _$controller_("shoppingCartCtrl as vm", { $scope: scope, shoppingCartService: _shoppingCartService_, $interval: interval, toastr: toastr });
    }));

    describe('Controller Tests', function () {
        it('should have startAnimate defined ', function () {
            expect(scope.vm.startAnimate).toBeDefined();
            expect(scope.vm.startAnimate).toBe(false);
        });

        it('should have buttonStyle defined and set default value as btn-default', function () {
            expect(scope.vm.buttonStyle).toBeDefined();
            expect(scope.vm.buttonStyle).toBe('btn-default');
        });

        it('should have addToCart defined', function () {
            expect(scope.vm.addToCart).toBeDefined();
        });

        it('should have updateCart defined', function () {
            expect(scope.vm.updateCart).toBeDefined();
        });

        it('should have getShoppingCartList defined', function () {
            expect(scope.vm.updateCart).toBeDefined();
        });

        it('should resolve promise', function () {
            deferred.resolve(shoppingCartItems);

            // We have to call apply for this to work
            scope.$apply();

            // Since we called apply, not we can perform our assertions
            expect(scope.vm.shoppingCartItems).not.toBe(undefined);
            expect(scope.vm.shoppingCartItems.length).toBe(3);
            expect(scope.vm.error).toBe('');
        });

        it('should reject promise', function () {
            deferred.reject('error');

            // We have to call apply for this to work
            scope.$apply();

            // Since we called apply, not we can perform our assertions
            expect(scope.vm.error).toBeDefined();
            expect(scope.vm.error).toBe('error');
        });

        it('should getShoppingCartList populate grandTotal', function () {
            shoppingCartService.getShoppingCartList('ALFKI');
            deferred.resolve(shoppingCartItems);

            // We have to call apply for this to work
            scope.$apply();

            // Since we called apply, not we can perform our assertions
            expect(scope.vm.grandTotal()).toBe(238.92);
        });

        it('should addShoppingCart set startAnimate false', function () {
            var cart = {
                CustomerID: "ALFKI",
                EmployeeID: 1,
                ProductID: 1,
                Quantity: 1,
                OrderDate: "2015/10/27"
            };
            controller.addToCart(cart);
            deferred.resolve(true);

            // We have to call apply for this to work
            scope.$apply();

            // Since we called apply, not we can perform our assertions
            expect(scope.vm.startAnimate).toBe(true);
            expect(globalObjects.toastr.info).toHaveBeenCalled();
        });

        it('should addToCart failure set startAnimate false', function () {
            var cart = {
                CustomerID: "ALFKI",
                EmployeeID: 1,
                ProductID: 1,
                Quantity: 1,
                OrderDate: "2015/10/27"
            };
            controller.addToCart(cart);
            deferred.reject('error');

            // We have to call apply for this to work
            scope.$apply();

            // Since we called apply, not we can perform our assertions
            expect(scope.vm.error).toBe('error');
            expect(scope.vm.startAnimate).toBe(false);
            expect(shoppingCartService.addShoppingCart).toHaveBeenCalledWith(cart);
        });

        it('increaseQuantityByOne should increment quantity', function () {
            shoppingCartService.getShoppingCartList('ALFKI');
            deferred.resolve(shoppingCartItems);

            // We have to call apply for this to work
            scope.$apply();

            scope.vm.increaseQuantityByOne(1);

            // Since we called apply, not we can perform our assertions
            expect(scope.vm.shoppingCartItems[1].Quantity).toBe(2);
        });

        it('decreaseQuantityByOne should decrement quantity', function () {
            shoppingCartService.getShoppingCartList('ALFKI');
            deferred.resolve(shoppingCartItems);

            // We have to call apply for this to work
            scope.$apply();
            scope.vm.decreaseQuantityByOne(2);
            scope.$apply();

            

            // Since we called apply, not we can perform our assertions
            expect(scope.vm.shoppingCartItems[2].Quantity).toBe(4);
            expect(scope.vm.startAnimate).toBe(true);
        });

        it('set quantity to 0 should remove the item', function () {
            shoppingCartService.getShoppingCartList('ALFKI');
            deferred.resolve(shoppingCartItems);

            // We have to call apply for this to work
            scope.$apply();
            scope.vm.shoppingCartItems[2].Quantity = 0;
            scope.$apply();



            // Since we called apply, not we can perform our assertions
            expect(scope.vm.shoppingCartItems.length).toBe(2);
            expect(scope.vm.startAnimate).toBe(true);
        });
    });
});