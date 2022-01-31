$(document).ready(function () {
    // Onload

    var ideiaId, anexoId, filename;

    $("#tbxDataInicio, #tbxDataFim, #DataSubAnalise").datepicker({ format: "dd/mm/yyyy", todayHighlight: true, autoclose: true });

    $("#lnkIdeias").addClass("active");
    $("#AnexoIFormFile").attr("data-val", "true");
    $("#AnexoIFormFile").attr("data-val-required", "Preencha o campo Anexo");

    if ($("#ProdutoNovo").prop("checked")) {
        enableDisableElement(true, "ProdutoExistente");
    }

    if ($("#ExisteConcorrente").prop("checked")) {
        enableDisableElement(true, "DetalhesConcorrente");
    }

    // Events

    $("#ProdutoNovo").change(function () {
        enableDisableElement(this.checked, "ProdutoExistente");
    });

    $("#ExisteConcorrente").change(function () {
        enableDisableElement(this.checked, "DetalhesConcorrente");
    });

    $("#modal-adicionar-anexo").on("hidden.bs.modal", function () {
        $("#adicionarAnexoForm").find("#Descricao, #AnexoIFormFile, #img_nome").val("");
        $("#adicionarAnexoForm").find("#img_nome").text("");
    });

    $("#modal-excluir-anexo").on("show.bs.modal", function (e) {
        anexoId = $(e.relatedTarget).attr("data-id");
        ideiaId = $(e.relatedTarget).attr("data-ideiaid");
        filename = $(e.relatedTarget).attr("data-filename");
    });

    $("#modal-excluir-ideia").on("show.bs.modal", function (e) {
        ideiaId = $(e.relatedTarget).attr("data-id");
    });

    $("#btnAdicionarAnexo").on("click", function (e) {
        e.preventDefault();

        var form = document.forms[2];

        if (form.elements["Descricao"].value === "") {
            form.elements["Descricao"].focus();
            return;
        }

        if (form.elements["AnexoIFormFile"].value === "") {
            form.elements["AnexoIFormFile"].focus();
            return;
        }

        $.ajax({
            url: "/Ideias/AdicionarAnexo",
            data: new FormData(form),
            contentType: false,
            processData: false,
            type: "POST",
            success: function (result) {
                if (result.success) {
                    $("#modal-adicionar-anexo").modal("hide");
                    $("#lista-anexo-content").load(result.url);
                } else {
                    $("#modal-adicionar-anexo").html(result);
                    $("#modal-adicionar-anexo").find(".modal").modal("show");
                }
            },
            fail: function () {
                alert("Falha ao adicionar o anexo.");
            }
        });
    });

    $("#btnExcluirAnexo").click(function (e) {
        e.preventDefault();
        $.ajax({
            url: "/Ideias/ExcluirAnexo?id=" + anexoId + "&ideiaId=" + ideiaId + "&filename=" + filename,
            type: "GET",
            success: function (result) {
                if (result.success) {
                    $("#modal-excluir-anexo").modal("hide");
                    $("#lista-anexo-content").load(result.url);
                }
                else {
                    alert("Falha ao excluir o anexo.");
                }
            }
        });
    });

    $("#btnExcluirIdeia").click(function () {
        $.ajax({
            url: "/Ideias/Delete?id=" + ideiaId,
            type: "GET",
            success: function () {
                document.location.reload();
            }
        });
    });

    $("#AnexoIFormFile").change(function () {
        $("#img_nome").text(this.files[0].name);
        $("#img_nome")[0].style.display = "block";
    });

    $("#tbxDataInicio, #tbxDataFim, #tbxDescricao").change(function () {
        showFilterResult();
    });

    $("#tbxDescricao").keyup(function () {
        showFilterResult();
    });

    // Functions

    function enableDisableElement(enable, elementName) {
        var el = $("#" + elementName);
        if (!enable) {
            el.attr("disabled", "disabled").val("");
        }
        else {
            el.removeAttr("disabled").focus();
        }
    };

    function showFilterResult() {
        var dtInicio = $("#tbxDataInicio").val();
        var dtFim = $("#tbxDataFim").val();
        var desc = $("#tbxDescricao").val();
        $.ajax({
            url: "/Ideias/GetIdeiasList?dataInicio=" + dtInicio + "&dataFim=" + dtFim + "&descricao=" + desc,
            type: "GET",
            success: function (result) {
                $("#lista-ideias-content").html(result);
            }
        });
    };
});