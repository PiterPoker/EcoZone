app.controller('mainController', mainController);

function mainController($scope, $mdDialog) {
    $scope.title = 'EcoZone';
    $scope.description = 'экологический портал';

    $scope.showSearchDialog = function (ev) {
        var confirm = $mdDialog.prompt()
          .title('What would you name your dog?')
          .textContent('Bowser is a common name.')
          .placeholder('Dog name')
          .ariaLabel('Dog name')
          .initialValue('Buddy')
          .targetEvent(ev)
          .ok('Okay!')
          .cancel('I\'m a cat person');

        $mdDialog.show(confirm).then(function (result) {
            $scope.status = 'You decided to name your dog ' + result + '.';
        }, function () {
            $scope.status = 'You didn\'t name your dog.';
        });
    };
}