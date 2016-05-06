$('#transfer').on('click', function () {

    var value1, value2, value3;
    value1 = $('.from').val();
    value2 = $('.where').val();

    value3 = value1;
    value1 = value2;
    value2 = value3;

    $('.from').val(value1);
    $('.where').val(value2);
});

