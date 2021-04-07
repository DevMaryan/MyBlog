//function StarCounter() {
//    var counter_number = document.getElementById('counter_number').value;
//    var star_span = document.getElementById('star_rate');
//    if (counter_number == 1) {
//        star_span.innerHTML = "<i class='fas fa-star' ></i>"
//    } else if (counter_number == 2) {
//        star_span.innerHTML = "<i class='fas fa-star' ></i><i class='fas fa-star' ></i>"
//    } else if (counter_number == 3) {
//        star_span.innerHTML = "<i class='fas fa-star' ></i><i class='fas fa-star' ></i><i class='fas fa-star' ></i>"
//    }else if (counter_number == 4) {
//        star_span.innerHTML = "<i class='fas fa-star' ></i><i class='fas fa-star' ></i><i class='fas fa-star' ></i><i class='fas fa-star' ></i>"
//    }
//    else if (counter_number == 5) {
//        star_span.innerHTML = "<i class='fas fa-star' ></i><i class='fas fa-star' ></i><i class='fas fa-star' ></i><i class='fas fa-star' ></i><i class='fas fa-star' ></i>"
//    }
//}


var star_1 = document.getElementById('star_1');
star_1.addEventListener('click', function () {
    var x = document.getElementById("counter_number");
    star_1.style.color = "gold";
    star_2.style.color = "gray";
    star_3.style.color = "gray";
    star_4.style.color = "gray";
    star_5.style.color = "gray";
    x.value = 1;
})
star_1.addEventListener('mouseover', function () {
    var x = document.getElementById("counter_number");
    x.value = 1;
    star_1.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_2.innerHTML = "<i class='far fa-star' style='color:gray'></i>";
    star_3.innerHTML = "<i class='far fa-star' style='color:gray'></i>";
    star_4.innerHTML = "<i class='far fa-star' style='color:gray'></i>";
    star_5.innerHTML = "<i class='far fa-star' style='color:gray'></i>";
})

var star_2 = document.getElementById('star_2');
star_2.addEventListener('click', function () {
    var x = document.getElementById("counter_number");
    star_1.style.color = "gold";
    star_2.style.color = "gold";
    star_3.style.color = "gray";
    star_4.style.color = "gray";
    star_5.style.color = "gray";
    x.value = 2;
})
star_2.addEventListener('mouseover', function () {
    var x = document.getElementById("counter_number");
    x.value = 2;
    star_1.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_2.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_3.innerHTML = "<i class='far fa-star' style='color:gray'></i>";
    star_4.innerHTML = "<i class='far fa-star' style='color:gray'></i>";
    star_5.innerHTML = "<i class='far fa-star' style='color:gray'></i>";
})

var star_3 = document.getElementById('star_3');
star_3.addEventListener('click', function () {
    var x = document.getElementById("counter_number");
    star_1.style.color = "gold";
    star_2.style.color = "gold";
    star_3.style.color = "gold";
    star_4.style.color = "gray";
    star_5.style.color = "gray";
    x.value = 3;
})
star_3.addEventListener('mouseover', function () {
    var x = document.getElementById("counter_number");
    x.value = 3;
    star_1.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_2.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_3.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_4.innerHTML = "<i class='far fa-star' style='color:gray'></i>";
    star_5.innerHTML = "<i class='far fa-star' style='color:gray'></i>";
})

var star_4 = document.getElementById('star_4');
star_4.addEventListener('click', function () {
    var x = document.getElementById("counter_number");
    star_1.style.color = "gold";
    star_2.style.color = "gold";
    star_3.style.color = "gold";
    star_4.style.color = "gold";
    star_5.style.color = "gray";
    x.value = 4;
})
star_4.addEventListener('mouseover', function () {
    var x = document.getElementById("counter_number");
    x.value = 4;
    star_1.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_2.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_3.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_4.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_5.innerHTML = "<i class='far fa-star' style='color:gray'></i>";
})

var star_5 = document.getElementById('star_5');
star_5.addEventListener('click', function () {
    var x = document.getElementById("counter_number");
    star_1.style.color = "gold";
    star_2.style.color = "gold";
    star_3.style.color = "gold";
    star_4.style.color = "gold";
    star_5.style.color = "gold";
    x.value = 5;
})
star_5.addEventListener('mouseover', function () {
    var x = document.getElementById("counter_number");
    x.value = 5;
    star_1.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_2.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_3.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_4.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
    star_5.innerHTML = "<i class='fas fa-star' style='color:gold'></i>";
})
