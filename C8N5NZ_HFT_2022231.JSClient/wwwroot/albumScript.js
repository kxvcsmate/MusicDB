let albums = [];
let connection = null;
let albumIdToUpdate = -1;
let artistid = 1;
getdata();
setupSignalR();

async function getdata() {
    await fetch('http://localhost:53770/album')
        .then(x => x.json())
        .then(y => {
            albums = y;
            display();
        });
}

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:53770/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AlbumCreated", (user, message) => {
        getdata();
    });

    connection.on("AlbumDeleted", (user, message) => {
        getdata();
    });

    connection.on("AlbumUpdated", (user, message) => {
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
    albums.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.albumId + "</td><td>"
            + t.albumTitle + "</td><td>" + t.rating + "</td><td>" + t.release + "</td><td>" +
            `<button type="button" onclick="remove(${t.albumId})">Delete</button>` + "  " +
            `<button type="button" onclick="showupdate(${t.albumId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:53770/album/' + id, {
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
    let albumname = document.getElementById('albumname').value;
    let rating = document.getElementById('rating').value;
    let releasedate = document.getElementById('releasedate').value;
    fetch('http://localhost:53770/album', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                albumTitle: albumname, rating: rating,
                release: releasedate
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
    document.getElementById('albumnametoupdate').value = albums.find(t => t['albumId'] == id)['albumTitle'];
    document.getElementById('ratingtoupdate').value = albums.find(t => t['albumId'] == id)['rating'];
    document.getElementById('releasedatetoupdate').value = albums.find(t => t['albumId'] == id)['release'];
    artistid = albums.find(t => t['albumId'] == id)['artistId'];
    document.getElementById('updateformdiv').style.display = 'flex';
    albumIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let albumname = document.getElementById('albumnametoupdate').value;
    let rating = document.getElementById('ratingtoupdate').value;
    let releasedate = document.getElementById('releasedatetoupdate').value;
    fetch('http://localhost:53770/album', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { albumTitle: albumname, rating: rating, release: releasedate, artistId: artistid, albumId: albumIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}