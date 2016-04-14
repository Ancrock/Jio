/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
$(document).ready(function () {
    $("#cart_in").hide().delay(800).fadeIn();
});

$(function () {
    $(".menuclick").hover(function () {
        $(this).css("border", "dotted red").css("background-color", "whitesmoke");
    }, function () {
        $(this).css("border", "dotted black").css("background-color", "white");

    });
});



$(function () {
    $("#login-button").hover(function () {
        $(this).css("background-color", "#000099");
    }, function () {
        $(this).css("background-color", "#3333ff");
    });
});


$(function () {
    $("#backblur").click(function () {
        $(this).hide();
        $("#login-page").hide();
        $("#reg-popup").hide();
        $("#order-extras").hide();
    });
});

function updatelogin() {
    var container = $(window);
    var top = -$("#login-page").height() / 2;
    var left = -$("#login-page").width() / 2;
    return $("#login-page").css('position', 'fixed').css({ 'margin-left': left + 'px', 'margin-top': top + 'px', 'left': '50%', 'top': '50%' });
}

$(function () {
    $("#login-button").click(function () {
        $("#backblur").fadeIn();
        $(".llink").css('background-color', 'gray');
        $("#reg-popup").fadeOut();
        $("#login-page").fadeIn();
        updatelogin();
    });
});

$(function () {
    $(".llink").click(function () {
        $("#reg-popup").hide();
        $("#login-page").fadeIn();
        $(".rlink").css('background-color', 'white');
        $(".llink").css('background-color', 'gray');
        updatelogin();
    });
});

$(function () {
    $(".rlink").click(function () {
        $(".llink").css('background-color', 'white');
        $(".rlink").css('background-color', 'gray');
        $("#login-page").hide();
        updatereg();
        $("#reg-popup").fadeIn();

    });
});

function updatereg() {
    var container = $(window);
    var top = -$("#reg-popup").height() / 2;
    var left = -$("#reg-popup").width() / 2;
    return $("#reg-popup").css('position', 'fixed').css({ 'margin-left': left + 'px', 'margin-top': top + 'px', 'left': '50%', 'top': '50%' });

}

$(function () {
    $("#login-submit").click(function () {
        $("h2").css('width', '65%');
        $("#login-page").hide();
        $("#reg-popup").hide();
        $("#backblur").hide();
        $("#login-button").hide();
        $("#welcome").fadeIn();

    });
});



$(function () {
    $(".menuclick").click(function () {
        var title = $(this).find("h1").html();
        var price = $(this).find("p").html();
        var description = $(this).find("article").html();
        $("#backblur").fadeIn();
        $("#title").text(title);
        $("#price").text(price);
        $("#description").text(description);
        updateorder();
        $("#order-extras").fadeIn();
    });
});

function updatereg() {
    var container = $(window);
    var top = -$("#reg-popup").height() / 2;
    var left = -$("#reg-popup").width() / 2;
    return $("#reg-popup").css('position', 'fixed').css({ 'margin-left': left + 'px', 'margin-top': top + 'px', 'left': '50%', 'top': '50%' });

}
function updateorder() {
    var container = $(window);
    var top = -$("#order-extras").height() / 2;
    var left = -$("#order-extras").width() / 2;
    return $("#order-extras").css('position', 'fixed').css({ 'margin-left': left + 'px', 'margin-top': top + 'px', 'left': '50%', 'top': '50%' });

}


$(function () {
    $("#minus").click(function () {
        var m = $("#order-extras").find("#qty").val();
        if (m > 0) {
            m = m - 1;
        }
        $("#qty").val(m);

    });
});

$(function () {
    $("#plus").click(function () {
        var m = $("#order-extras").find("#qty").val();
        m++;
        $("#qty").val(m);

    });
});

$(function () {
    $("#add").click(function () {
        var title = $("#order-extras").find("#title").html();
        var price = $("#order-extras").find("#price").html();
        var qty = $("#order-extras").find("#qty").val();


    });
});


