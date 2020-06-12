$.ajax({

    url: "../../../Manager/Layout/GetUsersInfo",
    type: "get",
    dataType: "json",
    success: function(data) {
        $("#usersName").text(data.NickName);
        var url = "../../../upload/Admins/" + data.SmallImage;
        $("#usersPhoto").attr("src", url);

    }


});