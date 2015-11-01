var app = angular.module('calendar');

app.directive('dayPopover', ['$compile', function($compile) {
    return {
        restrict: 'A',
        scope: false,

        link: function($scope, element, attributes, controller) {
            var date      = attributes.dayPopover,
                placement = attributes.popoverPosition || 'auto',
                $element  = $(element);

            $element.popover({
                container: 'body',
                placement: placement,

                html: true,
                template:
                '<div class="popover day-popover-container">' +
                    '<div class="arrow"></div>' +
                    '<div role="tooltip">' +
                        '<div class="popover-content day-popover"></div>' +
                    '</div>' +
                '</div>',

                content: function() {
                    $('.popover').popover('hide');

                    return $compile('<day-panel date="' + date + '"></day-panel>')($scope.$parent);
                }
            });

            $element.on('show.bs.popover', function() {
                $element.addClass('popover-active');
            });

            $element.on('hide.bs.popover', function() {
                $element.removeClass('popover-active');
            });
        }
    };
}]);
