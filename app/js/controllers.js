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

            var cartArray = $cookies.getObject("games");

            var artigoId = $routeParams.artigoId;
            var nome = $scope.game.DescArtigo;
            var quantidade = 1;
            var preco = $scope.game.PVP1;
            var discount = $scope.game.Desconto;
            
            if(cartArray)
            {
                for(var i = 0; i < cartArray.length; i++)//for all items
                {
                    if(cartArray[i]["id"] === artigoId)
                        cartArray[i]["quantity"] = parseInt(cartArray[i]["quantity"]) +1;
                }
            }
            else
            {
                var cartArray = new Array();
                var game = {artigoId: artigoId, DescArtigo: nome, quantity: quantidade, PVP1: preco, Desconto: discount };
                cartArray.push(game);
            }
            $cookies.putObject("games", cartArray);
        }

/*
    $scope.addCart =function () {
        
        var id = $routeParams.artigoId;
        var name = $scope.game.DescArtigo;
        var quantity = 1;
        var price = $scope.game.PVP1;

        var infoArray = id+";"+name+";"+quantity+";"+price;
        console.log("infoArray: " + infoArray);


        var cartArray = $cookies.get("cart");

        //verify if there's already items stored
        if(cartArray)
        {
            var add = 1;//assuming no repeated item
            var cartArray = $cookies.get("cart").split(",");//splitting currents items into an array

            for(var i = 0; i < cartArray.length; i++)//for all items
            {
                var cartInfo = cartArray[i].split(";");//spliting item's information into an array
                
                if(cartInfo[0] === id)//if the item matches any existing item
                {
                    cartInfo[2] = parseInt(cartInfo[2]) + 1;//increase item quantity

                    cartArray[i] = cartInfo[0]+";"+cartInfo[1]+";"+cartInfo[2]+";"+cartInfo[3];//updating current info
                    
                    add = 0;//does not add at the end
                }
                console.log("cartInfo: "+cartInfo);
                console.log("cartArray: " + cartArray);
            }

            if(add)//if the item is not repeated
            {   
                console.log("adding");
                var temp = cartArray;
                cartArray = [temp, infoArray];
            }
        }
        else //no items stored
            cartArray = [infoArray];

        //stroing current items
        $cookies.put("cart",cartArray);

    }
*/
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



    //$scope.games = $cookies.get("cart").split(",");

    var games = $cookies.getObject("games");
/*    var games = new Array();
    for(var i = 0; i < gamesUnparsed.length;i++)
    {
        games[i]['id'] = gamesUnparsed[i][0];
        games[i]['name'] = gamesUnparsed[i][1];
        games[i]['quantity'] = gamesUnparsed[i][2];
        games[i]['price'] = gamesUnparsed[i][3];
    }
*/
    $scope.games = games;

    $scope.payment = function payment()
    {
        window.location = "#/payment";
    }

}]);

storeControllers.controller('PayCtrl', ['$scope', '$http', '$cookies', function ($scope,$http,$cookies){

    var games = $cookies.getObject("games");
    

}]);

