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

            var thElements = this.find("th");
            if (thElements == null)
                throw exception("you need a th element in your table!");

            var tbody = this.find("tbody");
            if (tbody == null)
                throw exception("you need a tbody element in your table!");

            var header = {}

            // loop through and build our column array
            $.each(thElements, function (index, thElement) {
                if (!thElement.attributes["class"]) {
                    header[thElement.id] = "";
                } else {
                    header[thElement.id] = thElement.attributes["class"].value.split(' ');
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
                    for (headerkey in header) {
                        for (key in obj) {
                            if (!obj.hasOwnProperty(key)) {
                                continue;
                            }

                            if (headerkey != key)
                                continue;

                            // if no class styles use default renderer
                            if (header[headerkey].length == 0) {
                                row[headerkey] = cellRenderers["default"]({ key: key, obj: obj });
                                continue;
                            }

                            var styleFound;

                            // if the style maps to a cell renderer use that
                            for (style in header[headerkey]) {

                                if (header[headerkey][style] in cellRenderers) {

                                    row[headerkey] = cellRenderers[header[headerkey][style]]({ key: key, obj: obj });
                                    styleFound = true;
                                    break;
                                }
                            }

                            if (!styleFound)
                                row[headerkey] = cellRenderers["default"]({ key: key, obj: obj });
                        }
                    }

                    rows.push(row);
                });

                // output our rows
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