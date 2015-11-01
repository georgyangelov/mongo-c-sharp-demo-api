var app = angular.module('calendar');

app.controller('CalendarController', ['$scope', 'Task', function($scope, Task) {

    if (!$scope.year || !$scope.month) {
        var today = moment();

        $scope.year  = today.year();
        $scope.month = today.month();
    }

    $scope.weeks = [];

    update_month();

    $scope.$watch('year', update_month);
    $scope.$watch('month', update_month);

    $scope.previous_month = function() {
        var date = $scope.date.clone().subtract(1, 'months');

        $scope.year = date.year();
        $scope.month = date.month();
    };

    $scope.next_month = function() {
        var date = $scope.date.clone().add(1, 'months');

        $scope.year = date.year();
        $scope.month = date.month();
    };

    function update_month() {
        var date  = moment([$scope.year, $scope.month]),
            weeks = [],
            week  = [];

        $scope.date = date.clone();
        date = date.startOf('week');

        function push_date(other_month) {
            if (week.length == 7) {
                weeks.push(week);
                week = [];
            }

            week.push({
                other: other_month,
                today: today.year()  == date.year()  &&
                       today.month() == date.month() &&
                       today.date()  == date.date(),
                number: date.date(),
                date:   date.clone(),
                tasks:  Task.query_for_date({date: date.format('YYYY-MM-DD')})
            });

            date.add(1, 'days');
        }

        // Days before start of month
        while (date.month() != $scope.month) {
            push_date(true);
        }

        // Days of month
        while (date.month() == $scope.month) {
            push_date(false);
        }

        // Days after the end of the month
        while (week.length < 7) {
            push_date(true);
        }

        weeks.push(week);

        $scope.weeks = weeks;
    }

}]);
