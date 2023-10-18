import React, { useEffect, useState } from 'react'
import ProductImage from '../../../assets/images/1973238.jpg'
import axios from 'axios'
import { Link } from 'react-router-dom'

const HomeSection4 = () => {
    const [products,setProducts]=useState([])

    useEffect(() => {  
    axios.get("https://localhost:7066/api/Products/GetDiscountProducts").then(res=>{
        setProducts(res.data.data);
    })},[])
  return (
    <div className='newProducts bgRed'>
         <div className="txt">
                <h2>Endirimli məhsullar</h2>
                <p>Daim yenilənən endirimlərdən sən də yararlan</p>
            </div>
            <div className="products">
                {products.map((product,i)=>{
                    return( <Link to={"productDetail/"+(product.id)} key={i} className="product">
                    <div className="image">
                    <img  src={product.productImagePaths[0]} alt="" />
                    </div>
                    <div className="productInfo">

                        <p>{product.name}</p>
                        <span>{product.price}$</span>
                    </div>
                </Link>)
                })}
               
          </div>
     
    </div>
  )
}

export default HomeSection4