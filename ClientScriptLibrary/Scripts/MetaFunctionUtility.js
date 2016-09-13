
// Meta function is an utility class to check for function
//
function MetaFunctionUtility() {
    this.isFunction = function (functionToCheck) {
        var tempType = {};
        return functionToCheck && tempType.toString.call(functionToCheck) === '[object Function]';
    }

    this.isObject = function (functionToCheck) {
        var tempType = {};
        return functionToCheck && tempType.toString.call(functionToCheck) === '[object object]';
    }

    this.isDefinedOrNotNull = function (functionToCheck) {
        var tempType = {};
        return functionToCheck !== undefined && functionToCheck !== null;
    }
}