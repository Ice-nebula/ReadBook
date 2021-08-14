$(document).ready(function () {
    // logout
    $("#SubmitLogout").click(function () {
        $("#LogoutForm").submit();
        return false;
    }); //end SubmitLogout
}); //end function.ready
function AlertError(Msg) {
    Swal.fire({
        title: "Error",
        text: Msg,
        background: "#ff0000"
    }); //end sweet alert
}