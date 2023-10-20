import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const PartsUpdate = () => {
    const {id}=useParams()
    const [name,setName]=useState("")
    const [imageF,setImageF]=useState()
    const url='https://localhost:7066/api/Parts/UpdatePart'
    const history=useNavigate()

    useEffect(()=>{
        axios.get(`https://localhost:7066/api/Parts/GetBlogCategoryById/${id}`).then(res=>{
            setName(res.data.data.name)
        }).catch(error=>{
            console.log(error)
        })
    },[])

    const UpdatePart=async (e)=>{
        e.preventDefault()
        try{
            const formData=new FormData();
            formData.append("id",id)
            formData.append("name", name);
            formData.append("imagef", imageF)
            await axios.put(url,formData)
            history(-1)
        }catch(error){
            console.log(error)
        }
    }

  return (
    <div className="AdminPanelForm">
    <h2>Update Part</h2>
    <form action='post' encType='multipart/form-data' className='partCreate adminCreate'>

        <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />
        <input type="file" id='ImageF' onChange={(e) => { setImageF(e.target.files[0]) }} />


        <button onClick={UpdatePart} type='submit'>
            Update
        </button>

    </form>
</div>
  )
}

export default PartsUpdate