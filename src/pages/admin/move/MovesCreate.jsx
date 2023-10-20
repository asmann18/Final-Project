import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'


const MovesCreate = () => {
    const [name,setName]=useState("")
    const [description,setDescription]=useState("")
    const [partImagesF,setPartImagesF]=useState([])
    const[partId,setPartId]=useState(0)
    const [parts,setParts]=useState([])
    
    useEffect(() => {
        axios.get('https://localhost:7066/api/Parts/GetAllParts').then(res => {
          setParts(res.data.data)
        }).catch(e => {
          console.log(e)
        })
      }, [])
    
      const history=useNavigate()
      const url='https://localhost:7066/api/Moves/CreateMove'
    
      const CreateMove=async (e)=>{
        e.preventDefault();
        try{
            const formData = new FormData();
            formData.append("name", name);
            formData.append("description", description);
            formData.append("partId",partId)
            partImagesF.forEach((file) => {
              formData.append(`moveimagesf`, file, file.name);
            });
            const response=await axios.post(url,formData)
            history(-1)
        }catch(e){
            console.log(e)
        }
      }



  return (
    <div className="AdminPanelForm">
    <h2>Create new Move</h2>
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


      <button onClick={CreateMove} type='submit'>
        Create
      </button>

    </form>
  </div>
  )
}

export default MovesCreate