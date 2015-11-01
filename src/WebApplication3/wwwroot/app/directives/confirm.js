var app = angular.module('calendar');

app.directive('confirm', ['$window', function($window) {
    return {
        priority: 1,
        terminal: true,

        restrict: 'A',
        scope: false,

        link: function($scope, element, attributes, controller) {
            element.on('click', function(event) {
                var action = attributes.ngClick;

                if ($window.confirm(attributes.confirm)) {
                    $scope.$apply(function() {
                        $scope.$eval(action);
                    });
                } else {
                    event.stopPropagation();
                    event.stopImmediatePropagation();
                    event.preventDefault();

                    return false;
                }
            });
        }
    };
}]);
