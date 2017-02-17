$(document)
        .ready(function () {
            

            var lastState = localStorage.getItem("lastState");

            $(".mainheader").click(function (e) {
                $("#SystemInfo").addClass("in");
                lastState = [];
                localStorage.setItem("lastState", JSON.stringify(lastState));
            });

            if (!lastState) {
                lastState = [];
                localStorage.setItem("lastState", JSON.stringify(lastState));
            } else {
                lastStateArray = JSON.parse(lastState);
                var arrayLength = lastStateArray.length;
                for (var i = 0; i < arrayLength; i++) {
                    var panel = "#" + lastStateArray[i];
                    $(panel).addClass("in");
                }
            }

            $("#mainmenu").on("shown.bs.collapse", ".panel-collapse", function () {
                lastState = JSON.parse(localStorage.getItem("lastState"));
                if ($.inArray($(this).attr("id"), lastState) == -1) {
                    lastState.push($(this).attr("id"));
                };
                localStorage.setItem("lastState", JSON.stringify(lastState));
            });

            $("#mainmenu").on("hidden.bs.collapse", ".panel-collapse", function () {
                lastState = JSON.parse(localStorage.getItem("lastState"));
                lastState.splice($.inArray($(this).attr("id"), lastState), 1);
                localStorage.setItem("lastState", JSON.stringify(lastState));
            });

            $("#mainmenu .panel-toggle")
                .addClass("glyphicon glyphicon-plus");

            var resetMenu = $("#mainmenu .in");
            if (resetMenu.length < 1) {
                $("#SystemInfo").addClass("in");
            }

            var list = $("#mainmenu .in");

            for (var i = 0; i < list.length; i++) {
                $("a[href='#" + $(list[i]).attr("id") + "']")
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

        