$("body").on("click", "#btnAddReplaceComponent", function (val) {
    var table = document.getElementById("tblReplaceComponents");
    var counter = table.rows.length - 2;
    var componentDropDown = document.getElementById("Components");
    var selectedText = componentDropDown.options[componentDropDown.selectedIndex].text;
    var selectedValue = componentDropDown.options[componentDropDown.selectedIndex].value;
    var count = $("#Count");
    var tBody = $("#tblReplaceComponents > TBODY")[0];
    var row = tBody.insertRow(-1);

    var cell = $(row.insertCell(-1));
    var innerComponentId = '<input type="hidden" class="readonly" name="Model.Replaces[' + counter + '].ComponentId" value="' + selectedValue + '"/>';
    cell.attr("class", "d-none");
    cell.html(innerComponentId);

    var cell = $(row.insertCell(-1));
    var innerEquipmentTypeModelId = '<input type="hidden" class="readonly" name="Model.Replaces[' + counter + '].ComponentModel.Id" value="' + selectedValue + '"/>';
    cell.attr("class", "d-none");
    cell.html(innerEquipmentTypeModelId);

    var cell = $(row.insertCell(-1));    
    var innerEquipmentText = '<input type="text" class="form-control tblItem bg-white border-0" readonly name="Model.Replaces[' + counter + '].ComponentModel.Name" value="' + selectedText + '"/>';
    cell.attr("class", "w-100");
    cell.html(innerEquipmentText);

    var cell = $(row.insertCell(-1));    
    var innerCount = '<input type="text" class="form-control tblItem bg-white border-0" readonly name="Model.Replaces[' + counter + '].Count" value="' + count.val() + '"/>';
    cell.attr("class", "w-100");
    cell.html(innerCount);

    var cell = $(row.insertCell(-1));    
    var btnRemove = '<button type="button" value="Удалить" class="btn btn-danger w-100" onclick="Remove(this)"> <i class="fa fa-trash" ></i> </button >';
    cell.attr("class", "w-100");
    $("#Components").prop('selectedIndex', 0);
    cell.append(btnRemove);
    count.val("");
});

$(".table tbody").on("click", ".btn", function () {
    $(this).closest("TR").remove();
});