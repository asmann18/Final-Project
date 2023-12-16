import React, { useEffect, useState } from 'react'
import Header from '../../../layout/site/Header/Header'
import Footer from '../../../layout/site/Footer/Footer'
import { Outlet } from 'react-router-dom'
import axios from 'axios'
const SiteRoot = () => {
  const [tokenData, setTokenData] = useState(localStorage.getItem("tokenData"));

  useEffect(() => {
    const storedTokenData = localStorage.getItem("tokenData");
    if (storedTokenData) {
      axios.defaults.headers.common['Authorization'] = "Bearer " + JSON.parse(storedTokenData).token;
      setTokenData(storedTokenData);
    }else{
      axios.defaults.headers.common['Authorization'] = "";

    }
  }, [tokenData]);
  return (
   <>

   <Header/>
   <Outlet/>
   <Footer/>
   </>
  )
}

export default SiteRoot