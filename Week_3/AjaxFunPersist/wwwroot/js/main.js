$().ready(function(){
    $.ajax({
        url:"/users",
        success:function(response){
            buildUsers(response);
        }
    })
})
$("form").submit(function(e){
    console.log("form submitted?");
    e.preventDefault();
    var formData = $(this).serialize(e);
    console.log($(this));
    console.log(formData);
    
    $.ajax({
        url:"/submit",
        method:"post",
        data:formData,
        success:function(response){
            buildUsers(response);
        }
    })
    
    $(this)[0].reset();
})
function buildUsers(data){
    $("#content").html("");
    for (var i = 0; i < data.length; i++) {
        var element = data[i];
        $("#content").append("<p>" + element.name + " from " + element.location + "</p>")
    }
}

$("button").click(function(){
    $("#content").append("<p>NEW CONTENT!</p>")
})