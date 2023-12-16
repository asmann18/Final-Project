import React from 'react'
import '../../assets/styles/site/layout/Component.scss'
import Image from '../../assets/images/BadRequest.jpeg'
const Error = () => {
  return (
    <div className='badRequest'>
      <div className="img">
      <img src={Image} alt="" />
      </div>
    </div>
  )
}

export default Error