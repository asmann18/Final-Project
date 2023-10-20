import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const MovesUpdate = () => {

    const [name,setName]=useState("")
    const [description,setDescription]=useState("")
    const [partImagesF,setPartImagesF]=useState([])
    const[partId,setPartId]=useState(0)
    const [parts,setParts]=useState([])
    

    const history=useNavigate()
    const url='https://localhost:7066/api/Moves/UpdateMove'
    const {id}=useParams()

    useEffect(()=>{
        axios.get(`https://localhost:7066/api/Moves/GetMoveById/${id}`).then(res=>{
            setName(res.data.data.name)
            setDescription(res.data.data.description)
            setPartId(res.data.data.part.id)
        }).catch(e=>{
            console.log(e)
        })


        axios.get('https://localhost:7066/api/Parts/GetAllParts').then(res => {
            setParts(res.data.data)
          }).catch(e => {
            console.log(e)
          })
        
    },[])


    const UpdateMove=async (e)=>{
        e.preventDefault()
        try{
            const formData = new FormData();
            formData.append("id",id);
            formData.append("name", name);
            formData.append("description", description);
            formData.append("partId",partId)
            partImagesF.forEach((file) => {
              formData.append(`moveimagesf`, file, file.name);
            });
            const response=await axios.put(url,formData)
            console.log(response)
            history(-1)

        }catch(e){
            console.log(e)
        }
    }
  return (
    <div className="AdminPanelForm">
    <h2>Update Move</h2>
    <form action='post' encType='multipart/form-data' className='moveCreate adminCreate'>

      <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />
      <input type="text" id='description' value={description} onChange={(e) => { setDescription(e.target.value) }} placeholder='Açıqlama daxil edin' />
      <select name="PartId" id="partId" value={partId} onChange={(e) => setPartId(e.target.value)}>
        <option value="">Part seçin</option>
        {parts.map((part, i) => {
          return <option key={i} value={part.id}>{part.name}</option>
        })}
      </select>

      


      <input type="file" multiple id='partImagesF' onChange={(e) => { setPartImagesF(Array.from(e.target.files)) }} />


      <button onClick={UpdateMove} type='submit'>
        Update
      </button>

    </form>
  </div>
  )
}

export default MovesUpdate