import React from 'react'
import BannerSlider from '../../../components/site/Common/BannerSlider'
import OrderTable from '../../../components/site/Common/OrderTable'
import '../../../assets/styles/site/Order.scss'
const Orders = () => {
  return (
    <div className='ordersPage'>
      <BannerSlider content={"SİFARİŞLƏRİM"}/>
      <OrderTable/>
    </div>
  )
}

export default Orders