// StAuth10244: I Darshil Gajera, 000867069 certify that this material is my original work. No other person's work has been used without due acknowledgement. I have not made my work available to anyone else.

import React, { useState, useEffect } from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';


export function Search() {

  const [searchResults, setSearchResults] = useState([]);
  const [isLoaded, setIsLoaded] = useState(false);
  const [pets, setPets] = useState([]);


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
  useEffect(fetchPets, [pets]);




  // Searches for pets in the pet inventory.  Again we use hardcoded data but
  // we could build a custom fetch URL string.
  function searchPet(text) {
    fetch("http://localhost:3001/api?act=search&term=" + text)
      .then(res => res.json())
      .then(
        (result) => {
          setSearchResults(result);
        });
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
        <div className='searchDiv'>
          <Box
            component="form"
            sx={{
              '& .MuiTextField-root': { m: 1, width: '25ch' },
            }}
            noValidate
            autoComplete="off"
          >
            <TextField
              id="standard-search"
              label="Search"
              type="search"
              variant="standard"
              onChange={(e) => searchPet(e.target.value)}
            />
          </Box>

        </div>
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
                </TableRow>
              </TableHead>
              <TableBody>
                {searchResults != '' ? (

                  searchResults.map((pet) => (
                    <TableRow key={pet.id}>
                      <TableCell>{pet.animal}</TableCell>
                      <TableCell>{pet.description}</TableCell>
                      <TableCell>{pet.age}</TableCell>
                      <TableCell>{pet.price}</TableCell>
                    </TableRow>
                  ))

                ) : pets.map((pet) => (
                  <TableRow key={pet.id}>
                    <TableCell>{pet.animal}</TableCell>
                    <TableCell>{pet.description}</TableCell>
                    <TableCell>{pet.age}</TableCell>
                    <TableCell>{pet.price}</TableCell>
                  </TableRow>
                ))
                }
              </TableBody>
            </Table>
          </TableContainer>
        </div>
      </div>
    );
  }


}
