let artists = [];
let albums = [];
let ratings = [];
let albumlengths = [];
let songs = [];
let connection = null;
getdata();
getdata2();
getdata3();
getdata4();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:53770/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

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

async function getdata() {
    await fetch('http://localhost:53770/stat/NumberOfSongsByAlbum')
        .then(x => x.json())
        .then(y => {
            albums = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    albums.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.albumTitle + "</td><td>"
            + t.songCount + "</td></tr>";
    });
}

async function getdata2() {
    await fetch('http://localhost:53770/stat/NumberOfAlbumsByArtist')
        .then(x => x.json())
        .then(y => {
            artists = y;
            display2();
        });
}

function display2() {
    document.getElementById('resultarea2').innerHTML = "";
    artists.forEach(t => {
        document.getElementById('resultarea2').innerHTML +=
            "<tr><td>" + t.artistName + "</td><td>"
            + t.albumCount + "</td></tr>";
    });
}

async function getdata3() {
    await fetch('http://localhost:53770/stat/AVGRatingByArtist')
        .then(x => x.json())
        .then(y => {
            ratings = y;
            display3();
        });
}

function display3() {
    document.getElementById('resultarea3').innerHTML = "";
    ratings.forEach(t => {
        document.getElementById('resultarea3').innerHTML +=
            "<tr><td>" + t.artistName + "</td><td>"
            + t.avgRating + "</td></tr>";
    });
}

async function getdata4() {
    await fetch('http://localhost:53770/stat/AlbumByLength')
        .then(x => x.json())
        .then(y => {
            albumlengths = y;
            display4();
        });
}

function display4() {
    document.getElementById('resultarea4').innerHTML = "";
    albumlengths.forEach(t => {
        document.getElementById('resultarea4').innerHTML +=
            "<tr><td>" + t.albumTitle + "</td><td>"
            + t.length + "</td></tr>";
    });
}

function search() {
    let givenlength = document.getElementById('givenlength').value;
    fetch(`http://localhost:53770/Stat/GetSongsByLength?length=`+`${givenlength}`)
        .then(x => x.json())
        .then(y => {
            songs = y;
            display5();
        });
}

function display5() {
    document.getElementById('resultarea5').innerHTML = "";
    songs.forEach(t => {
        document.getElementById('resultarea5').innerHTML +=
            "<tr><td>" + t.songTitle + "</td><td>"
            + t.length + "</td></tr>";
    });
}