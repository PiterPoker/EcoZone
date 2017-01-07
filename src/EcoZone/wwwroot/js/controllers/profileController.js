app.controller("profileController", profileController);

function profileController($scope, $state, $stateParams, authService, profileService, $mdDialog, $mdToast) {
    $scope.profile = {};
    $scope.image = null;
    var profileId = $stateParams.profileId;

    profileService.getProfile(profileId, function (data) {
        if (data != "Пльзователь не найден.") {
            $scope.profile = data;
            $scope.image = data.photo == null ? null : "data/profile_photos/" + data.photo;
        } else {
            $state.go("Admin");
            $mdToast.show($mdToast.simple().textContent(data).position('bottom right').hideDelay(3000));
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

    $scope.showProfileImageModal = function (ev) {
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
            });
    };
}