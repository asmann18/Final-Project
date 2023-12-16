import React, { useEffect, useState } from 'react'
import logo from '../../../assets/images/logo_red.png'
const Dashboard = () => {

const [tokenData,setTokenData]=useState([])


useEffect(()=>{
setTokenData(JSON.parse(localStorage.getItem("tokenData")));
},[])

  return (
    <section className='dashboardAdmin'>
    <div>Welcome to Atlet.az Admin Panel</div>
    <img src={logo} alt="" />
    </section>
  )
}

export default Dashboard