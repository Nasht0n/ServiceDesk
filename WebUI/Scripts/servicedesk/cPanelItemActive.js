$(document).ready(function () {
    $(document).on('click', '.nav-item a', function (e) {
        console.log("Click");
        $(this).parent().addClass('active').siblings().removeClass('active');
    });
});
