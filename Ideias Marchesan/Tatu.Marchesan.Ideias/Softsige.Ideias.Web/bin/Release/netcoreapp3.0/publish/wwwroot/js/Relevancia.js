$(document).ready(function () {
    // Onload
    var relevanciaId;

    $("#lnkRelevancia").addClass("active");

    // Events
    $("#modal-excluir-relevancia").on("show.bs.modal", function (e) {
        relevanciaId = $(e.relatedTarget).attr("data-id");
    });

    $("#btnExcluirRelevancia").click(function () {
        $.ajax({
            url: "/Relevancia/Delete?id=" + parseInt(relevanciaId),
            type: "GET",
            success: function () {
                document.location.reload();
            }
        });
    });
});