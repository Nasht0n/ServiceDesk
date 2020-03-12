$(document).on('change', '#branch', function () {

    var MyAppUrlSettings = {
        MyUsefulUrl: '@Url.Action("GetCategory", "Service")'
    }

    var url = '/Service/GetCategory';

    var categories = $('#category');
    var id = $(this).val();
    console.log(id);

    $.getJSON(url, { branch: id }, function (response) {
        categories.empty();
        $.each(response, function (index, item) {
            categories.append($('<option></option>').text(item.Name).val(item.Id));
        });
    });
});