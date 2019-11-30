var map;
function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 4.6199212, lng: -74.0865597 },
        zoom: 15
    });
}

setInterval(function () {
    var marker = new google.maps.Marker({
        position: { lat: 4.6199212, lng: -74.0865597 },
        map: map,
        title: 'Hello World!'
    });
}, 5000);