var myMap;

var mapController = {
    init:false,
    ready: function (callback) {
        this.callback = callback;
    },
    go: function () {
        if (this.callback) this.callback();
    }
};

function init() {
        var geolocation = ymaps.geolocation,
        myMap = new ymaps.Map("map", {
            center: [geolocation],
            zoom: 15,
            controls: ['zoomControl', 'typeSelector', 'fullscreenControl', 'geolocationControl', 'trafficControl', 'searchControl'] // <!-- добавляет на карту кнопки управления: масштабирования, поиска ('searchControl', ), слои, полный экран, местоположения пользователя, пробки -->
        });

        var multiRoute, ch = 1;

        var markers = [];

        var point = [];


    //событие на клик по карте создает метку
        myMap.events.add('click', function (e) {
            var coords = e.get('coords');
            if (markers.length < 10) {
                myPlacemark = new ymaps.Placemark([coords[0].toPrecision(6), coords[1].toPrecision(6)], {
                    // Свойства
                    // Текст метки
                    iconContent: ch
                }, {
                    // Опции
                    // Иконка метки будет растягиваться под ее контент
                    preset: 'twirl#blueStretchyIcon'
                });

                markers.push(myPlacemark);
                myMap.geoObjects.add(myPlacemark);
                ch++;
                if (ch == 3) {
                    myMap.geoObjects.removeAll();
                    calcRoute();
                }
            }
            else {
                alert("Вы задали максимальное количество точек");
            }
        });



        geolocation.get({
            provider: 'yandex',
            mapStateAutoApply: true
        }).then(function (result) {
            //    //result.geoObjects.options.set('preset', 'island#redCircleIcon');
            //    result.geoObjects.get(0).properties.set();
            myMap.geoObjects.add(result.geoObjects);
        })
        var myButton1 = new ymaps.control.Button({
            data: {
                content: 'Построить маршрут',
                title: 'По установленным меткам построить маршрут'
            }
        });

        myButton1.events.add('click', calcRoute);

        myMap.controls.add(myButton1, { selectOnClick: false });



        // Получаем ссылки на нужные элементы управления.
        var searchControl = myMap.controls.get('searchControl');
        var geolocationControl = myMap.controls.get('geolocationControl');

    //myButton1.events.add('click',
        mapController.getCoordinates = function () {
                var coordinates = [];
                var yCoordinates = [];
                var route = multiRoute.getActiveRoute();
                route.getPaths().each(function (path) {
                    console.log('path data:', path.properties.getAll());
                    /**
                     * Возвращает массив сегментов пути.
                     * @see https://tech.yandex.ru/maps/doc/jsapi/2.1/ref/reference/multiRouter.masstransit.Path-docpage/
                     */
                    path.getSegments().each(function (segment) {
                        console.log('segment data:', segment.properties.getAll());
                        //  console.log('segment data:', segment.geometry.getCoordinates());
                        segment.geometry.getCoordinates()
                            .map(function (el) { return { X: el[0], Y: el[1] }; })
                            .forEach(function (c) { coordinates.push(c); });

                        segment.geometry.getCoordinates().forEach(function (c) {
                            yCoordinates.push(c);
                        });
                    });
                });
                return coordinates;
            };

      

        function clearRoute() {
            myMap.geoObjects.remove(multiRoute);
            multiRoute = currentRoutingMode = null;
        }


       
        

        function calcRoute() {
            for (var i = 0, l = markers.length; i < l; i++) {
                point[i] = markers[i].geometry.getCoordinates();
            }

            multiRoute = new ymaps.multiRouter.MultiRoute({
                referencePoints:point
                }, {
                boundsAutoApply: true,
                editorMidPointsType: "viaPoint",
                editorDrawOver: false
            });

            multiRoute.model.setParams({
                routingMode: 'auto'
            });


            multiRoute.model.events
            .add("requestsuccess", function (event) {
                var routes = event.get("target").getRoutes();
                console.log("Найдено маршрутов: " + routes.length);
                for (var i = 0, l = routes.length; i < l; i++) {
                    console.log("Длина маршрута " + (i + 1) + ": " + routes[i].properties.get("distance").text);
                }
            })
            .add("requestfail", function (event) {
                console.log("Ошибка: " + event.get("error").message);
            })
            .add("update", function (event) {
                console.log("Update");
                console.log(event);
            })
            ;


            multiRoute.editor.start({
                addWayPoints: true,
                removeWayPoints: true,
                dragWayPoints: true,
                dragViaPoints: true,
                removeViapoints: true

            });

            myMap.geoObjects.add(multiRoute);
        }

    //Удаление маршрута и меток с карты и очистка данных
        function reset() {
            multiRoute && myMap.geoObjects.remove(multiRoute);
            for (var i = 0, l = markers.length; i < l; i++) {
                myMap.geoObjects.remove(markers[i]);
            }
            markers = [];
            point = [];
            ch = 1;
        }

        mapController.go();
    }










ymaps.ready(init);// инициализация карты после загрузки страницы 
