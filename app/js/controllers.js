'use strict';

/* Controllers */

var storeControllers = angular.module('storeControllers',['ngRoute']);

storeControllers.controller('StoreCtrl', ['$scope', '$http', function ($scope, $http){

	$http({
    url: "http://127.0.0.1:49822/api/artigos",
    method: "GET",
    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
  }).success(function(response) {
    $scope.games = response;
    console.log(response);
});

}]);

storeControllers.controller('GameCtrl', ['$scope', '$http', function ($scope,$http){

}]);

