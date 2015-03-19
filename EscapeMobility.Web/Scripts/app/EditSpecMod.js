/// <reference path="../lib/angular/angular.js" />

var EditSpecMod = angular.module("EditSpecMod", [])
.directive('ckEditor', function () {
    return {
        require: '?ngModel',
        link: function (scope, elm, attr, ngModel) {
            var ck = CKEDITOR.replace(elm[0]);

            if (!ngModel) return;

            ck.on('pasteState', function () { 
                scope.$apply(function () {
                    ngModel.$setViewValue(ck.getData());
                });
            });

            ngModel.$render = function (value) {
                ck.setData(ngModel.$viewValue);
            };
        }
    };
});;

EditSpecMod.controller("EditSpecCtrl", ['$scope', '$http', '$window', function ($scope, $http, $window) {
    var arrayLength = pageJsonObj.rows.length,
        currentId = pageJsonObj.rows[arrayLength -1].id;
    $scope.specs = pageJsonObj;
    $scope.AddSpecRows = function () {
        $scope.specs.rows.push({ 'id': currentId >= 1 ? currentId++ : 1, 'key': '', 'value': '' });
    };
    $scope.DeleteSpecRow = function(id) {
        $scope.specs.rows = $scope.specs.rows.filter(function (elem) {
            return elem.id !== id;
        });
    }
    $scope.submit = function () {
        var paramsObj = {
            "productId" : $("#productId").val(),
            "json": JSON.stringify($scope.specs),
            "Show": $("#Show").is(':checked'),
            "ShowInProd": $("#ShowInProd").is(':checked')
        }
        $http.post("/ProductsAdmin/AddCustomSpecs", paramsObj)
            .success(function() {
                $window.location.href = "/ProductsAdmin";
            })
            .error(function() {
            
        });
    }

}]);