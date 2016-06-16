(function ($) {
    viewModel = new (function () {
        var self = this;
        //Поля формы
        self.from = ko.observable();
        self.to = ko.observable();
        self.date = ko.observable();
        self.time = ko.observable();

        //по карте
        self.routes = ko.observable();
        self.point1 = ko.observable();
        self.point2 = ko.observable();
        self.selectedRoute = ko.observable();


        self.search = function () {
            $.ajax({
                url: '/Home/SearchRoutes',
                type: 'POST',
                data: {
                    point1: {
                        X: self.point1()[0],
                        Y: self.point1()[1]
                    },
                    point2: {
                        X:self.point2()[0],
                        Y: self.point2()[1],
                },
                    sMax: 500,
                    date: self.date(),
                    time:self.time()
                },
                dataType: 'json',
                success: function (data) {
                    self.routes(data);
                    self.selectedRoute(data.length && data[0]);
                },
                error: function (arg) {
                    alert("Ошибка при получении данных.");

                }
            });
        };
    })();
    ko.applyBindings(viewModel);
})(jQuery);