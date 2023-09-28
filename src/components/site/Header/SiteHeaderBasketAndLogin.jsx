import React, { useState } from 'react'
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import PersonIcon from '@mui/icons-material/Person';

import MenuIcon from '@mui/icons-material/Menu';
import  '../../../assets/styles/site/layout/Header.scss'
import  '../../../assets/styles/site/layout/Header.scss'
import CloseIcon from '@mui/icons-material/Close';

const SiteHeaderBasketAndLogin = () => {
  const[toggleMenu,setToggleMenu]=useState(false);
  function menuToggle(){
    setToggleMenu(!toggleMenu)
  }
  return (
    <div className='siteHeaderBasketAndLogin'>
    <div className="basket">
        <ShoppingCartIcon  />
    </div>
    <div className="login ">
       <PersonIcon />
    </div>
    <div onClick={menuToggle} className="navbar">
     {toggleMenu? <MenuIcon/> : <CloseIcon/>}
    </div>

    </div>
  )
}

export default SiteHeaderBasketAndLogin