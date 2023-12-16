import React, { useEffect, useState } from 'react'
import logo from '../../../assets/images/logo_red.png'
import axios from 'axios'
import PersonIcon from '@mui/icons-material/Person';
import { Link } from 'react-router-dom';

const AdminHeaderTop = () => {
  const [username, setUsername] = useState("")
  const [error,setError] = useState("")
  const [dummy,setDummy] = useState(false)

  useEffect(() => {
    axios.get("https://localhost:7066/api/Users/UserGetInfo").then(res=>{
      setUsername(res.data.data.username)
      setDummy(!dummy)
    }).catch(err=>{
      setError(err.message)
      // setDummy(!dummy)

    })

  }, [])
  return (
    <div className='adminHeaderTop'>
      <Link to={"/"} className="logo">
        <div className="img">
          <img src={logo} alt="logo" />
        </div>
        <h2>Admin Panel</h2>
      </Link>
      <div className="search">
        <input type="text" placeholder='Search' />
      </div>
      <div className="userInfo">
        <p>{username}</p>
        <PersonIcon />
      </div>
    </div>
  )
}

export default AdminHeaderTop