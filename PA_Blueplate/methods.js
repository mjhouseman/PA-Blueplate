function getLocation() {
    // Check for geolocation support
    if (navigator.geolocation) {
        // Use method getCurrentPosition to get coordinates
        document.getElementById('lblGPSAvailability').innerHTML = "GPS unavailable";
        navigator.geolocation.getCurrentPosition(function (position) {
            document.getElementById('hdnLatitude').value = position.coords.latitude;
            document.getElementById('hdnLongitude').value = position.coords.longitude;

            document.getElementById('lblGPSAvailability').innerHTML = position.coords.latitude + ", " + position.coords.longitude;
        });
    } else {
        document.getElementById('lblGPSAvailability').innerHTML = "GPS unavailable";
    }
}