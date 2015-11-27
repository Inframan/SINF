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
    });

}]);

storeControllers.controller('GameCtrl', ['$scope', '$http', '$routeParams', function ($scope,$http,$routeParams){

   
	var s = $routeParams.artigoId;

    $http({
        url: "http://127.0.0.1:49822/api/artigos/" +s,
        method: "GET",
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
      }).success(function(response) {
        $scope.game = response;
        console.log(response);
    });


}]);




storeControllers.controller('OrderCtrl', ['$scope', '$http', '$routeParams', function ($scope,$http,$routeParams){

    var s = $routeParams.clientId;

    $http({
        url: "http://127.0.0.1:49822/api/DocVenda/" + s,  //versão final
        //url: "http://127.0.0.1:49822/api/DocVenda/C0001",//para teste, as encomenas do cliente C0001
        method: "GET",
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
      }).success(function(response) {
        $scope.orders = response;
    });

}]);

