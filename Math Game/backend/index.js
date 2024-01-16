// "StAuth10244: I Darshil Gajera, 000867069 certify that this material is my original work. No other person's work has been used without due acknowledgement. I have not made my work available to anyone else."

const express = require('express');
const sqlite3 = require('sqlite3').verbose();
const redis = require('redis');
const cors = require('cors');
let count = 1;
// Creating a Redis client
client = redis.createClient({
    url: "redis://redis-17776.c323.us-east-1-2.ec2.cloud.redislabs.com:17776",
    password: "2vpwDhZOodMybC2AklHePMjpgvAaIMD6"
});

// Connecting to Redis
client.connect();

// Handle Redis errors
client.on("error", function (err) {
    console.log("Error: " + err)
});

// Create an Express application
const app = express();

// Enable CORS middleware
app.use(cors());

// Parse JSON and form data
app.use(express.json());
app.use(express.urlencoded({ extended: false }));

// Create an SQLite database and define a users table
const db = new sqlite3.Database('mathgameusercredential');
db.serialize(() => {
    db.run('CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, username TEXT, password TEXT)');
});

// Handle login requests
app.post('/login', (req, res) => {
    const { username, password } = req.body;
    console.log('Received login request:', username, password);

    // Check if the user exists in the SQLite database
    db.get('SELECT * FROM users WHERE username = ? AND password = ?', [username, password], (err, row) => {
        if (row) {
            res.json({ status: 'success' });
        } else {
            res.json({ status: 'failure' });
        }
    });
});

// Handle signup requests
app.post('/signup', (req, res) => {
    const { username, password } = req.body;

    if (!username || !password) {
        res.json({ status: 'failure', message: 'All fields must be completed' });
        return;
    }

    // Insert a new user into the SQLite database
    db.run('INSERT INTO users (username, password) VALUES(?,?)', [username, password], (err) => {
        if (err) {
            res.json({ status: 'failure', message: 'Error creating user' });
            return;
        }

        res.json({ status: 'success' });
    });
});

// Handle update requests, store data in Redis
app.post('/update', async (req, res) => {
    console.log("/update requested ...." + req.body.username + " " + req.body.result);
    count
    try {
        const { username, result } = req.body;
        // const key = `user:${username}:result`;
        const key = "record_id";

        // set data 
        await client.set(key, count);

        const key1 = `user:${count}:username`;
        await client.set(key1, username);
        count++;
        console.log(`/update requested: ${username} ${result}`);
        await client.set(key, count);
        res.json({ status: 'success' });
    } catch (error) {
        console.error("Error updating data: ", error);
        res.status(500).json({ status: 'error', message: 'Internal Server Error' });
    }
});

// Handle leaderboard requests, retrieve data from Redis
app.post("/leaderboard", async function (req, res) {
    try {
        const leaderboard = [];
        const recordId = await client.get("record_id");
        const getuser = recordId-1;
        const exists = await client.exists(`user:${getuser}:username`);

        // no record found
        if (exists === 0) {
            console.log("No records found");
            return res.send("No records found");
        }

        // Assigning the start id depending on the length of records
        const startId = recordId <= 10 ? 1 : recordId - 10;

        for (let i = recordId - 1; i >= startId; i--) {
            const usernameKey = `user:${i}:username`;

            const username = await client.get(usernameKey);

            leaderboard.push({ username });
        }
        console.log("leaderboard",leaderboard);
        res.send({"data":leaderboard});
    } catch (err) {
        console.error("Error retrieving data:", err);
        res.status(500).send("Error retrieving data");
    }
});

// Start the Express server on port 3000
var server = app.listen(3000, function () {
    console.log("Server listening on port 3000");
});
