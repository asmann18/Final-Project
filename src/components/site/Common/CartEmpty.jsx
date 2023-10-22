import React from 'react'
import cartEmptyImage from '../../../assets/images/cartEmpty.jpeg'
const CartEmpty = () => {
  return (
    <div className='cartEmpty'>
        <img src={cartEmptyImage} alt="" />
    </div>
  )
}

export default CartEmpty