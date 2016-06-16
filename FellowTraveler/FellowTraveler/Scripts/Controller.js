(function ($) {
    SendData =  function (coordinates) {
            var Name = $('#name')[0].value;
            var From = $('#from')[0].value;
            var To = $('#to')[0].value;
            var Date = $('#date')[0].value;
            var Time = $('#time')[0].value;
            var Coordinates = mapController.getCoordinates();
            var route = {
                Id: null,
                Name: Name,
                From: From,
                To: To,
                Date: Date,
              //  Price: price,
                Points: Coordinates
            };
            //console.log(route);
            $.ajax({
                url: '/Home/AddRouteJSON',
                type: 'POST',
                data:{ route:route, ownerId: 1 },
                dataType: 'json',
                success: function (data) {
                    route.Id = data;
                    alert('success');
                },
                error: function (arg) {
                    alert("Ошибка при сохранении скрипта, попробуйте еще раз.");
                    
                }
            });
    }


    mapController.ready(function () {
        $("#submit").removeAttr('disabled');
    });

    $(document).ready(function(){
        $("#submit").on('click', function () {
            var Coordinates = mapController.getCoordinates();
            SendData();
        })
    }
    
    )






})(jQuery);