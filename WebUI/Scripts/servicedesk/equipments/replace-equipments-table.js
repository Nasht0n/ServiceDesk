$("body").on("click", "#btnAddReplaceEquipments", function (val) {
    var table = document.getElementById("tblReplaceEquipments");
    var counter = table.rows.length - 2;
    var equipmentDropDown = document.getElementById("EquipmentTypes");
    var selectedText = equipmentDropDown.options[equipmentDropDown.selectedIndex].text;
    var selectedValue = equipmentDropDown.options[equipmentDropDown.selectedIndex].value;
    var inventoryNumber = $("#InventoryNumber");
    var tBody = $("#tblReplaceEquipments > TBODY")[0];
    var row = tBody.insertRow(-1);
    var cell = $(row.insertCell(-1));
    var innerEquipmentTypeId = '<input type="hidden" class="readonly" name="Model.Installations[' + counter + '].EquipmentTypeId" value="' + selectedValue + '"/>';
    cell.attr("class", "d-none");
    cell.html(innerEquipmentTypeId);
    var cell = $(row.insertCell(-1));
    var innerEquipmentTypeModelId = '<input type="hidden" class="readonly" name="Model.Installations[' + counter + '].EquipmentTypeModel.Id" value="' + selectedValue + '"/>';
    cell.attr("class", "d-none");
    cell.html(innerEquipmentTypeModelId);
    var cell = $(row.insertCell(-1));
    cell.attr("class", "w-100");
    var innerEquipmentText = '<input type="text" class="form-control tblItem bg-light border-0" readonly name="Model.Installations[' + counter + '].EquipmentTypeModel.Name" value="' + selectedText + '"/>';
    cell.html(innerEquipmentText);
    cell = $(row.insertCell(-1));
    cell.attr("class", "w-100");
    var innerInventoryNumber = '<input type="text" class="form-control tblItem bg-light border-0" readonly name="Model.Installations[' + counter + '].InventoryNumber" value="' + inventoryNumber.val() + '"/>';
    cell.html(innerInventoryNumber);
    cell = $(row.insertCell(-1));
    cell.attr("class", "w-100");
    var btnRemove = '<button type="button" value="Удалить" class="btn btn-danger w-100" onclick="Remove(this)"> <i class="fa fa-trash" ></i> </button >';
    $("#EquipmentTypes").prop('selectedIndex', 0);
    cell.append(btnRemove);
    inventoryNumber.val("");
});

$(".table tbody").on("click", ".btn", function () {
    $(this).closest("TR").remove();
});