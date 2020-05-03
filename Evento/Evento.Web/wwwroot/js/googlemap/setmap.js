function initMap() {

    var mapOptions, map, marker, searchBox, city,
        infoWindow = '';
    var element = document.getElementById('map');
    var longtitude = document.getElementById("lng");
    var latitude = document.getElementById("lat");


    mapOptions = {
        zoom: 20,
        center: new google.maps.LatLng(49.993500, 36.230385),

        zoomControl: true,
        // Disables the controls like zoom control on the map if set to true
        scrollWheel: true, // If set to false disables the scrolling on the map.
        draggable: true, // If set to false , you cannot move the map around.
        maxZoom: 60,
        minZoom: 20,
        disableDefaultUI: true

    };


    map = new google.maps.Map(element, mapOptions);

    marker = new google.maps.Marker({
        position: mapOptions.center,
        map: map,
        draggable: true
    });



    google.maps.event.addListener(marker, "dragend", function (event) {
        var lat, long, address;
        lat = marker.getPosition().lat();
        long = marker.getPosition().lng();


        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({ latLng: marker.getPosition() }, function (result, status) {
            if ('OK' === status) {
                address = result[0].formatted_address;
                resultArray = result[0].address_components;

                place.value = address;
                latitude.value = lat;
                longtitude.value = long;



            } else {
                console.log('Geocode was not successful for the following reason: ' + status);
            }
            if (infoWindow) {
                infoWindow.close();
            }

            infoWindow = new google.maps.InfoWindow({
                content: address
            });

            infoWindow.open(map, marker);
        });
    });


}