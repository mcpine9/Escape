var ProductSpecsMod = angular.module("ProductSpecsMod", []);

ProductSpecsMod.controller("ProdSpecsCtrl", ["$scope", function ($scope) {
    $scope.specs = pageJsonObj;
}])