var total = 0;

$(document).ready(function () {
    cargaProductos();
});

function cargaProductos() {

    $.ajax({
        type: "Get",
        url: "/producto/productos",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

            var $dropdown = $("#dropProductos");
            var options = "";
            for (var i = 0; i < data.length; i++) {
                options += `<option value=${data[i].ProductoId}>${data[i].Nombre}</option>`;
            }
            $($dropdown).append(options);

        },
        error: function () {
            alert("Error al cargar productos")
        }
    });
}

function cargaProducto(id) {

    $.ajax({
        type: "Get",
        url: "/producto/producto",
        dataType: "json",
        data: { "id": id },
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            total += data.Precio;
            var producto = "<tr><td id='ProductId_" + data.ProductoId + "'>" + data.ProductoId + "</td><td>" + data.Nombre + "</td> <td id='Cantidad_" + data.ProductoId + "'>" + 1 + "</td> <td>" + data.Precio + "</td> </tr>";
            $("table tbody").append(producto);
            $("#spanTotal").text(total);

        },
        error: function () {
            alert("Error al cargar producto")
        }
    });

}

function guardaPedido(pedido) {

    $.ajax({
        type: "Post",
        url: "/pedido/generaPedido",
        dataType: "json",
        data: '{pedido: ' + JSON.stringify(pedido) + '}',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            alert("Pedido registrado con exito");

        },
        error: function () {
            alert("Error al generar pedido");
        }
    });

}


$("#dropProductos").change(function () {
    $(this).find('option').removeAttr("selected", "selected");
    $(this).find('option:selected').attr("selected", "selected");
    var productoId = $(this).find('option:selected').val();
    cargaProducto(productoId);
});

$("#btnGeneraPedido").on("click", function () {
    debugger;
    obtenerProductos();
    var pedido = obtenerDatos();
    console.log(pedido);
    guardaPedido(pedido);

});

function obtenerDatos() {

    var Clientes = {
        Nombre: $("#Nombre").val(),
        ApellidoPaterno: $("#ApellidoPaterno").val(),
        ApellidoMaterno: $("#ApellidoMaterno").val(),

    };
    var ObtenerPedidoProducto = obtenerProductos();

    return Pedido = {
        Total: parseFloat($("#spanTotal").text()),
        Cliente: Clientes,
        PedidoProducto: ObtenerPedidoProducto
    }

}

function obtenerProductos() {
    var ProductosArray = [];
    $('#tblProductos tbody tr').each((tr_idx, tr) => {
        var count = 0;
        $(tr).children('td').each((td_idx, td) => {
            count += 1;
            console.log($(td).text());
            if (count == 1) {
                var productos = {
                    ProductoId: parseInt($("#ProductId_" + $(td).text()).text()),
                    Cantidad: parseInt($("#Cantidad_" + $(td).text()).text())
                };
                ProductosArray.push(productos);

            }
        });
    });
    return ProductosArray;
}