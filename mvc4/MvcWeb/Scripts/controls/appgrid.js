(function ($) {

    var methods = {
        init: function (options) {
            this.appgrid.settings = $.extend({}, this.appmenu.defaults, options);
        },

        load: function (options) {

                $.getjson(options.url, null, function (data) {
                               
                    var output = "";
                    if (data == null)
                        return;

                    var count = data.length;

                    for (var i = 0; i < count; i++) { 
                         output += output = "<tr>";

                        var jsize = data[i].length;
                      
                        for (var j = 0; j < jsize; j++) {
                            output += output = "<td>" + data[i][j] + "</td>";
                        }

                        output += output = "</tr>";
                    }

                    this.html(output);
                });
        }
    };

    $.fn.appmenu = function (methodOrOptions) {

        if (methods[methodOrOptions]) {
            return methods[methodOrOptions].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof methodOrOptions === 'object' || !methodOrOptions) {
            // Default to "init"
            return methods.init.apply(this, arguments);
        } else {
            $.error('Method ' + method + ' does not exist on jQuery.appgrid');
        }
    };

    $.fn.appgrid.defaults = {
       
    };

    $.fn.appgrid.settings = {}

})(jQuery);