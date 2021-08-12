window.disableCheckbox = (elementId, markers) => {
    var elem = document.getElementById(elementId);
    elem.setAttribute("disabled","true");
    }

window.saveInSession = (elementId) => {
    var val = document.getElementById(elementId).value;
    var streetsInSession = JSON.parse(window.sessionStorage.getItem('selected'));
    var streets = streetsInSession != null ? streetsInSession : [];
    streets.push(val);
    window.sessionStorage.setItem('selected', JSON.stringify(streets));
}

window.sessionStorageClean = () => {
    window.sessionStorage.clear();
}