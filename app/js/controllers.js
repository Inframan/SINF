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

storeControllers.controller('GameCtrl', ['$scope', '$http', '$routeParams', '$cookies', function ($scope,$http,$routeParams,$cookies){

   
	var s = $routeParams.artigoId;

    $http({
        url: "http://127.0.0.1:49822/api/artigos/" +s,
        method: "GET",
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
      }).success(function(response) {
        $scope.game = response;
    });


    $scope.addCart =function () {
        
        var cartArray = $cookies.get("cart");
        if(cartArray.length > 0){
            var temp = cartArray;
            cartArray = [temp, $routeParams.artigoId];
        }
        else
            cartArray = [$routeParams.artigoId];
        $cookies.put("cart",cartArray);

    }

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


storeControllers.controller('CartCtrl', ['$scope', '$http', '$cookies', function ($scope,$http,$cookies){

    //var s = $routeParams.clientId;


    console.log($cookies.get("cart"));

    $scope.games = $cookies.get("cart").split(",");


}]);

