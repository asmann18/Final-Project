import React from 'react'
import BannerSlider from '../../../components/site/Common/BannerSlider'
import BasketTable from '../../../components/site/Common/BasketTable'
import '../../.././/assets/styles/site/Basket.scss'
const Basket = () => {
  return (
    <div className='basketPage'>
        <BannerSlider content={"SƏBƏTİM"} />
        <BasketTable/>
    </div>
  )
}

export default Basket