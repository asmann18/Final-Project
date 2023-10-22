import React, { useContext, useState } from 'react'
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import PersonIcon from '@mui/icons-material/Person';

import MenuIcon from '@mui/icons-material/Menu';
import  '../../../assets/styles/site/layout/Header.scss'
import  '../../../assets/styles/site/layout/Header.scss'
import CloseIcon from '@mui/icons-material/Close';
import MainContext from '../../../contexts/MainContext';
import { Link } from 'react-router-dom';

const SiteHeaderBasketAndLogin = () => {
  const[toggleMenu,setToggleMenu]=useState(false);
  const data=useContext(MainContext)


  function menuToggle(){
    setToggleMenu(!toggleMenu)
  }
  const loginToggle=()=>{
    data.setToggleLogin(!data.toggleLogin)
  }
  return (
    <div className='siteHeaderBasketAndLogin'>
    <Link to={"/basket"}>

    <div className="basket">
        
        <ShoppingCartIcon  />
        
    </div>
    </Link>
    <div onClick={loginToggle} className="login ">
       <PersonIcon />
    </div>
    <div onClick={menuToggle} className="navbar">
     {toggleMenu? <MenuIcon/> : <CloseIcon/>}
    </div>

    </div>
  )
}

export default SiteHeaderBasketAndLogin