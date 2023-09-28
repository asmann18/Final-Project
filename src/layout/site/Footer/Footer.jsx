import React from 'react'
import SiteFooterAbout from '../../../components/site/Footer/SiteFooterAbout'
import SiteFooterCategories from '../../../components/site/Footer/SiteFooterCategories'
import SiteFooterMenu from '../../../components/site/Footer/SiteFooterMenu'
import  '../../../assets/styles/site/layout/Footer.scss'


const Footer = () => {
  return (
    <footer className='footer'>
      <div className="top">
        <SiteFooterAbout className="about"/>
        <SiteFooterCategories/>
        <SiteFooterMenu/>
      </div>


    </footer>
  )
}

export default Footer