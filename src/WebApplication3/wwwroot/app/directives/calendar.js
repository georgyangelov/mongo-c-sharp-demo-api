var app = angular.module('calendar');

app.directive('calendar', ['Task', function(Task) {
    return {
        scope: {},

        controller: 'CalendarController',
        templateUrl: 'app/views/calendar.html'
    };
}]);
