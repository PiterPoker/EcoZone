app.config(routes);

function routes($stateProvider, $httpProvider, $urlRouterProvider) {
    
    $httpProvider.interceptors.push("authInterceptorService");
    
    var auth = function ($q, authService) {
        authService.fillAuthData();
        if (authService.authentication.isAuth) {
            return $q.when(authService.authentication);
        } else {
            return $q.reject({authenticated: false});
        }
    };

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
            url: "/profile/:id",
            templateUrl: "../app/profile.html",
            controller: "profileController",
            resolve: {
                auth: auth
            }
        })
        .state("users", {
            url: "/users",
            templateUrl: "../app/users.html",
            controller: "userController"
        })
        .state("settings", {
            url: "/settings",
            templateUrl: "../app/settings.html"
        })
        .state("help", {
            url: "/help",
            templateUrl: "../app/help.html"
        })
        .state("news", {
            url: "/news",
            templateUrl: "../app/news.html",
            controller: "newsController"
        })
        .state("history", {
            url: "/history",
            templateUrl: "../app/history.html",
            controller: "historyController"
        })
        .state("about", {
            url: "/about",
            templateUrl: "../app/about.html",
            controller: "aboutController"
        });
}