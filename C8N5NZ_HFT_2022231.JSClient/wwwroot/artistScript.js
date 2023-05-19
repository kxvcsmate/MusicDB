let artists = [];
let connection = null;
let artistIdToUpdate = -1;
getdata();
setupSignalR();

async function getdata() {
    await fetch('http://localhost:53770/artist')
            .then(x => x.json())
            .then(y => {
                artists = y;
                display();
            });
}

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:53770/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ArtistCreated", (user, message) => {
        getdata();
    });

    connection.on("ArtistDeleted", (user, message) => {
        getdata();
    });

    connection.on("ArtistUpdated", (user, message) => {
        getdata();
    })

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

function display() {
    document.getElementById('resultarea').innerHTML = "";
    artists.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.artistId + "</td><td>"
            + t.name + "</td><td>" +
        `<button type="button" onclick="remove(${t.artistId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.artistId})">Update</button>`
            + "</td></tr>";
    });
}

function create() {
    let artistname = document.getElementById('artistname').value;
    fetch('http://localhost:53770/artist', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: artistname })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:53770/artist/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let artistname = document.getElementById('artistnametoupdate').value;
    fetch('http://localhost:53770/artist', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: artistname, artistId: artistIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('artistnametoupdate').value = artists.find(t => t['artistId'] == id)['name'];
    document.getElementById('updateformdiv').style.display = 'flex';
    artistIdToUpdate = id;
}