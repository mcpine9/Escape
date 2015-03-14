﻿/// <reference path="../lib/angular/angular.js" />

var AddSpecMod = angular.module("AddSpecMod", [])
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

AddSpecMod.controller("AddSpecCtrl", ['$scope', function ($scope) {
    var currentId = 1,
        jsonStr = '{ "rows": [{ "id": 0, "key": "", "value": "" }], "description": "" }';
    var obj = JSON.parse(jsonStr);
    $scope.specs = obj;
    $scope.specs.description = "";
    $scope.AddSpecRows = function () {
        $scope.specs.rows.push({ 'id': currentId, 'key': 'key', 'value': 'value' });
        currentId++;
    };

    $scope.DeleteSpecRow = function(id) {
        $scope.specs.rows = $scope.specs.rows.filter(function (elem) {
            return elem.id !== id;
        });
    }
    $scope.json = JSON.stringify($scope.specs);

}]);