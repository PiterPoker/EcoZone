app.controller("profileController", profileController);

function profileController($scope, $state, $stateParams, $mdToast, $mdDialog, profileService, authService) {
    $scope.profile = {};
    $scope.image = null;
    $scope.firstname = [];
    $scope.lastname = [];
    $scope.role = [];

    var profileId = $stateParams.id;

    profileService.getProfile(profileId, function (data) {
        if (data != "Пльзователь не найден.") {
            $scope.profile = data;
            $scope.image = data.photo == null ? null : "data/profile_photos/" + data.photo;
        }
    });

    $scope.getRole = function (role) {
        switch (role) {
            case "Admin":
                return "Администратор";
            case "User":
                return "Пользователь";
            case "Author":
                return "Автор";
            case "Moderator":
                return "Модератор";
        }
    };

    $scope.isInRole = function (role) {
        var isInRole = false;
        angular.forEach($scope.profile, function (userRole) {
            if (userRole == role) {
                isInRole = true;
            }
        });
        return isInRole;
    };

    $scope.isCurrent = function () {
        var currentProfileId = authService.authentication.id;
        return profileId == currentProfileId || profileId == "";
    };

    $scope.isAdmin = function () {
        var isAdmin = false;
        angular.forEach($scope.profile.roles, function (role) {
            if (role == "Admin") {
                isAdmin = true;
            }
        });
        return isAdmin;
    };

    $scope.isUser = function () {
        var isUser = false;
        angular.forEach($scope.profile.roles, function (role) {
            if (role == "User") {
                isUser = true;
            }
        });
        return isUser;
    };

    $scope.getRole = function (role) {
        return authService.getRole(role);
    };

    $scope.showProfileImageModal = function (ev) {
        if (!$scope.isCurrent) return;
        $mdDialog.show({
            controller: 'ProfileImageLoaderController',
            templateUrl: '../app/partials/profileImageLoaderView.html',
            parent: angular.element(document.body),
            targetEvent: ev,
            clickOutsideToClose: false,
            fullscreen: false
        }).then(
            function (response) {
                $scope.image = response;
            },
            function (response) {
            });
    };
}