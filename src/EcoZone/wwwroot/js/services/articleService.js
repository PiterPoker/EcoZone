app.factory("articleService", articleService);

function articleService($http) {
    return {
        getNews: function (callback) {
            $http.get("/api/createarticle").then(function successCallback(response) {
                callback(response.data);
            }, function errorCallback(error) {
                console.error("Problem with getting news from the server" + error);
            });
        }
    }
}