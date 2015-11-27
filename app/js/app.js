'use strict';



/* App Module */

var gameApp = angular.module('gameApp', [
  'ngRoute',
  'storeControllers'
]);

gameApp.config(['$routeProvider',
  function($routeProvider) {
    $routeProvider.
      when('/home', {
        templateUrl:'partials/catalog.html',
        controller: 'StoreCtrl'
      }).
      when('/artigo/:artigoId', {
        templateUrl: 'partials/game.html',
        controller: 'GameCtrl'
      }).
      when('/orders/:clientId', {
        templateUrl: 'partials/orders.html',
        controller: 'OrderCtrl'
      }).
      otherwise({
        redirectTo: '/home'
      });
  }]);
