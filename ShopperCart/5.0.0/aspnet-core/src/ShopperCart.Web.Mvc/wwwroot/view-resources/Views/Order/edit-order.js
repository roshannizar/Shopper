var TempProduct = [];
var breakCount = 0;

function EditOrders(id) {

    var orderId = document.getElementById("orderid "+id).innerHTML;
    var productId = document.getElementById("productid " + id).innerHTML;
    var productName = document.getElementById("productName " + id).innerHTML;
    var description = document.getElementById("description " + id).innerHTML;
    var unitPrice = document.getElementById("unitprice " + id).innerHTML;
    var quantity = document.getElementById("quantity " + id).innerHTML;
    var editBtn = document.getElementById("EditBtn " + id);


    if (editBtn.value === "Edit") {
        document.getElementById("productid").value = productId;
        document.getElementById("id").value = id;
        document.getElementById("orderId").value = orderId;
        document.getElementById("Name").value = productName;
        document.getElementById("description").value = description;
        document.getElementById("UnitPrice").value = unitPrice;
        document.getElementById("Quantity").value = quantity;
        editBtn.value = "Undo Edit";
    } else {
        editBtn.value = "Edit";
    }
}

function DeleteOrderItem(id) {
    var orderId = document.getElementById("orderid " + id).innerHTML;
    var productId = document.getElementById("productid " + id).innerHTML;
    var unitPrice = document.getElementById("unitprice " + id).innerHTML;
    var deleteBtn = document.getElementById("DeleteBtn " + id);

    var orderItems = {
        Id: 0,
        ProductId: 0,
        UnitPrice: 0,
        Quantity: 0,
        OrderId: 0
    };

    if (deleteBtn.value === "Delete") {
        orderItems.Id = id;
        orderItems.ProductId = parseInt(productId);
        orderItems.OrderId = parseInt(orderId);
        orderItems.Quantity = 0;
        orderItems.UnitPrice = parseInt(unitPrice);
        TempProduct.push(orderItems);
        deleteBtn.value = "Undo Delete";
        document.getElementById("SaveChanges").hidden = false;
        document.getElementById("EditBtn " + id).hidden = true;
    } else {
        deleteBtn.value = "Delete";
    }
}

function ConfirmOrderChanges() {

    var orderItems = {
        Id: 0,
        ProductId: 0,
        UnitPrice: 0,
        Quantity: 0,
        OrderId: 0
    };

    orderItems.Id = parseInt(document.getElementById("id").value);
    orderItems.ProductId = parseInt(document.getElementById("productid").value);
    orderItems.UnitPrice = parseInt(document.getElementById("UnitPrice").value);
    orderItems.Quantity = parseInt(document.getElementById("Quantity").value);
    orderItems.OrderId = parseInt(document.getElementById("orderId").value);
    document.getElementById("updatedQuantity " + orderItems.Id).textContent = "Quantity: " + orderItems.Quantity;
    document.getElementById("updateTotalAmount " + orderItems.Id).textContent = "Total Amount: Rs: " +
            (parseInt(document.getElementById("Quantity").value) *
            parseInt(document.getElementById("UnitPrice").value));
    document.getElementById("EditBtn " + orderItems.Id).value = "Undo Edit";

    TempProduct.push(orderItems);

    document.getElementById("SaveChanges").hidden = false;
}

function Confirm() {

    var date = new Date();
    var currentDate = JSON.stringify(date);

    var order = {
        CustomerId: 0,
        Date: null,
        OrderItems: TempProduct
    }

    order.Date = currentDate.replace(/^"(.*)"$/, '$1');

    $.ajax({
        url: '../UpdateOrder',
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(order),
        processData: false,
        success: function (data, textStatus, jQxhr) {
            console.log(data, textStatus, jQxhr);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(jqXhr, textStatus, errorThrown);
        }
    });
}

function EraseChanges() {
    TempProduct = [];
    document.getElementById("SaveChanges").hidden = true;
}

function PlaceNewOrder() {

    var temp = document.getElementById("productId");
    var productId = temp.options[temp.selectedIndex].value;
    var productName = temp.options[temp.selectedIndex].textContent;
    var description = document.getElementById("descriptionText").value;
    var unitprice = document.getElementById("UnitPriceText").value;
    var quantity = document.getElementById("QuantityText").value;

    var orderItems = {
        Id: 0,
        ProductId: 0,
        UnitPrice: 0,
        Quantity: 0,
        OrderId: 0
    };

    var exist = false;

    for (var i = 0; i < TempProduct.length; i++) {

        var existing = TempProduct[i].productId;

        if (parseInt(existing) == parseInt(productId)) {

            var tempQuantity = parseInt(TempProduct[i].quantity);
            var existingQuantity = parseInt(quantity);

            var tempTotal = tempQuantity + existingQuantity;

            TempProduct[i].quantity = parseInt(tempTotal);
            exist = true;
            break;
        }

    }

    if (TempProduct.length == 0) {
        TempProduct.push(orderItems);
    } else if (exist == false) {
        TempProduct.push(orderItems);

    }

    CreateTableRow(productName, description, unitprice, quantity);
}

function CreateTableRow(productName, description, unitPrice, quantity) {

    var table = document.getElementById("tableForm");
    var deleteBtn = document.createElement("input");
    var editBtn = document.createElement("input");
    var quantityText = document.createElement("input");

    deleteBtn.setAttribute('type', 'button');
    deleteBtn.setAttribute('value', 'Delete');
    deleteBtn.classList.add("btn");
    deleteBtn.classList.add("btn-sm");
    deleteBtn.classList.add("btn-danger");

    editBtn.setAttribute('type', 'button');
    editBtn.setAttribute('value', 'Edit');
    editBtn.classList.add("btn");
    editBtn.classList.add("btn-sm");
    editBtn.classList.add("btn-warning");
    deleteBtn.classList.add("margin-left");

    quantityText.setAttribute('type', 'number');
    quantityText.classList.add('form-control');
    quantityText.classList.add('col-md-6');
    quantityText.disabled = true;

    if (breakCount == 0) {
        var row = table.insertRow(0);
        var lineBreak = document.createElement("br");
        var breakerCell = row.insertCell(0);
        breakerCell.appendChild(lineBreak);
    }
    breakCount++;

    var row = table.insertRow(1);
    var productNameCell = row.insertCell(0);
    var descriptionCell = row.insertCell(1);
    descriptionCell.colSpan = 2;
    var unitpriceCell = row.insertCell(2);
    var quantityCell = row.insertCell(3);
    var totalCell = row.insertCell(4);
    var editBtnCell = row.insertCell(5);
    var deleteBtnCell = row.insertCell(6);

    deleteBtnCell.appendChild(deleteBtn);
    editBtnCell.appendChild(editBtn);
    quantityCell.appendChild(quantityText);

    productNameCell.innerHTML = productName;
    descriptionCell.innerHTML = description;
    unitpriceCell.innerHTML = "Rs: " + unitPrice;
    quantityText.value = quantity;
    totalCell.innerHTML = "Rs: " + parseInt(quantity) * parseInt(unitPrice);
    editBtnCell.appendChild(editBtn);
}