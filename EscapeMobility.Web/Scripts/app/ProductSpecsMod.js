var ProductSpecsMod = angular.module("ProductSpecsMod", ['ngSanitize']);

ProductSpecsMod.controller("ProdSpecsCtrl", ["$scope", function ($scope) {
    $scope.specs = pageJsonObj;
}])