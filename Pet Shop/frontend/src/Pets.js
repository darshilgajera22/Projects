// StAuth10244: I Darshil Gajera, 000867069 certify that this material is my original work. No other person's work has been used without due acknowledgement. I have not made my work available to anyone else.


import React, { useState, useEffect } from 'react';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import EditIcon from '@mui/icons-material/Edit';





// Material UI is included in the install of the front end, so we have access
// to components like Buttons, etc, when we import them.
export function Pets() {

  // isLoaded keeps track of whether the initial load of pet data from the
  // server has occurred.  pets is the array of pets data in the table, and 
  // searchResults is the array of pets data after a search request.
  const [isLoaded, setIsLoaded] = useState(false);
  const [pets, setPets] = useState([]);
  const [newPetName, setNewName] = useState('');
  const [newPetDescription, setNewDescription] = useState('');
  const [newPetAge, setNewAge] = useState('');
  const [newPetPrice, setNewPrice] = useState('');
  const [editPetID, setEditPetID] = useState(null);
  const [editPetName, setEditPetName] = useState('');
  const [editPetDescription, setEditPetDescription] = useState('');
  const [editPetAge, setEditPetAge] = useState('');
  const [editPetPrice, setEditPetPrice] = useState('');




  // fetches all pet data from the server
  function fetchPets() {
    fetch("http://localhost:3001/api?act=getall")
      .then(res => res.json())
      .then(
        (result) => {
          setIsLoaded(true);
          setPets(result);
        });
  }

  // use fetchPets as an effect with an empty array as a 2nd argument, which 
  // means fetchPets will ONLY be called when the component first mounts
  useEffect(fetchPets, []);

  // Inserts a pet with hardcoded data in the URL for each query parameter, we 
  // could insert a pet with custom data by building a string like this:
  //
  // let url = "http://localhost:3001/api?act=add&animal=" + animal + ...
  //
  // fetch(url)
  // .then( ... )...
  //
  function addPet() {
    var petName = newPetName;
    var petDescription = newPetDescription;
    var petAge = newPetAge;
    var petPrice = newPetPrice;
    fetch("http://localhost:3001/api?act=add&animal=" + petName + "&description=" + petDescription + "&age=" + petAge + "&price=" + petPrice)
      .then(res => res.json())
      .then(
        (result) => {
          fetchPets();
        });

    setNewName('');
    setNewDescription('');
    setNewAge('');
    setNewPrice('');
  }

  // Deletes a pet from the pet inventory, using a hardcoded id query parameter
  // Again we could delete a pet with custom data by building a string like:
  //
  // let url = "http://localhost:3001/api?act=delete&id=" + id
  //
  // fetch(url)
  // .then( ... )...
  //
  // 
  function deletePet(petID) {
    if (petID) {
      fetch("http://localhost:3001/api?act=delete&id=" + petID)
        .then(res => res.json())
        .then(
          (result) => {
            fetchPets();
          });
    } else {
      console.error("Invalid petid");
    }

  }

  // Updates a pet in the pet inventory.  Again we use hardcoded data but 
  // could build a custom fetch URL string.
  function updatePet() {
    var petid = editPetID;
    var petName = editPetName;
    var petDescription = editPetDescription;
    var petAge = editPetAge;
    var petPrice = editPetPrice;
    fetch("http://localhost:3001/api?act=update&id=" + petid + "&animal=" + petName + "&description=" + petDescription + "&age=" + petAge + "&price=" + petPrice)
      .then(res => res.json())
      .then(
        (result) => {
          fetchPets();
        });


    setEditPetID("");
    setEditPetName("");
    setEditPetDescription("");
    setEditPetAge("");
    setEditPetPrice("");

  }


  function editPet(petID) {
    var editpets = [...pets];
    const petToEdit = editpets.find((pet) => pet.id === petID);
    setEditPetID(petToEdit.id);
    setEditPetName(petToEdit.animal);
    setEditPetDescription(petToEdit.description);
    setEditPetAge(petToEdit.age);
    setEditPetPrice(petToEdit.price);
  }


  // If data has loaded, render the table of pets, buttons that execute the 
  // above functions when they are clicked, and a table for search results. 
  // Notice how we can use Material UI components like Button if we import 
  // them as above.
  //
  if (!isLoaded) {
    return <div>Loading...</div>;
  } else {
    return (
      <div>
        <div className='petsTable'>
          <h2>Pets</h2>
          <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="Simple Table">
              <TableHead>
                <TableRow>
                  <TableCell align="center">Pet Name</TableCell>
                  <TableCell align="center">Pet Description</TableCell>
                  <TableCell align="center">Pet Age</TableCell>
                  <TableCell align="center">Pet Price</TableCell>
                  <TableCell align="center">Edit</TableCell>
                  <TableCell align="center">Delete</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {pets.map(pet => (
                  <TableRow key={pet.id}>
                    <TableCell>{pet.animal}</TableCell>
                    <TableCell>{pet.description}</TableCell>
                    <TableCell>{pet.age}</TableCell>
                    <TableCell>{pet.price}</TableCell>
                    <TableCell><EditIcon onClick={() => editPet(pet.id)} /></TableCell>
                    <TableCell><DeleteForeverIcon onClick={() => deletePet(pet.id)} /></TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        </div>

        <div className='addPetFormDiv'>
        <h2>Add New Pet</h2>
          <Box
            component="form"
            sx={{
              '& .MuiTextField-root': { m: 1, width: '25ch' },
            }}
            noValidate
            autoComplete="off"
          >
            <div>
              <TextField
                required
                id="AddPetName"
                label="Enter Pet Name"
                value={newPetName}
                onChange={(e) => setNewName(e.target.value)} />
              <TextField
                required
                id="AddPetDesc"
                label="Enter Pet Description"
                value={newPetDescription}
                onChange={(e) => setNewDescription(e.target.value)} />
              <TextField
                required
                id="AddPetAge"
                label="Enter Pet Age"
                value={newPetAge}
                onChange={(e) => setNewAge(e.target.value)} />
              <TextField
                required
                id="AddPetPrice"
                label="Enter Pet Price"
                value={newPetPrice}
                onChange={(e) => setNewPrice(e.target.value)} />
              <Button variant="contained" onClick={addPet}>Submit</Button>
            </div>
          </Box>
        </div>

        <br />

        {editPetID && (
          <div className='editPetFormDiv'>
          <h2>Edit Existing Pet</h2>
            <Box
              component="form"
              sx={{
                '& .MuiTextField-root': { m: 1, width: '25ch' },
              }}
              noValidate
              autoComplete="off"
            >
              <div>
                <TextField
                  required
                  id="EditPetName"
                  label="Enter Pet Name"
                  value={editPetName}
                  onChange={(e) => setEditPetName(e.target.value)}
                />
                <TextField
                  required
                  id="EditPetDesc"
                  label="Enter Pet Description"
                  value={editPetDescription}
                  onChange={(e) => setEditPetDescription(e.target.value)}
                />
                <TextField
                  required
                  id="EditPetAge"
                  label="Enter Pet Age"
                  value={editPetAge}
                  onChange={(e) => setEditPetAge(e.target.value)}
                />
                <TextField
                  required
                  id="EditPetPrice"
                  label="Enter Pet Price"
                  value={editPetPrice}
                  onChange={(e) => setEditPetPrice(e.target.value)}
                />
                <Button variant="contained" onClick={updatePet}>Submit</Button>
              </div>
            </Box>
          </div>
        )
        }
      </div>


    );
  }



}

