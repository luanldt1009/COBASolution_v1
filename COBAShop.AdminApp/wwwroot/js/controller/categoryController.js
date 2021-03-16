var categoryController = {
    init: function () {
        categoryController.register();
    },
    register: function () {
        $(".btnDelete").off("click").on("click", function (e) {
            var id = $(this).data('id');
            categoryController.deleteCategory(id)
        });
    },
    deleteCategory: function (id) {
        bootbox.confirm("Bạn có muốn xóa?", function (result) {
            if (result) {
                $.ajax({
                    url: 'Category/Delete',
                    type: "GET",
                    dataType: "json",
                    data: { id: id },
                    success: function (res) {
                        if (res.status) {
                            bootbox.alert("Xóa thành công", function () {
                                window.location.reload()
                                //categoryController.loadData();
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
categoryController.init();