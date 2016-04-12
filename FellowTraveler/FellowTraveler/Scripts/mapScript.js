ymaps.ready(init);// инициализация карты после загрузки страницы 
var myMap;


function init() {

    var geolocation = ymaps.geolocation,
    myMap = new ymaps.Map("map", {
        center: [geolocation],
        zoom: 15,
        controls: ['zoomControl', 'typeSelector', 'fullscreenControl', 'geolocationControl', 'trafficControl', 'searchControl'] // <!-- добавляет на карту кнопки управления: масштабирования, поиска ('searchControl', ), слои, полный экран, местоположения пользователя, пробки -->

    });

    geolocation.get({
        provider: 'yandex',
        mapStateAutoApply: true
    }).then(function (result) {
        result.geoObjects.options.set('preset', 'island#redCircleIcon');
        result.geoObjects.get(0).properties.set();
        myMap.geoObjects.add(result.geoObjects);
    })


    //multiRoute.getRoutes().get(0).getPaths().get(0).properties._ec.coordinates  создать сайт, чтобы он брал этот массив и отправлял на сервер

    // Получаем ссылки на нужные элементы управления.
    var searchControl = myMap.controls.get('searchControl');
    var geolocationControl = myMap.controls.get('geolocationControl');

   
    var myButton1 = new ymaps.control.Button({
        data: {
            content: 'Оправить',
            title: 'Добавить метку на карту'
        }
    });
   

    var myButton1 = new ymaps.control.Button({
        data: {
            content: 'Оправить',
            title: 'Добавить метку на карту'
        }
    });


    myButton1.events.add('click', function () {
        var coordinates = multiRoute.getRoutes().get(0).getPaths().get(0).properties._ec.coordinates // создать сайт, чтобы он брал этот массив и отправлял на сервер
        coordinates = coordinates.map(function (el) {
            return { X: el[0], Y: el[1] };
        })
        //Ajax
    });

    //myMap.events.add('click', onMapClick);
    myMap.controls.add(myButton1, { selectOnClick: false });
 //   myMap.events.add('click', onMapClick);

    //function onMapClick(e) {
    //     clearSourcePoint();
    //     alert(e.get('coords'));
    //    sourcePoint = new ymaps.Placemark(e.get('coords'), { iconContent: 'Транзит' }, { preset: 'islands#greenStretchyIcon' });
    //    var referencePoints = multiRoute.model.getReferencePoints();
    //    referencePoints.splice(1, 0, e.get('coords'));
    //    multiRoute.model.setReferencePoints(referencePoints, [1]);
    //    myMap.geoObjects.add(sourcePoint);
    //      createRoute();
    //}


    function clearSourcePoint(keepSearchResult) {
        if (!keepSearchResult) {
            searchControl.hideResult();
        }

        if (sourcePoint) {
            myMap.geoObjects.remove(sourcePoint);
            sourcePoint = null;
        }
    }

    /*
    * Функция, создающая маршрут.
    */
    function createRoute(routingMode, targetBtn) {
        // Если `routingMode` был передан, значит вызов происходит по клику на пункте выбора типа маршрута,
        // следовательно снимаем выделение с другого пункта, отмечаем текущий пункт и закрываем список.
        // В противном случае — перестраиваем уже имеющийся маршрут или ничего не делаем.
        if (routingMode) {
            if (routingMode == 'auto') {
                masstransitRouteItem.deselect();
            } else if (routingMode == 'masstransit') {
                autoRouteItem.deselect();
            }

            targetBtn.select();
            routeTypeSelector.collapse();
        } else if (currentRoutingMode) {
            routingMode = currentRoutingMode;
        } else {
            return;
        }

        // Если начальная точка маршрута еще не выбрана, ничего не делаем.
        if (!sourcePoint) {
            currentRoutingMode = routingMode;
            geolocationControl.events.fire('press');
            return;
        }

        // Стираем предыдущий маршрут.
        clearRoute();

        currentRoutingMode = routingMode;

        // Создаём маршрут нужного типа из начальной в конечную точку.
        currentRoute = new ymaps.multiRouter.MultiRoute({
            referencePoints: [sourcePoint, targetPoint],
            params: { routingMode: routingMode }
        }, {
            boundsAutoApply: true
        });

        // Добавляем маршрут на карту.
        myMap.geoObjects.add(currentRoute);
    }

    function clearRoute() {
        myMap.geoObjects.remove(currentRoute);
        currentRoute = currentRoutingMode = null;
    }

   ymaps.modules.require([
        'MultiRouteCustomView'

    ], function (MultiRouteCustomView) {
        new MultiRouteCustomView(multiRoute);
    });

    var multiRoute = new ymaps.multiRouter.MultiRoute({
        // Описание опорных точек мультимаршрута.
        referencePoints: []
    }, {
        boundsAutoApply: true,
        editorMidPointsType: "viaPoint",
        editorDrawOver: false
    });


    multiRoute.editor.start({
        addWayPoints: true,
        removeWayPoints: true,
        dragWayPoints: true,
        dragViaPoints: true,
        removeViapoints: true

    });

    myMap.geoObjects.add(multiRoute);

}
