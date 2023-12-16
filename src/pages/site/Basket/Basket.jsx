import React, { useState } from 'react'
import BannerSlider from '../../../components/site/Common/BannerSlider'
import BasketTable from '../../../components/site/Common/BasketTable'
import '../../.././/assets/styles/site/Basket.scss'
import MainContext from '../../../contexts/MainContext'
const Basket = () => {
  const [togglePayment, setTogglePayment] = useState(false)
  const data = { togglePayment, setTogglePayment }

  return (
    <MainContext.Provider value={data}>
      <div className='basketPage'>
        <BannerSlider content={"SƏBƏTİM"} />
        <BasketTable /> 
      </div>
    </MainContext.Provider>
  )
}

export default Basket