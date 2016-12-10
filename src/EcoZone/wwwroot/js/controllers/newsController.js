app.controller("newsController", newsController);

function newsController($scope, newsService) {
    $scope.title = "Новости";

    $scope.news = [];

    newsService.getNews(function (data) {
        $scope.news = data;
    });
}