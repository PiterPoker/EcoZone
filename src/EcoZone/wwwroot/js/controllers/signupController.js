app.controller("signupController", signupController);

function signupController($scope, $state, $element, authService) {
    $scope.title = "Регистрация";
    $scope.savedSuccessfully = false;
    $scope.message = "";
    $scope.activeLoader = false;

    $scope.registration = {
        firstName: "",
        lastName: "",
        email: "",
        password: "",
        confirmPassword: ""
    };

    $scope.validation = {
        email: /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/
    };

    $scope.signUp = function () {
        if ($scope.signUpForm.$valid) {
            $scope.activeLoader = true;
            authService.signUp($scope.registration,
                function (result) {
                    if (result == "OK") {
                        $scope.message = "Регистрация прошла успешно.";
                        $scope.activeLoader = false;
                        $state.go("profile", {profileId: authService.authentication.id});
                    } else {
                       $scope.activeLoader = false;
                    }
                });
        }
    };
}