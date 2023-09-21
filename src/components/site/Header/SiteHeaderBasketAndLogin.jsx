import React from 'react'
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import PersonIcon from '@mui/icons-material/Person';

const SiteHeaderBasketAndLogin = () => {
  return (
    <div className='flex '>
    <div className="basket text-white flex justify-center items-center w-20 h-20 bg-red-600 p-5">
        <ShoppingCartIcon  />
    </div>
    <div className="login text-white flex justify-center items-center w-20 h-20 p-5">
       <PersonIcon />
    </div>
    
    </div>
  )
}

export default SiteHeaderBasketAndLogin