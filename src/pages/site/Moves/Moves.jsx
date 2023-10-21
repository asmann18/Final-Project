import React, { useEffect, useState } from 'react'
import BannerSlider from '../../../components/site/Common/BannerSlider'
import '../../../assets/styles/site/Moves.scss'
import axios from 'axios'
import SiteTable from '../../../components/site/Common/SiteTable'
const MovesPage = () => {
  return (
    <div className='movesPage'>
      <BannerSlider content={"MƏŞQ HƏRƏKƏTLƏRİ"}/>
      <SiteTable/>
    </div>
  )
}

export default MovesPage