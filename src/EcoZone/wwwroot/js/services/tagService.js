app.factory("tagService", tagService);

function tagService($http) {
    return {
        createTag: function (tagName, callback) {
            $http({
                url: "/api/tag/create",
                method: "POST",
                dataType: "json",
                data: JSON.stringify(tagName),
                headers: {
                    "Content-Type": "application/json"
                }
            }).then(
                function successCallback(response) {
                    callback(response.data);
                }, function errorCallback(error) {
                    console.error("Problem with creating discipline " + error);
                }
            );
        },
        getTags: function (callback) {
            $http({
                url: "/api/tag/",
                method: "GET"
            }).then(
                function successCallback(response) {
                    callback(response.data);
                }, function errorCallback(error) {
                    console.error("Problem with creating discipline " + error);
                }
            );
        }
    }
}