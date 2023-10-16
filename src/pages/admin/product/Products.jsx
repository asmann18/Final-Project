import axios from 'axios'
import React, { useEffect, useState } from 'react'

const Products = () => {
    const [products, setProducts] = useState([])
    useEffect(()=>{
        axios.get('https://localhost:7066/api/Products/GetAllProducts').then(res=>{
            setProducts(res.data.data)
        })
    },[])
  return (
    <div className='products adminList'>
        <h2>Products</h2>
        <ul className='list'>
            {products.map((product,i)=>{
                return (<div key={i}>
                    {product.name}
                </div>)
            })}
        </ul>
    </div>
  )
}

export default Products