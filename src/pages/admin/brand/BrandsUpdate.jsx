import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const BrandsUpdate = () => {
const {id}=useParams()
const [name,setName]=useState("")
const [description,setDescription]=useState("")
const [imageF,setImageF]=useState()
const history=useNavigate()

const url='https://localhost:7066/api/Brands/UpdateBrand'

useEffect(()=>{
    axios.get(`https://localhost:7066/api/Brands/GetBrandById/${id}`).then(res=>{
        console.log(res.data)
        setName(res.data.data.name)
        setDescription(res.data.data.description)
    })
},[])


const updateBrand = async (e) => {
    e.preventDefault();
    try {
        const formData = new FormData();
        formData.append("id",id)
        formData.append("name", name);
        formData.append("description", description)
        formData.append("imagef", imageF)
        const response = await axios.put(url, formData)
        history(-1)
    } catch (e) {
        console.log(e)
    }
}


  return (
    <div className="AdminPanelForm">
            <h2>Create new Brand</h2>
            <form action='post' encType='multipart/form-data' className='brandCreate adminCreate'>

                <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />
                <input type="text" id='description' value={description} onChange={(e) => { setDescription(e.target.value) }} placeholder='Açıqlama daxil edin' />
                <input type="file" id='ImageF' onChange={(e) => { setImageF(e.target.files[0]) }} />

                <button onClick={updateBrand} type='submit'>
                    Update
                </button>

            </form>
        </div>
  )
}

export default BrandsUpdate