import React, { useEffect, useState } from 'react'

const Dashboard = () => {

const [tokenData,setTokenData]=useState([])


useEffect(()=>{
setTokenData(JSON.parse(localStorage.getItem("tokenData")));
console.log(tokenData)
},[])

  return (
    <div>Dashboard</div>
  )
}

export default Dashboard