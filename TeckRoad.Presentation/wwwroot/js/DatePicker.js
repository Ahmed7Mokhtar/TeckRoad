$(function () {
    $('.datepicker').datepicker(
        {
            dateFormat: 'yy-mm-dd',
            minDate: new Date(),
            maxDate: AddsubtractMonths(new Date(), 2)
        }
    );

});