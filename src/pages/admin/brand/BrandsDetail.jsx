import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

const BrandsDetail = () => {
    const[brand, setBrand] = useState();
    const { id } = useParams()
    const history = useNavigate()

    useEffect(() => {
        axios.get(`https://localhost:7066/api/Brands/GetBrandById/${id}`).then(res => {
            setBrand(res.data.data)
        })
    }, [id])
  return (
    <div className='adminPanelDetail productDetail'>{brand ? (<div className="brand">
    <div className="info">
        <div className="img">
            <img src={brand.image.path} alt="brandImage" />
        </div>
        <p>{brand.name}</p>
        <span>{brand.description}</span>
    </div>
   
        <div className="button">
            <button onClick={() => history(-1)} className='btn btn-primary'>Back</button>
        </div>
   
</div>) : ""}</div>
  )
}

export default BrandsDetail