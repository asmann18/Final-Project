import React, { useEffect, useRef } from 'react'
import SiteHeaderNavbar from '../../../components/site/Header/SiteHeaderNavbar'
import SiteHeaderInfo from '../../../components/site/Header/SiteHeaderInfoIcons'
import SiteHeaderLogo from '../../../components/site/Header/SiteHeaderLogo'
import SiteHeaderBasketAndLogin from '../../../components/site/Header/SiteHeaderBasketAndLogin'
import '../../../assets/styles/site/layout/Header.scss'
import SiteHeaderMobileNavbar from '../../../components/site/Header/SiteHeaderMobileNavbar'
import Login from '../../../components/site/Home/Login'
import MainContext from '../../../contexts/MainContext'
import { useState } from 'react'
const Header = () => {
  const [toggleLogin, setToggleLogin] = useState(false);
  const data = { toggleLogin, setToggleLogin }

 


  return (
    <MainContext.Provider value={data}>

      <header className='header'>
        <div className="headerLeft">
          <SiteHeaderLogo className='siteHeaderLogo' />
        </div>


        <div className="headerCenter">
          <SiteHeaderInfo />
          <SiteHeaderNavbar />
        </div>
        <div className="headerRight">
          <SiteHeaderBasketAndLogin />
        </div>
        {toggleLogin ?
          <div className="loginFormBg">
            <div className="loginFormSection" >
              <Login />
            </div>
          </div>
          : ""}

      </header>
    </MainContext.Provider>
  )
}

export default Header