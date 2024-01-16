// StAuth10244: I Darshil Gajera, 000867069 certify that this material is my original work. No other person's work has been used without due acknowledgement. I have not made my work available to anyone else.

// Starter code for the front-end, includes examples of accessing all server 
// API routes with AJAX requests.

import './App.css';
import React from 'react';
import { Routes, Route, NavLink, Link, useParams, Outlet } from "react-router-dom";
import { Pets } from './Pets';
import { Search } from './Search';
import { About } from './About';
import { Home } from './Home';


function Inventory() {
  return (
    <Pets />
  );
}

function App() {
  return (
    <div className='pageMenu'>
      <ul>
        <li><NavLink className='navlink' to="/">Home</NavLink></li>
        <li><NavLink className='navlink' to="/inventory">Inventory</NavLink></li>
        <li><NavLink className='navlink' to="/search">Search</NavLink></li>
        <li><NavLink className='navlink' to="/about">About</NavLink></li>
      </ul>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/inventory" element={<Inventory />} />
        <Route path="/search" element={<Search />} />
        <Route path="/about" element={<About />} />
      </Routes>
    </div>
  );
}

export default App;
