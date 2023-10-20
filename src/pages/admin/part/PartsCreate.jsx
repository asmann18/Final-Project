import axios from 'axios'
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'

const PartsCreate = () => {
    const [name,setName]=useState("")
    const[imageF,setImageF]=useState()
    const url='https://localhost:7066/api/Parts/CreatePart'
    const history=useNavigate()
    const CreatePart=async (e)=>{
        e.preventDefault()
        try{
            const formData=new FormData();
            formData.append("name", name);
            formData.append("imagef", imageF)
            await axios.post(url,formData)
            history(-1)
        }catch(error){
            console.log(error)
        }
    }
  return (
    <div className="AdminPanelForm">
    <h2>Create new Part</h2>
    <form action='post' encType='multipart/form-data' className='partCreate adminCreate'>

        <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />
        <input type="file" id='ImageF' onChange={(e) => { setImageF(e.target.files[0]) }} />


        <button onClick={CreatePart} type='submit'>
            Create
        </button>

    </form>
</div>
  )
}

export default PartsCreate