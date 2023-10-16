import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import axios from 'axios';
import { json } from 'react-router-dom';

var token=localStorage.getItem("tokenData")
if(token=!undefined){
console.log(token)
    axios.defaults.headers.common['Authorization']="Bearer "+JSON.parse(localStorage.getItem("tokenData")).token
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <App />
);


