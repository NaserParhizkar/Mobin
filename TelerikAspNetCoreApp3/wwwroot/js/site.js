﻿// Write your Javascript code.
function saveMessage(pathname) {
    //alert(pathname + " has been saved successfully!");

    document.getElementById('divServerValidations').innerText = pathname + " has been saved successfully!";

}

function setFocusOnElement(element) {
    element.focus();
}

function getCities() {
    var cities = ['New York', 'Los Angeles', 'Chicago', 'Houston', 'Phoenix', 'Philadelphia', 'San Antonio',
        'San Diego', 'Dallas', 'San Jose', 'Austin', 'Jacksonville', 'Fort Worth', 'Columbus', 'San Francisco',
        'Charlotte', 'Indianapolis', 'Seattle', 'Denver', 'Washington'];

    return cities;
}