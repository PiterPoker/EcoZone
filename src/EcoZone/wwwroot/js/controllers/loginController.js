app.controller("loginController", loginController);

function loginController($scope, $state, authService) {
    $scope.title = "Вход";
    $scope.activeLoeder = false;
    
    authService.logOut();

    $scope.loginData = {
        email: "",
        password: ""
    };

    $scope.validation = {
        email: /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/
    };

    $scope.login = function () {
        if ($scope.loginForm.$valid) {
            $scope.activeLoader = true;
            authService.login($scope.loginData,
                function (result) {
                    if (result == "OK") {
                        $scope.message = "Вход прошел успешно.";
                        $scope.activeLoader = false;
                        $state.go("profile", {profileId: authService.authentication.id});
                    } else {
                        $scope.activeLoader = false;
                    }
                });
        }
    };
}