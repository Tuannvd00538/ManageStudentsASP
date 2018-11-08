function deleteStudent(id) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this student!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: '/Students/Delete/' + id,
                    type: 'POST',
                    success: function (response) {
                        swal("Poof! Your student has been deleted!", {
                            icon: "success",
                        });
                        $('#' + id).remove();
                    },
                    error: function (err) {
                        swal("Poof! An error occurred!", {
                            icon: "error",
                        });
                    }
                });
            }
        });
}