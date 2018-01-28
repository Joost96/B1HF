var MethodButton1 = document.getElementById("#Method1");
var MethodButton2 = document.getElementById("#Method2");
var MethodButton3 = document.getElementById("#Method3");
var MethodButton4 = document.getElementById("#Method4");
var Method;

$(".PaymentMethod").click(function () {
    Method = $(this).val();
});