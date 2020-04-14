$("body").on("click", "#btnAddInstallationEquipments", function (val) {
    var table = document.getElementById("tblInstallationEquipments");
    var counter = table.rows.length - 2;
    var equipmentDropDown = document.getElementById("EquipmentTypes");
    var selectedText = equipmentDropDown.options[equipmentDropDown.selectedIndex].text;
    var selectedValue = equipmentDropDown.options[equipmentDropDown.selectedIndex].value;
    var count = $("#Count");
    var tBody = $("#tblInstallationEquipments > TBODY")[0];
    var row = tBody.insertRow(-1);
    var cell = $(row.insertCell(-1));
    var innerEquipmentTypeId = '<input type ="hidden" class="readonly" name = "Model.Installations[' + counter + '].EquipmentTypeId" value = "' + selectedValue + '" />';
    cell.attr("class", "d-none");
    cell.html(innerEquipmentTypeId);
    var cell = $(row.insertCell(-1));
    var innerEquipmentTypeModelId = '< input type = "hidden" class="readonly" name = "Model.Installations[' + counter + '].EquipmentTypeModel.Id" value = "' + selectedValue + '" /> ';
    cell.attr("class", "d-none");
    cell.html(innerEquipmentTypeModelId);
    var cell = $(row.insertCell(-1));
    cell.attr("class", "w-100");
    var innerEquipmentText = '<input type = "text" class="form-control tblItem bg-white border-0" readonly name = "Model.Installations[' + counter + '].EquipmentTypeModel.Name" value = "' + selectedText + '" /> ';
    cell.html(innerEquipmentText);
    cell = $(row.insertCell(-1));
    cell.attr("class", "w-100");
    var innerCount = '<input type = "text" class="form-control tblItem bg-white border-0" readonly name = "Model.Installations[' + counter + '].Count" value = "' + count.val() + '" /> ';
    cell.html(innerCount);
    cell = $(row.insertCell(-1));
    cell.attr("class", "w-100");
    var btnRemove = '<button type="button" value="Удалить" class="btn btn-danger w-100" onclick="Remove(this)"> <i class="fa fa-trash"></i></button>';
    $("#EquipmentTypes").prop('selectedIndex', 0);
    cell.append(btnRemove);
    count.val("");
    counter++;
});

$(".table tbody").on("click", ".btn", function () {
    $(this).closest("TR").remove();
});