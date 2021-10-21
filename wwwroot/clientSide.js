window.disableCheckbox = (elementId, markers) => {
    var elem = document.getElementById(elementId);
    elem.setAttribute("disabled","true");
    }

window.saveInSession = (elementId, path) => {
    //var val = document.getElementById(elementId).value;
    var streetsInSession = JSON.parse(window.sessionStorage.getItem(path));
    var streets = streetsInSession != null ? streetsInSession : [];
    streets.push(elementId);
    window.sessionStorage.setItem(path, JSON.stringify(streets));
}

window.sessionStorageClean = (nrPath) => {
    var stagedPaths = window.sessionStorage.getItem(nrPath.replace('Nr', ''));
    if (stagedPaths == null) {
        window.sessionStorage.clear();
        return null;
    }
    else {
        return stagedPaths;
    }
}