$(".jazzAbtn").click(function () {
    var id = $(this).attr("id");
    var title = $(".jazz_page_actinfosection h3#" + id).text();
    console.log(title);
    $(".modaltitle").text(title);

    modal.style.display = "block";

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }
    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

});

// Get the modal
var modal = document.getElementById('myModal');

// Get the button that opens the modal
var btn = document.getElementsByClassName("jazz_page_program_passpartout")[0];

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal 
btn.onclick = function () {
    
}


function myFunction0() {
    var x = document.getElementsByClassName("example");
    x[0].innerHTML = "Hello World! + 0";
}
