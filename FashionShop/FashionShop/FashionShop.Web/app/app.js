﻿/// <reference path="../assets/admin/libs/angular.js" />
(function () {
    angular.module('fashionshop', ['fashionshop.products', 'fashionshop.product_categories' ,'fashionshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();