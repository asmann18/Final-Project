import React, { useEffect, useState } from 'react'
import ProductImage from '../../../assets/images/1061961.jpg'
import axios from 'axios'
import { Link } from 'react-router-dom'
const HomeSection5 = () => {
    const [popProducts, setPopProducts] = useState([])
    useEffect(() => {
        axios.get("https://localhost:7066/api/Products/GetBestSellerProducts").then(res => {
            setPopProducts(res.data.data)
        })
    }, [])
    return (
        <div className='newProducts'>
            <div className="txt">
                <h2>ƏN ÇOX SATILANLAR</h2>
                <p>Alıcılarımız tərəfindən ən çox alınan məhsullar</p>
            </div>
            <div className="products">
                {popProducts.map((product, i) => {
                    return (<Link to={"productDetail/"+(product.id)} key={i} className="product">
                        <div className="image">

                            <img src={product.productImagePaths[0]} alt="" />
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

export default HomeSection5