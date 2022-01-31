$(document).ready(function () {
    // Onload

    var userId, claimValues, roleName;
    $("#lnkUsuarios").addClass("active");

    // Events

    $("#modal-excluir-claim").on("show.bs.modal", function (e) {
        userId = $(e.relatedTarget).attr("data-id");
        claimValues = $(e.relatedTarget).attr("data-claimValues");
    });

    $("#modal-excluir-usuario").on("show.bs.modal", function (e) {
        userId = $(e.relatedTarget).attr("data-id");
    });

    $("#modal-adicionar-claim").on("hidden.bs.modal", function () {
        $("#Type, #Value").val("");
        userId = $("#UserId").val();
    });

    $("#modal-adicionar-claim").on("show.bs.modal", function () {
        $("#cbxRole").val("");
        $("#cbxClaimRole option").remove();
        $("#Type").val($("#cbxRole option:selected").text().toString());
    });

    $("#modal-adicionar-role").on("show.bs.modal", function () {
        $("#cbxAddRole").val("");
    });

    $("#modal-excluir-role").on("show.bs.modal", function (e) {
        userId = $(e.relatedTarget).attr("data-userId");
        roleName = $(e.relatedTarget).attr("data-roleName");
    });

    $("#btnAdicionarClaim").on("click", function (e) {
        e.preventDefault();
        var form = document.forms[2];

        if (form.elements["Type"].value === "") {
            form.elements["cbxRole"].focus();
            return;
        }

        if (form.elements["Value"].value === "") {
            form.elements["cbxClaimRole"].focus();
            return;
        }

        $.ajax({
            url: "/Admin/AdicionarClaim",
            data: new FormData(form),
            contentType: false,
            processData: false,
            type: "POST",
            success: function (result) {
                if (result.success) {
                    $("#modal-adicionar-claim").modal("hide");
                    $("#lista-claim-content").load(result.url);
                } else {
                    $("#modal-adicionar-claim").modal("hide");
                }
            },
            fail: function () {
                alert("Falha ao adicionar a permissão.");
            }
        });
    });

    $("#btnAdicionarRole").on("click", function (e) {
        e.preventDefault();
        var form = document.forms[3];

        $.ajax({
            url: "/Admin/AdicionarRoleUsuario",
            data: new FormData(form),
            contentType: false,
            processData: false,
            type: "POST",
            success: function (result) {
                if (result.success) {
                    $("#modal-adicionar-role").modal("hide");
                    $("#lista-role-content").load(result.url);
                } else {
                    $("#modal-adicionar-role").modal("hide");
                }
            },
            fail: function () {
                alert("Falha ao adicionar a role.");
            }
        });
    });

    $("#btnExcluirUsuario").click(function (e) {
        e.preventDefault();
        $.ajax({
            url: "/Admin/Delete?id=" + userId,
            type: "GET",
            success: function () {
                document.location.reload();
            }
        });
    });

    $("#btnExcluirClaim").click(function (e) {
        e.preventDefault();
        $.ajax({
            url: "/Admin/ExcluirClaim?userId=" + userId + "&claimValues=" + claimValues,
            type: "GET",
            success: function (result) {
                if (result.success) {
                    $("#modal-excluir-claim").modal("hide");
                    $("#lista-claim-content").load(result.url);
                }
                else {
                    $("#modal-excluir-claim").html(result);
                    $("#modal-excluir-claim").find(".modal").modal("show");
                }
            },
            fail: function () {
                alert("Falha ao excluir a permissão.");
            }
        });
    });

    $("#btnExcluirRole").click(function (e) {
        e.preventDefault();
        $.ajax({
            url: "/Admin/ExcluirRoleUser?userId=" + userId + "&roleName=" + roleName,
            type: "GET",
            success: function (result) {
                if (result.success) {
                    $("#modal-excluir-role").modal("hide");
                    $("#lista-role-content").load(result.url);
                }
                else {
                    $("#modal-excluir-role").html(result);
                    $("#modal-excluir-role").find(".modal").modal("show");
                }
            },
            fail: function () {
                alert("Falha ao excluir a role.");
            }
        });
    });

    $("#tbxUserName, #tbxEmail").change(function () {
        showFilterResult();
    });

    $("#tbxUserName, #tbxEmail").keyup(function () {
        showFilterResult();
    });

    $("#cbxRole").change(function () {
        $("#Type").val($("#cbxRole option:selected").text().toString());

        var userIdClaim = $("#UserId").val();

        $.ajax({
            url: "/Admin/GetClaimValueByRoleName",
            data: { roleName: $("#cbxRole option:selected").val(), userId: userIdClaim },
            type: "GET"
        }).done(function (data) {
            var modelDropDown = $("#cbxClaimRole");
            modelDropDown.empty();
            $.each(data, function (index, model) {
                modelDropDown.append(
                    $("<option>", {
                        value: model.id
                    }).text(model.claimValue)
                );
            });
        }).fail(function () {
            //Do something with the error response
        });
    });

    $("#cbxClaimRole").change(function () {
        var value = $("#cbxClaimRole option:selected").map(function () {
            return $(this).text();
        }).get().join(",");

        $("#Value").val(value);
    });

    // Functions

    function showFilterResult() {
        var userName = $("#tbxUserName").val();
        var email = $("#tbxEmail").val();
        $.ajax({
            url: "/Admin/GetUsuarioList?userName=" + userName + "&email=" + email,
            type: "GET",
            success: function (result) {
                $("#lista-usuarios-content").html(result);
            }
        });
    };
});