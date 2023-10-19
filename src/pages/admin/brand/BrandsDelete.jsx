import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

const BrandsDelete = () => {
    const[brand, setBrand] = useState();
    const { id } = useParams()
    const history = useNavigate()

    useEffect(() => {
        axios.get(`https://localhost:7066/api/Brands/GetBrandById/${id}`).then(res => {
            setBrand(res.data.data)
        })
    }, [])

    const DeleteBrand=async (e)=>{
        e.preventDefault();
        try{
            const response=await axios.delete(`https://localhost:7066/api/Brands/DeleteBrand/${id}`)
            history(-1)
        }catch(e){
            console.log(e)
        }
    }


    return (
        <div className='adminPanelDelete productDelete'>
            <h2>Brand Delete</h2>
            {brand ? (<div className="brand">
                <div className="info">
                    <div className="img">
                        <img src={brand.image.path} alt="brandImage" />
                    </div>
                    <p>{brand.name}</p>
                    <span>{brand.description}</span>
                </div>
                <div className="action">
                    <p>Bu brandı silmək istəyirsiniz?</p>
                    <div className="buttons">
                        <button onClick={DeleteBrand} className='btn btn-danger'>Delete</button>
                        <button onClick={() => history(-1)} className='btn btn-primary'>Back</button>
                    </div>
                </div>
            </div>) : ""}

        </div>
    )
}

export default BrandsDelete