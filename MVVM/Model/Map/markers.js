function addMarker(lat, lon, title) {
    L.marker([lat, lon]).addTo(map)
        .bindPopup(title);
}
