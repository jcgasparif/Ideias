$(document).ready(function () {
    var ideiaId;

    // Onload

    $("#tbxDataInicio, #tbxDataFim, #tbxDataReuniao ").datepicker({ format: "dd/mm/yyyy", todayHighlight: true, autoclose: true });
    $("#lnkComite").addClass("active");

    $("#AnexoIFormFile").attr("data-val", "true");
    $("#AnexoIFormFile").attr("data-val-required", "Preencha o campo Anexo");

    // Events

    $("#ibox-title-comite-detalhes-ideia").click(function () {
        $("#ibox-content-comite-detalhes-ideia").toggle();
        $("#ibox-tools-comite-detalhes-ideia-chevron").toggleClass("fa-chevron-up fa-chevron-down");
    });

    $("#tbxDataInicio, #tbxDataFim, #tbxDescricao").change(function () {
        showFilterResult();
    });

    $("#tbxDescricao").keyup(function () {
        showFilterResult();
    });

    $("#modal-criar-reuniao").on("show.bs.modal", function (e) {
        if (e.relatedTarget) {
            ideiaId = $(e.relatedTarget).attr("data-ideiaid");
        }
    });

    $("#modal-ata-reuniao").on("show.bs.modal", function (e) {
        if (e.relatedTarget) {
            ideiaId = $(e.relatedTarget).attr("data-ideiaid");
        }

        $("#adicionarAnexoForm").find("#Descricao, #AnexoIFormFile, #img_nome").val("");
        $("#adicionarAnexoForm").find("#img_nome").text("");
    });

    $("#AnexoIFormFile").change(function () {
        $("#img_nome").text(this.files[0].name);
        $("#img_nome")[0].style.display = "block";
    });

    $("#btnAdicionarReuniao").click(function (e) {
        e.preventDefault();
        var dataReuniao = $("#tbxDataReuniao").val();
        var horaReuniao = $("#tbxHoraReuniao").val();
        console.log(horaReuniao);

        $.ajax({
            url: "/Comite/CriarReuniao?ideiaId=" + ideiaId + "&data=" + dataReuniao + ' ' + horaReuniao,
            type: "GET",
            success: function (result) {
                if (result.success) {
                    $("#modal-criar-reuniao").modal("hide");
                    document.location.reload();
                }
                else {
                    alert("Falha ao criar reunião.");
                }
            }
        });
    });

    $("#btnAdicionarAtaReuniao").on("click", function (e) {
        e.preventDefault();

        var form = document.forms[1];

        if (form.elements["Descricao"].value === "") {
            form.elements["Descricao"].focus();
            return;
        }

        if (form.elements["AnexoIFormFile"].value === "") {
            form.elements["AnexoIFormFile"].focus();
            return;
        }

        form.elements["IdeiaId"].value = ideiaId;

        $.ajax({
            url: "/Comite/AdicionarAnexo",
            data: new FormData(form),
            contentType: false,
            processData: false,
            type: "POST",
            success: function (result) {
                if (result.success) {
                    $("#modal-ata-reuniao").modal("hide");
                    document.location.reload();
                } else {
                    document.location.reload();
                    $("#modal-ata-reuniao").find(".modal").modal("show");
                }
            },
            fail: function () {
                alert("Falha ao adicionar o anexo.");
            }
        });
    });

    // Functions
    function showFilterResult() {
        var dtInicio = $("#tbxDataInicio").val();
        var dtFim = $("#tbxDataFim").val();
        var desc = $("#tbxDescricao").val();
        $.ajax({
            url: "/Comite/GetComiteIdeiasList?dataInicio=" + dtInicio + "&dataFim=" + dtFim + "&descricao=" + desc,
            type: "GET",
            success: function (result) {
                $("#lista-comite-ideias-content").html(result);
            }
        });
    };
});