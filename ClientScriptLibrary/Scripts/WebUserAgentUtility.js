// Web user agent utility is an utility class to check container of this website

function WebUserAgentUtility() {

    this.GetContainer = function () {
        var result = "";
        if (navigator.userAgent.match(/iPhone/i)) {
            result = "iphone";
        } else if (navigator.userAgent.match(/android/i)) {
            result = "android";
        } else if (navigator.userAgent.match(/ipad/i)) {
            result = "ipad";
        } else if (navigator.userAgent.match(/firefox/i)) {
            result = "firefox";
        } else if (navigator.userAgent.match(/msie/i) || navigator.userAgent.match(/trident/i)) {
            result = "ie";
        }
        return result;
    }

    this.GetVersion = function () {
        var result = "";
        result = navigator.appVersion;
        return result;
    }

}