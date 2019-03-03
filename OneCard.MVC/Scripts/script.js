
function showPopup(url, title) {
    $('#popup_container #defModalHead').text(title)
    $('#popup_container').modal('show');
    $('#popup_container .modal-body').load(url)
}
function initDatatable(lang) {
    if (lang == 'ar') {
        $('.datatable').DataTable({
            "language": {
                "url": "//cdn.datatables.net/plug-ins/1.10.19/i18n/Arabic.json"
              //  "url": "/Scripts/DataTables/Arabic.json"
            }
        });
    }
    else {
        $('.datatable').DataTable();
    }
}
$(function () {
    $('.datepicker').datepicker({ dateFormat: 'dd-MM-yy' }).val();; //Initialise any date pickers
    //var uiElements = function () {
    ////Datatables
    //    var uiDatatable = function () {
    //        if ($(".datatable").length > 0) {
    //            $(".datatable").dataTable();
    //        //    $(".datatable").on('page.dt', function () {
    //        //        onresize(100);
    //        //    });
    //        //}

    //        //if ($(".datatable_simple").length > 0) {
    //        //    $(".datatable_simple").dataTable({ "ordering": false, "info": false, "lengthChange": false, "searching": false });
    //        //    $(".datatable_simple").on('page.dt', function () {
    //        //        onresize(100);
    //        //    });
    //        }
    //    }//END Datatable  
    //return {
    //    init: function () {
    //        uiDatatable();
    //    }
    //}

    //}();
    //uiElements.init();

   

});