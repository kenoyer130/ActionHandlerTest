(function ($) {

    var cellRenderers;

    function defaultCellRenderer(options) {
        return "<td>" + options.obj[options.key] + "</td>";
    };

    var methods = {
        init: function (options) {
            this.appgrid.settings = $.extend({}, this.appmenu.defaults, options);
            cellRenderers = this.appgrid.cellRenderers;
            methods["addCellRenderer"]({ id: "default", callback: defaultCellRenderer });
        },

        addCellRenderer: function (options) {
            cellRenderers[options.id] = options.callback;
        },

        load: function (options) {

            base = this;

            if (!this.is("table"))
                throw exception("you must call this plugin from a table element!");

            // load column headers
            var headerTH = this.find("th");
            if (headerTH == null)
                throw exception("you need a th element in your table!");

            var tbody = this.find("tbody");
            if (tbody == null)
                throw exception("you need a tbody element in your table!");

            var header = {}

            // loop through and build our column array
            $.each(headerTH, function (index, headerth) {
                if (!headerth.attributes["class"]) {
                    header[headerth.id] = "";
                } else {
                    header[headerth.id] = headerth.attributes["class"].value;
                }
            });

            // call the indicated json rpc call
            $.getJSON(this.appgrid.settings.basePath + options.url, null, function (data) {

                var output = "";
                if (data == null)
                    return;

                // create array of rows
                var rows = new Array();

                // iterate each returned data row
                $.each(data, function (index, obj) {

                    var row = new Array(header.length);

                    // map the returned properties to the correct columns
                    for (key in obj) {
                        if (!obj.hasOwnProperty(key)) {
                            continue;
                        }

                        for (headerkey in header) {

                            if (header[headerkey] in cellRenderers) {
                                row[headerkey] = cellRenderers[header[headerkey]]({ key: key, obj: obj });
                            }
                            else {
                                row[headerkey] = cellRenderers["default"]({ key: key, obj: obj });
                            }
                        }
                    }

                    rows.push(row);
                });


                for (var i = 0; i < rows.length; i++) {
                    output += "<tr>";

                    for (key in rows[i]) {
                        output += rows[i][key];
                    }

                    output += "</tr>";
                }

                tbody.html(output);
            });
        }
    };

    $.fn.appgrid = function (methodOrOptions) {
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
        basePath: '/'
    };

    $.fn.appgrid.settings = {}
    $.fn.appgrid.cellRenderers = {}

})(jQuery);