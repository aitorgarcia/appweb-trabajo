


function addElementCompileAngularToSelector($target, htmlCode, eliminarHtml, eliminarScope) {

    var htmlCode = (typeof htmlCode === 'string') ? htmlCode : null;

    // The new element to be added
    if (htmlCode != null) {
        var $div = $(htmlCode);

        // Si eliminarScope === true, elimina el scope
        if (eliminarScope === true) {
            try {
                var nodosHijos = $target.children();
                var scopeHijos = $target.children().scope();

                if (scopeHijos) {
                    scopeHijos.$destroy();
                    scopeHijos = null;
                }

                if (nodosHijos) {
                    nodosHijos.remove();
                    nodosHijos = null;
                }
            }
            catch (e) { }
        }

        // Si eliminarHtml === true, elimina todo el contenido html
        if (eliminarHtml === true) {
            $target.empty();
        }

        var injector = angular.element($target).injector();
        if (typeof injector !== 'undefined') {
            injector.invoke(['$compile', function ($compile) {
                var $scope = angular.element($target).scope();
                $target.append($div);
                $compile($div)($scope);
                // Finally, refresh the watch expressions in the new element
                if (!$scope.$$phase)
                    $scope.$apply();
            }]);
        }
    }
}