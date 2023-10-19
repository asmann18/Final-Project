import axios from 'axios'
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'

const BrandsCreate = () => {
    const [name, setName] = useState("")
    const [description, setDescription] = useState("")
    const [imageF, setImageF] = useState()
    const url = 'https://localhost:7066/api/Brands/CreateBrand';
    const history = useNavigate();
    const createBrand = async (e) => {
        e.preventDefault();
        try {
            const formData = new FormData();
            formData.append("name", name);
            formData.append("description", description)
            formData.append("imagef", imageF)
            const response = await axios.post(url, formData)
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


                <button onClick={createBrand} type='submit'>
                    Create
                </button>

            </form>
        </div>
    )
}

export default BrandsCreate