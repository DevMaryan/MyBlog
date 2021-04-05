function CheckLength() {
    var vrednost = document.querySelector('textarea');
    var msg_small = document.getElementById('msg_small');
    var btn = document.getElementById('comment_btn');
    var total = vrednost.value;
    if (total.length > 4 && total != null) {
        msg_small.innerText = ""
        btn.style.display = "block";
    } else {
        msg_small.innerText = "oops type more than 4 characters";
        btn.style.display = "none";
    }
}
