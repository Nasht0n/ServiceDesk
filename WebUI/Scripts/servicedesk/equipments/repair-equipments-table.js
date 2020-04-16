$("body").on("click", "#btnAddRepairEquipments", function (val) {
    var table = document.getElementById("tblRepairEquipments");
    var counter = table.rows.length - 2;
    var consumablesDropDown = document.getElementById("Consumables");
    var selectedText = consumablesDropDown.options[consumablesDropDown.selectedIndex].text;
    var selectedValue = consumablesDropDown.options[consumablesDropDown.selectedIndex].value;
    var count = $("#Count");
    var tBody = $("#tblRepairEquipments > TBODY")[0];
    var row = tBody.insertRow(-1);
    var cell = $(row.insertCell(-1));
    var innerConsumableId = '<input type ="hidden" class="readonly" name = "Model.Repairs[' + counter + '].ConsumableId" value = "' + selectedValue + '" />';
    cell.attr("class", "d-none");
    cell.html(innerConsumableId);
    var cell = $(row.insertCell(-1));
    var innerEquipmentTypeModelId = '< input type = "hidden" class="readonly" name = "Model.Repairs[' + counter + '].ConsumableModel.Id" value = "' + selectedValue + '" /> ';
    cell.attr("class", "d-none");
    cell.html(innerEquipmentTypeModelId);
    var cell = $(row.insertCell(-1));
    cell.attr("class", "w-100");
    var innerEquipmentText = '<input type = "text" class="form-control tblItem bg-white border-0" readonly name = "Model.Repairs[' + counter + '].ConsumableModel.Name" value = "' + selectedText + '" /> ';
    cell.html(innerEquipmentText);
    cell = $(row.insertCell(-1));
    cell.attr("class", "w-100");
    var innerCount = '<input type = "text" class="form-control tblItem bg-white border-0" readonly name = "Model.Repairs[' + counter + '].Count" value = "' + count.val() + '" /> ';
    cell.html(innerCount);
    cell = $(row.insertCell(-1));
    cell.attr("class", "w-100");
    var btnRemove = '<button type="button" value="Удалить" class="btn btn-danger w-100" onclick="Remove(this)"> <i class="fa fa-trash"></i></button>';
    $("#Consumables").prop('selectedIndex', 0);
    cell.append(btnRemove);
    count.val("");
    counter++;
});

$(".table tbody").on("click", ".btn", function () {
    $(this).closest("TR").remove();
});