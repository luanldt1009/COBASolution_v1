var productController = {
    init: function () {
        productController.register();
    },
    register: function () {
        $(".btnDelete").off("click").on("click", function (e) {
            var id = $(this).data('id');
            productController.deleteProduct(id);
        });
    },
    deleteProduct: function (id) {
        bootbox.confirm("Bạn có muốn xóa?", function (result) {
            if (result) {
                $.ajax({
                    url: 'Product/Delete',
                    type: "GET",
                    dataType: "json",
                    data: { id: id },
                    success: function (res) {
                        if (res.status) {
                            bootbox.alert("Xóa thành công", function () {
                                window.location.reload();
                            });
                        }
                        else {
                            bootbox.alert(res.message)
                        }
                    }
                });
            }
        })
    },
};
productController.init();