import axios from 'axios'
import React, { useEffect, useState } from 'react'

const SiteFooterCategories = () => {
  const [categories,setCategories]=useState([])

  useEffect(() => {  
axios.get("https://localhost:7066/api/ProductCategories/GetAllProductCategories").then(res=>{
      setCategories(res.data.data);
  })},[])
  return (
    <div className='' >
    <h3>Məhsullar</h3>
    <ul>
      {
        categories.map((category,index)=>{
          return <li key={index}>
            {category.name}
          </li>
        })
      }
   
    </ul>
    </div>
  )
}

export default SiteFooterCategories