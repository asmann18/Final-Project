import React, { useEffect, useState } from 'react'
import logo from '../../../assets/images/logo_red.png'
import axios from 'axios'
import PersonIcon from '@mui/icons-material/Person';

const AdminHeaderTop = () => {
  const [username,setUsername]=useState("")
  useEffect(()=>{
axios.get('https://localhost:7066/api/Users/UserGetInfo').then(res=>{
    setUsername(res.data.result.data.username)
    // console.log(username)
  
})
  },[])
  return (
    <div className='adminHeaderTop'>
      <div className="logo">
        <div className="img">
        <img src={logo} alt="logo" />
        </div>
        <h2>Admin Panel</h2>
      </div>
      <div className="search">
        <input type="text" placeholder='Search'/>
      </div>
      <div className="userInfo">
        <p>{username}</p>
        <PersonIcon/>
      </div>
    </div>
  )
}

export default AdminHeaderTop