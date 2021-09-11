$(function ()
{
    $.get("../FrontEndLayout/GetLists", function (data) {

        var url = window.location.pathname.substr(1);

        var str = "";

        for (var i = 0; i < data.length; i++)
        {
            if (url == data[i].Link) {
                str += "<li class='fh5co-active'>";
            }
            else
            {
                str += "<li>";
            }
            
            str += "<a href='../" + data[i].Link + "' >" + data[i].Title + "</a>";
            str+="</li>"
        }

        $("#navList").html(str);

    }, "json");


})