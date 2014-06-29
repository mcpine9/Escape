$(function(){
    $(".brancheBlock").each(function() {
        if($(this).html() === "") {
            $(this).hide();
        }
    });
    
    masterpage.initMenu();
});