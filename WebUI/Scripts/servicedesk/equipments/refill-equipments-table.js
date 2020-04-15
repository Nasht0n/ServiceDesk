$("body").on("click", "#btnAddRefillEquipments", function (val) {
    var table = document.getElementById("tblRefillEquipments");
    var counter = table.rows.length - 2;
    
    var inventoryNumber = $("#InventoryNumber");
    var tBody = $("#tblRefillEquipments > TBODY")[0];
    var row = tBody.insertRow(-1);

    cell = $(row.insertCell(-1));
    cell.attr("class", "w-75");
    var innerCount = '<input type = "text" class="form-control tblItem bg-white border-0" readonly name = "Model.Refills[' + counter + '].InventoryNumber" value = "' + inventoryNumber.val() + '" /> ';
    cell.html(innerCount);

    cell = $(row.insertCell(-1));
    cell.attr("class", "w-25");
    var btnRemove = '<button type="button" value="Удалить" class="btn btn-danger float-right" onclick="Remove(this)"> <i class="fa fa-trash"></i></button>';
    cell.append(btnRemove);
    inventoryNumber.val("");
    counter++;
});

$(".table tbody").on("click", ".btn", function () {
    $(this).closest("TR").remove();
});