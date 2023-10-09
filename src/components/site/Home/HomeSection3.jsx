import React, { useEffect, useState } from 'react'
import ProductImage from '../../../assets/images/1061961.jpg'
import axios from 'axios'

const HomeSection3 = () => {
    const [newProducts,setNewProducts]=useState([])
    useEffect(()=>{
        axios.get("https://localhost:7066/api/Products/GetPopularProducts").then(res=>{
            setNewProducts(res.data.data)
        })
    },[])
    return (
        <div className='newProducts'>
            <div className="txt">
                <h2>Ən yeni məhsullar</h2>
                <p>Mağazalarımıza yeni gətirilmiş orijinal idman qidaları</p>
            </div>
            <div className="products">
                {newProducts.map((product,i)=>{
                    return ( <div key={i} className="product">
                    <img src={product.productImagePaths[0]} alt="product" />
                    <div className="productInfo">

                        <p>{product.name}</p>
                        <span>{product.price}$</span>
                    </div>
                </div>)
                })}
               
            </div>

        </div>
    )
}

export default HomeSection3