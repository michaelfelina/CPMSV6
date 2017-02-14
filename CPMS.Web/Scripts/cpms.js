$(document)
        .ready(function () {
            $("#mainmenu .panel-toggle")
                .addClass("glyphicon glyphicon-plus");

            var list = $("#mainmenu .in");

            for (var i = 0; i < list.length; i++) {
                $("a[href='#" + $(list[i]).attr('id') + "']")
                    .next(".panel-toggle")
                    .removeClass("glyphicon-plus")
                    .addClass("glyphicon-minus");
            }

            $("#mainmenu")
                .on("hide.bs.collapse",
                    function (e) {
                        $("#" + e.target.id)
                            .prev()
                            .find(".panel-toggle")
                            .removeClass("glyphicon-minus")
                            .addClass("glyphicon-plus");
                    });

            $("#mainmenu")
                .on("show.bs.collapse",
                    function (e) {
                        $("#" + e.target.id)
                            .prev()
                            .find(".panel-toggle")
                            .removeClass("glyphicon-plus")
                            .addClass("glyphicon-minus");
                    });
        });