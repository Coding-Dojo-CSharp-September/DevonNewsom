$().ready(function(){

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
            $("#content").append("<p>" + response.name + " from " + response.location + "</p>")
        }
    })
    
    $(this)[0].reset();
})

$("button").click(function(){
    $("#content").append("<p>NEW CONTENT!</p>")
})