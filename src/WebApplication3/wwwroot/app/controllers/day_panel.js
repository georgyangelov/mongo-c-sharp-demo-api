var app = angular.module('calendar');

app.controller('DayPanelController', ['$scope', 'Task', function($scope, Task) {
    $scope.add_task_state = false;

    $scope.show_add_task = function(task) {
        if (task) {
            $scope.task = task;
            $scope.editting_task = true;
        } else {
            $scope.task = {};
            $scope.editting_task = false;
        }

        $scope.add_task_state = true;
    };

    $scope.cancel_add_task = function() {
        $scope.add_task_state = false;
    };

    $scope.$watch('date', refresh);

    function refresh() {
        $scope.tasks = Task.query_for_date({date: $scope.date.format('YYYY-MM-DD')});
    }

    $scope.add_task = function() {
        $scope.task.date = $scope.date.toDate();

        if (!$scope.task.title) {
            return;
        }

        if ($scope.editting_task) {
            Task.update($scope.task, success);
        } else {
            Task.save($scope.task, success);
        }

        function success() {
            refresh();
            $scope.cancel_add_task();
        }
    };

    $scope.delete_task = function(task) {
        Task.delete(task, function() {
            refresh();
        });
    };

    $scope.mark_task_as_completed = function(task) {
        task.completed = !task.completed;

        Task.update(task);
    };
}]);
