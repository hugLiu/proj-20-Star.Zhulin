function Retrieve(id, urlStr, _apiPath, _achieveDown) { 
    $.ajax({ 
        url: _apiPath + "/DataService/Retrieve", //url: "http://192.168.1.239:8811/API/DataService/Retrieve",
        type: "get",
        data: { url: urlStr },
        async: false,
        success: function (result) { 
            var ticket = result[0].ticket;
            var format = result[0].format.toLocaleLowerCase();
            var name = result[0].name; 
            download(id, urlStr, ticket, format, name, _achieveDown);
        }
    });
}
function download(id, urlStr, ticket, format, name, _achieveDown) {
    var title = "";
    if (name && name != "") {
        title = name.substring(0, name.indexOf("."));
    } 
    $("#id").val(id);
    $("#title").val(title);
    $("#url").val(urlStr);
    $("#ticket").val(ticket);
    $("#format").val(format);
    $("#name").val(name); 
    var url = _achieveDown + "FileInfo/DownLoad"; //'http://192.168.1.239:8810/FileInfo/DownLoad';
    url = encodeURI(url);
    $("#formDown").attr('action', url);
    $("#formDown").submit();
}