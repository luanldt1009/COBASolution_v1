var userController = {
    init: function () {
        userController.register();
    },
    register: function () {
        $('#btnDelete').off('click').on('click', function (e) {
            var id = $(this).data('id');
            debugger;
            userController.deleteUser(id);
        })
    },

    deleteUser: function (id) {
        bootbox.confirm("Are you sure Delete?", function (result) {
            if (result) {
                $.ajax({
                    url: 'User/Delete',
                    type: "GET",
                    dataType: "json",
                    data: { id: id },
                    success: function (res) {
                        if (res.status) {
                            bootbox.alert("Xóa thành công");
                            //userController.loadData();
                        }
                        else {
                            bootbox.alert(res.message)
                        }
                    }
                 });
            }
        })
    },
    loadData: function () {
        window.location = "/Home/Index";
    }
}

userController.init();