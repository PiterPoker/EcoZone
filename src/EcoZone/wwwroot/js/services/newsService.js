app.factory("newsService", newsService);

function newsService($http) {
    var news = [];
    return {
        getNews: function (callback) {
            $http.get("/api/news")
                .success(function (data) {
                    news = data;
                    callback(data);
                })
                .error(function () {
                    console.error("Problem with getting news from the server");
                });
        }
    };
}