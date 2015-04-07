function getLocation() {
    // Check for geolocation support
    if (navigator.geolocation) {
        // Use method getCurrentPosition to get coordinates
        navigator.geolocation.getCurrentPosition(function (position) {
            document.getElementById('hdnLatitude').value = position.coords.latitude;
            document.getElementById('hdnLongitude').value = position.coords.longitude;
        });
    }
}

function dial(e) {
    console.log("calling me!");
    console.log(e.value);
    alert(e);
    window.location = 'tel:5555555555';
}