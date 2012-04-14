(function ($) {

    var methods = {
        init: function (options) {
            this.appmenu.settings = $.extend({}, this.appmenu.defaults, options);
        },

        add: function (options) {

            var menuElement = this;            
            var html = menuElement.html();
            menuElement.html(html + "<li><a id='" + options.id + "' href='" + this.appmenu.settings.basePath + options.url + "'>" + options.text + "<a></li>");
            return this;
        }
    };

    $.fn.appmenu = function (methodOrOptions) {

        if (methods[methodOrOptions]) {
            return methods[methodOrOptions].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof methodOrOptions === 'object' || !methodOrOptions) {
            // Default to "init"
            return methods.init.apply(this, arguments);
        } else {
            $.error('Method ' + method + ' does not exist on jQuery.appmenu');
        }
    };

    $.fn.appmenu.defaults = {
        basePath: '/'
    };

    $.fn.appmenu.settings = {}

})(jQuery);