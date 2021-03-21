// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function (){
    $('.done-checkbox').on('click',function (e) {
        //找到所有复选框.当被点击的时候,触发以下事件即:markCompleted
        markCompleted(e.target);
    });
});

function markCompleted(checkbox){
    checkbox.disable=true;
    
    var row=checkbox.closest('tr');
    $(row).addClass('done');
    
    var form=checkbox.closest('form');
    form.submit();
}
