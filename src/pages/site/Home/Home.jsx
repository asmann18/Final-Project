import React from 'react'
import SiteHeaderMobileNavbar from '../../../components/site/Header/SiteHeaderMobileNavbar'
import HomeSection1 from '../../../components/site/Home/HomeSection1'
import HomeSection2 from '../../../components/site/Home/HomeSection2'
import '../../../assets/styles/site/Home.scss'
import HomeSection3 from '../../../components/site/Home/HomeSection3'
const Home = () => {
  return (
    <>
    <div className='text-center'>
    <HomeSection1/>
    <HomeSection2/>
    <HomeSection3/>
    </div>
    </>
  )
}

export default Home