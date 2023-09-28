import React from 'react'
import Logo from '../../../assets/images/atlet-logo3.png'
import  '../../../assets/styles/site/layout/Header.scss'

const SiteHeaderLogo = () => {
  return (
    <>
    <div className="siteHeaderLogo">
        <img src={Logo} alt="" />
    </div>
    </>
  )
}

export default SiteHeaderLogo