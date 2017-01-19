app.controller("createArticleController", createArticleController);

function createArticleController($scope, $mdDialog, tagService) {
    $scope.title = 'Создание статьи';
    $scope.status = '  ';
    $scope.customFullscreen = false;
    $scope.tags = [];
    $scope.article = {
        name: '',
        tags: [],
        blocks: []
    };

    tagService.getTags(function (data) {
        $scope.tags = data;
    });

    $scope.showAddBlockModal = function (ev) {
        $mdDialog.show({
            controller: articleBlockTypeModal,
            templateUrl: '../app/article/_blockTypeModal.html',
            parent: angular.element(document.body),
            targetEvent: ev,
            clickOutsideToClose: true
        })
            .then(function (answer) {
                var block = {
                    text: '',
                    image: null,
                    blockType: answer
                };
                $scope.article.blocks.push(block);
            }, function () {
                $scope.status = 'You cancelled the dialog.';
            });
    };
}