import React from 'react'
import SiteFooterAbout from '../../../components/site/Footer/SiteFooterAbout'
import SiteFooterCategories from '../../../components/site/Footer/SiteFooterCategories'
import SiteFooterMenu from '../../../components/site/Footer/SiteFooterMenu'
import  '../../../assets/styles/site/layout/Footer.scss'
import SiteFooterCopyright from '../../../components/site/Footer/SiteFooterCopyright'
import SiteFooterIcons from '../../../components/site/Footer/SiteFooterIcons'


const Footer = () => {
  return (
    <footer className='footer'>
      <div className="top">
       
        <SiteFooterAbout/>
        <div className="shortcuts">
        <SiteFooterCategories className="categories"/>
        <SiteFooterMenu />
        </div>
      </div>
      <div className="bottom">
        <SiteFooterCopyright/>
        <SiteFooterIcons/>
      </div>

    </footer>
  )
}

export default Footer