var myMap;
function init() {
    var geolocation = ymaps.geolocation,
    myMap = new ymaps.Map("map", {
        center: [geolocation],
        zoom: 15,
        controls: ['zoomControl', 'typeSelector', 'fullscreenControl', 'geolocationControl', 'trafficControl', 'searchControl'] // <!-- добавляет на карту кнопки управления: масштабирования, поиска ('searchControl', ), слои, полный экран, местоположения пользователя, пробки -->
    });

    var ch=1, markers = [];

    //Создание метки - обработчик события клика по карте
    var addPlaceholder = function (e) {
        var coords = e.get('coords');
        var myPlacemark = new ymaps.Placemark([coords[0].toPrecision(6), coords[1].toPrecision(6)], {
            // Свойства
            // Текст метки
            iconContent: ch
        }, {
            // Опции
            // Иконка метки будет растягиваться под ее контент
            preset: 'twirl#blueStretchyIcon',
            draggable:true
        });
        var vPoint = (ch == 1) ? viewModel.point1 : viewModel.point2;

        vPoint(myPlacemark.geometry.getCoordinates());

        myPlacemark.events.add('dragend', function (e) {
            vPoint(myPlacemark.geometry.getCoordinates());
        })

        markers.push(myPlacemark);
        myMap.geoObjects.add(myPlacemark);
        ch++;
        if (ch == 3) myMap.events.remove('click', addPlaceholder);
    };

    myMap.events.add('click', addPlaceholder); 



    geolocation.get({
        provider: 'yandex',
        mapStateAutoApply: true
    }).then(function (result) {
        myMap.geoObjects.add(result.geoObjects);
    })

    // Получаем ссылки на нужные элементы управления.
    var searchControl = myMap.controls.get('searchControl');
    var geolocationControl = myMap.controls.get('geolocationControl');
    var polyLine;
    var createPolyLine = function (coords) {
        // Создаем ломаную, используя класс GeoObject.
        polyLine = new ymaps.GeoObject({
            // Описываем геометрию геообъекта.
            geometry: {
                // Тип геометрии - "Ломаная линия".
                type: "LineString",
                // Указываем координаты вершин ломаной.
                coordinates: coords
            },
            // Описываем свойства геообъекта.
            properties: {
                // Содержимое хинта.
                hintContent: "Я геообъект",
                // Содержимое балуна.
                balloonContent: "Меня можно перетащить"
            }
        }, {
            // Задаем опции геообъекта.
            // Включаем возможность перетаскивания ломаной.
            draggable: true,
            // Цвет линии.
            strokeColor: "#FFFF00",
            // Ширина линии.
            strokeWidth: 5
        });
        myMap.geoObjects.add(polyLine);
    }


   
    viewModel.selectedRoute.subscribe(function (value) {
        myMap.geoObjects.remove(polyLine);
        createPolyLine(value.Route.Points.map(function(point){
            return [point.X, point.Y];
        }));
    })
       
        



    }









ymaps.ready(init);// инициализация карты после загрузки страницы 
