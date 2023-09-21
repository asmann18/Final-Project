import React from 'react'
import SiteHeaderNavbar from '../../../components/site/Header/SiteHeaderNavbar'
import SiteHeaderInfo from '../../../components/site/Header/SiteHeaderInfoIcons'
import SiteHeaderLogo from '../../../components/site/Header/SiteHeaderLogo'
import SiteHeaderBasketAndLogin from '../../../components/site/Header/SiteHeaderBasketAndLogin'

const Header = () => {
  return (
    <header className='font-sans bg-black max-h-90 flex justify-center gap-5 '>
      <div className="header--left">
        <SiteHeaderLogo />
      </div>
      <div className="header--medium gap-10">
        <SiteHeaderInfo />
        <SiteHeaderNavbar />
      </div>
      <div className="header--right">
        <SiteHeaderBasketAndLogin/>
      </div>

    </header>
  )
}

export default Header