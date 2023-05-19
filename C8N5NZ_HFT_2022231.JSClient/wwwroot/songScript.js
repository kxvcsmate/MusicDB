let songs = [];
let connection = null;
let songIdToUpdate = -1;
let albumid = 1;
getdata();
setupSignalR();

async function getdata() {
    await fetch('http://localhost:53770/song')
        .then(x => x.json())
        .then(y => {
            songs = y;
            display();
        });
}

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:53770/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("SongCreated", (user, message) => {
        getdata();
    });

    connection.on("SongDeleted", (user, message) => {
        getdata();
    });

    connection.on("SongUpdated", (user, message) => {
        getdata();
    });

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
    songs.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.songId + "</td><td>"
            + t.songTitle + "</td><td>" + t.length + "</td><td>" + 
            `<button type="button" onclick="remove(${t.songId})">Delete</button>` + "  " +
            `<button type="button" onclick="showupdate(${t.songId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:53770/song/' + id, {
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

function create() {
    let songname = document.getElementById('songname').value;
    let length = document.getElementById('length').value;
    fetch('http://localhost:53770/song', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                songTitle: songname, length: length
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showupdate(id) {
    document.getElementById('songnametoupdate').value = songs.find(t => t['songId'] == id)['songTitle'];
    document.getElementById('lengthtoupdate').value = songs.find(t => t['songId'] == id)['length'];
    albumid = songs.find(t => t['songId'] == id)['albumId'];
    document.getElementById('updateformdiv').style.display = 'flex';
    songIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let songname = document.getElementById('songnametoupdate').value;
    let length = document.getElementById('lengthtoupdate').value;
    fetch('http://localhost:53770/song', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { songTitle: songname, length: length, albumId: albumid, songId: songIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}