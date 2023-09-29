import React from 'react'
import SiteHeaderNavbar from '../../../components/site/Header/SiteHeaderNavbar'
import SiteHeaderInfo from '../../../components/site/Header/SiteHeaderInfoIcons'
import SiteHeaderLogo from '../../../components/site/Header/SiteHeaderLogo'
import SiteHeaderBasketAndLogin from '../../../components/site/Header/SiteHeaderBasketAndLogin'
import  '../../../assets/styles/site/layout/Header.scss'
const Header = () => {
  return (
    <header className='header'>
      <div className="headerLeft">
        <SiteHeaderLogo  className='siteHeaderLogo'/>
      </div>
   

      <div className="headerCenter">
        <SiteHeaderInfo />
        <SiteHeaderNavbar  />
      </div>
      <div className="headerRight">
        <SiteHeaderBasketAndLogin/>
      </div>
    </header>
  )
}

export default Header