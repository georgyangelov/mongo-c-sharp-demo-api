var app = angular.module('calendar');

app.factory('Task', ['$resource', '$window', function($resource, $window) {
    var task_resource = $resource($window.api_base_url + '/tasks/:id', {}, {
        update: {
            method: 'PUT'
        },
        query_for_date: {
            method:  'GET',
            url:    $window.api_base_url + '/tasks/for_date/:date',
            isArray: true
        }
    });

    $window.Task = task_resource;

    return task_resource;
}]);
