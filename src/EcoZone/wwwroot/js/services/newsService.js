app.factory("newsService", newsService);

function newsService($http) {
    return {
        getNews: function (callback) {
            $http.get("/api/news").then(function successCallback(response) {
                callback(response.data);
            }, function errorCallback(error) {
                console.error("Problem with getting news from the server" + error);
            });
        }
    };
}