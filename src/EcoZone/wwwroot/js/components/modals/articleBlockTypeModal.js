app.controller("articleBlockTypeModal", articleBlockTypeModal);

function articleBlockTypeModal($scope, $sce, $mdDialog) {
    $scope.blockTypes = [{
        name: "Текст",
        icon: $sce.trustAsHtml('<i class="fa fa-align-center"></i>')
    }, {
        name: "Видео",
        icon: $sce.trustAsHtml('<i class="fa fa-youtube-play"></i>')
    }, {
        name: "Изображение",
        icon: $sce.trustAsHtml('<i class="fa fa-picture-o"></i>')
    }, {
        name: "Текс, Изображение",
        icon: $sce.trustAsHtml('<i class="fa fa-align-left"></i><i class="fa fa-picture-o"> </i>')
    }, {
        name: "Изображение, Текст",
        icon: $sce.trustAsHtml('<i class="fa fa-picture-o"> </i><i class="fa fa-align-left"></i>')
    }];

    $scope.selectedBlockIndex = null;

    $scope.cancel = function () {
        $mdDialog.cancel();
    };

    $scope.answer = function () {
        $mdDialog.hide($scope.selectedBlockIndex);
    };
}