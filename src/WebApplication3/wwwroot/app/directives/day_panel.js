var app = angular.module('calendar');

app.directive('dayPanel', [function() {
    return {
        scope: {},

        controller: 'DayPanelController',
        templateUrl: 'app/views/day_panel.html',

        link: function($scope, element, attributes, controller) {
            $scope.date = moment(attributes.date);
        }
    };
}]);
