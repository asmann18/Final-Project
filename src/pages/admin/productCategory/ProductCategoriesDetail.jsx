import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const ProductCategoriesDetail = () => {
  const {id}=useParams()
  const history=useNavigate()
  const [category,setCategory]=useState()
  useEffect(()=>{
    axios.get(`https://localhost:7066/api/ProductCategories/GetProductCategoryById/${id}`).then(res=>{
      setCategory(res.data.data)
    }).catch=(e)=>{
      console.log(e)
    }
  },[])
  return (
    <div className='adminPanelDetail categoryDetail'>
      Product Category Detail
      {category ? <div className="category">
        <p>id:{category.id}</p>
        <p>name:{category.name}</p>
        <p>description:{category.description}</p>
      </div> :""}
        
    </div>
  )
}

export default ProductCategoriesDetail