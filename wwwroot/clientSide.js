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

window.lightingBreakdownsStorage = (maxNumber) => {
    var reportNumber = document.getElementById('reportNumber').value;
    var date = document.getElementById('date').value;
    var streetLights = [];

    for (var i = 0; i < maxNumber; i++) {
        var streetLightNumber = document.getElementById('lamp' + i).value;
        var street = document.getElementById('via' + i).value;
        var streetNumber = document.getElementById('civico' + i).value;
        var feed = { streetLightNumber: streetLightNumber, street: street, streetNumber: streetNumber};
        streetLights.push(feed);
    }

    var feedToSave = { reportNumber: reportNumber, date: date, lampList: streetLights }
    window.sessionStorage.setItem("lightingBreakdowns", JSON.stringify(feedToSave));
};

window.serviceReportStorage = (maxOperatorNumber, maxVehicleNumber) => {

    var checkedTask = [];
    var addetti = [];
    var vehicles = [];

    var reportNumber = document.getElementById('reportNumber').value;
    var capoSquadra = document.getElementById('capoSquadra').value;
    var badgeIdCaposquadra = document.getElementById('badgeIdCaposquadra').value;
    var feedCaposquadra = { capoSquadra: capoSquadra, badge: badgeIdCaposquadra };
    addetti.push(feedCaposquadra);

    for (var o = 1; o <= maxOperatorNumber; o++) {
        var operator = document.getElementById('addetto' + o).value;
        var badgeId = document.getElementById('badgeId' + o).value;
        var feed = { operator: operator, badge: badgeId };
        addetti.push(feed);
    }

    for (var v = 1; v <= maxVehicleNumber; v++) {
        var type = document.getElementById('type' + v).value;
        var plate = document.getElementById('plate' + v).value;
        var km = document.getElementById('totKm' + v).value;
        var feedVehicle = { type: type, plate: plate, km: km };
        vehicles.push(feedVehicle);
    }

    for (var i = 1; i < 8; i++) {
        if (document.getElementById('task' + i).checked) {
            if (i == 6)
            {
                var feedWithEmergencyNote = { task: document.getElementById('task' + i).value, note: document.getElementById('noteForEmergency').value }
                checkedTask.push(feedWithEmergencyNote);
            }
            else if (i == 7) {
                var feedOtherWithNote = {
                    task: document.getElementById('task' + i).value,
                    note: document.getElementById('noteForOther').value
                }
                checkedTask.push(feedOtherWithNote);
            }
            else
            {
                var feedTask = {
                    task: document.getElementById('task' + i).value,
                    note: ""
                }
                checkedTask.push(feedTask);
            }
        }
            
    }

    var firstDepartureTime = document.getElementById('firstDepartureTime').value;
    var firstArrivalTime = document.getElementById('firstArrivalTime').value;
    var firstTotalTime = document.getElementById('firstTotalTime').value;
    var feedFirst = {departure: firstDepartureTime, arrival: firstArrivalTime, total: firstTotalTime};
    var secondDepartureTime = document.getElementById('secondDepartureTime').value;
    var secondArrivalTime = document.getElementById('secondArrivalTime').value;
    var secondTotalTime = document.getElementById('secondTotalTime').value;
    var feedSecond = { departure: secondDepartureTime, arrival: secondArrivalTime, total: secondTotalTime };
    var note = document.getElementById('note').value;

    var feedToSave = { reportNumber: reportNumber, tasks: checkedTask, operators: addetti, vehicles: vehicles, firstGroup: feedFirst, secondGroup: feedSecond, note: note }
    window.sessionStorage.setItem("serviceReport", JSON.stringify(feedToSave));
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