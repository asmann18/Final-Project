import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import axios from 'axios';
import { json } from 'react-router-dom';
const token=localStorage.getItem("tokenData")
if(token=!undefined){

    axios.defaults.headers.common['Authorization']="Bearer "+JSON.parse(token).token
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <App />
);


