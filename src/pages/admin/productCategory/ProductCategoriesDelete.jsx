import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import Error from '../../error/Error';
import axios, { Axios } from 'axios';

const ProductCategoriesDelete = () => {
    const {id}=useParams()
    const history=useNavigate()
    const [category,setCategory]=useState();
    const url=`https://localhost:7066/api/ProductCategories/DeleteProductCategoryById`;
    useEffect(()=>{
        axios.get(`https://localhost:7066/api/ProductCategories/GetProductCategoryById/${id}`).then(res=>{
            setCategory(res.data.data)
         
    
        }).catch=(err)=>{
            console.log(err)
        }
    },[])
const DeleteCategory=async (e)=>{
    e.preventDefault();
    try{
     await axios.delete(url+`/${id}`)
        history(-1);
    }catch(e){
        console.log(e)
    }
}

  return (
    <div className='adminPanelDelete productCategoryDelete'>
    <h2>Category Delete</h2>
    {category ? (   <div className="category">
      <div className="info">
         
          <p>{category.name}</p>
          <span>{category.description}</span>
      </div>
      <div className="action">
        <p>Bu kategoriyani silmək istəyirsiniz?</p>
        <div className="buttons">
          <button onClick={DeleteCategory} className='btn btn-danger'>Delete</button>
          <button onClick={()=>history(-1)} className='btn btn-primary'>Back</button>
        </div>
      </div>
    </div>) :<Error/>}
 
  </div>
  )
}

export default ProductCategoriesDelete