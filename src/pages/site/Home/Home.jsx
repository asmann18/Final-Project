import React from 'react'
import SiteHeaderMobileNavbar from '../../../components/site/Header/SiteHeaderMobileNavbar'
import HomeSection1 from '../../../components/site/Home/HomeSection1'
import HomeSection2 from '../../../components/site/Home/HomeSection2'
import HomeSection4 from '../../../components/site/Home/HomeSection4'
import '../../../assets/styles/site/Home.scss'
import HomeSection3 from '../../../components/site/Home/HomeSection3'
import HomeSection5 from '../../../components/site/Home/HomeSection5'
import HomeBlogSection from '../../../components/site/Home/HomeBlogSection'
import Swipper from '../../../components/site/Home/Swipper'
import Advertising from '../../../components/Common/Advertising'
const Home = () => {
  return (
    <>
    <div className='text-center'>
    <HomeSection1/>
    <HomeSection2/>
    <HomeSection3/>
    <Advertising/>
    <HomeSection4/>
    <HomeSection5/>
    <Advertising/>
    <HomeBlogSection/>
    <Swipper/>
    </div>
    </>
  )
}

export default Home