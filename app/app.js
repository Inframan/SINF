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
        templateUrl: 'partials/catalog.html',
        controller: 'storeCtrl'
      }).
      when('/artigo/:artigoId', {
        templateUrl: 'partials/game.html',
        controller: 'gameCtrl'
      }).
      otherwise({
        redirectTo: '/home'
      });
  }]);
