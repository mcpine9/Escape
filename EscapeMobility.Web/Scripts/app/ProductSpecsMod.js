var ProductSpecsMod = angular.module("ProductSpecsMod", []);

ProductSpecsMod.controller("ProdSpecsCtrl", ["$scope", "$http", function ($scope, $http) {
    $http.get("/ProductsAdmin").success().error();
}])