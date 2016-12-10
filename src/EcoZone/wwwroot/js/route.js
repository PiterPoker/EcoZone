app.config(routes);

function routes($stateProvider, $httpProvider, $urlRouterProvider) {
    //$httpProvider.interceptors.push("authInterceptorService");

    /*var Auth = function ($q, authService) {
     authService.fillAuthData();
     if (authService.authentication.isAuth) {
     return $q.when(authService.authentication);
     } else {
     return $q.reject({authenticated: false});
     }
     };*/

    $urlRouterProvider.otherwise("/");

    $stateProvider
        .state("main", {
            url: "/",
            templateUrl: "/home/index",
            controller: "mainController",
            abstract: true
        })
        .state("login", {
            url: "/login",
            templateUrl: "../app/account/login.html",
            controller: "loginController"
        })
        .state("signup", {
            url: "/signup",
            templateUrl: "../app/account/signup.html",
            controller: "signupController"
        })
        .state("profile", {
            url: "/profile",
            templateUrl: "../app/profile.html",
            controller: "profileController",
        })
        .state("users", {
            url: "/users",
            templateUrl: "../app/users.html",
            controller: "userController",
        })
        .state("settings", {
            url: "/settings",
            templateUrl: "../app/settings.html",
        })
        .state("help", {
            url: "/help",
            templateUrl: "../app/help.html",
        })
        .state("news", {
            url: "/news",
            templateUrl: "../app/news.html",
            controller: "newsController"
        })
        .state("navigation", {
            url: "/navigation",
            templateUrl: "../app/navigation.html",
            controller: "navigationController"
        });
}