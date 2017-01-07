app.controller('mainController', mainController);

function mainController($scope, $mdDialog, $mdSidenav, authService, $state) {
    $scope.title = 'EcoZone';
    $scope.description = 'экологический портал';

    $scope.showSearchDialog = function (ev) {
        var confirm = $mdDialog.prompt()
          .title('Поиск')
          .textContent('Введите текст или слово для поиска')
          .placeholder('Поиск...')
          .targetEvent(ev)
          .ok('Поиск!')
          .cancel('Отмена');

        $mdDialog.show(confirm).then(function (result) {
            $scope.status = 'You decided to name your dog ' + result + '.';
        }, function () {
            $scope.status = 'You didn\'t name your dog.';
        });
    };

    $scope.toggleSideNav = toggleSideNav("sideNav");

    function toggleSideNav() {
        return function () {
            $mdSidenav('sideNav')
                .toggle();
        };
    }

    $scope.close = function () {
        $mdSidenav('sideNav').close();
    };

    $scope.logOut = function () {
        $mdSidenav('sideNav').close();
        authService.logOut();
        $state.go("login");
    };

    $scope.authentication = authService.authentication;

    $scope.$on("$stateChangeError", function () {
        $state.go("login");
    });
}