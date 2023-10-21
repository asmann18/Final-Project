import React from 'react'



const BannerSlider = ({content,child}) => {
  return (
    <div className='bannerSlider'>
      <p>{content}</p>
      <span>{child}</span>
    </div>
  )
}

export default BannerSlider