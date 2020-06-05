$.ajax({
    url: "../../../Manager/Layout/LeftMenuBind",
    dataType: "json",
    type: "get",
    success: function(data) {
        var str = "";
        for (let i = 0; i < data.length; i++) {
            str += "<li>";
            str += "<a href='#"+data[i].Title+"' data-toggle='collapse' class='collapsed'><i class='lnr "+data[i].Icon+"'></i> <span>"+data[i].Title+"</span> <i class='icon-submenu lnr lnr-chevron-left'></i></a>";
            str += "<div id='" + data[i].Title + "' class='collapse'>";
            str += "<ul class='nav'>";
            for (let j = 0; j < data[i].SonList.length; j++) {
                str += "<li><a href='" + data[i].SonList[j].Link + "' class=''>" + data[i].SonList[j].Title+"</a></li>";
            }
            str += "</ul>";
            str += "</div>";
            str += "</li>";
        }
        $("#leftSidebar").html(str);
    }
});