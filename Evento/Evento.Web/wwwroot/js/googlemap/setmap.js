function initMap() {

    var mapOptions, map, marker, infoWindow = '';
    var element = document.getElementById('map');
    var longtitude = document.getElementById("lng");
    var latitude = document.getElementById("lat");
    var place = document.getElementById("place");

    mapOptions = {
        zoom: 20,
        center: new google.maps.LatLng(49.993500, 36.230385),

        zoomControl: true,
        scrollWheel: true, 
        draggable: true, 
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
    place.value = "Kharkiv,Ukraine";
    latitude.value = marker.getPosition().lat();
    longtitude.value = marker.getPosition().lng();
 


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