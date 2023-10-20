import axios from 'axios';
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';

const AromasCreate = () => {
    const url='https://localhost:7066/api/Aromas/CreateAroma';
    const [name,setName]=useState("")
    const history=useNavigate()
    const CreateAroma=async (e)=>{
        e.preventDefault();
        try{
            const response=await axios.post(url,{name})
            history(-1)

        }
        catch(e){
            console.log(e)
        }
    }
  return (
    <div className="AdminPanelForm">
    <h2>Create new Aroma</h2>
    <form action='post'  className='aromaCreate adminCreate'>

        <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />


        <button onClick={CreateAroma} type='submit'>
            Create
        </button>

    </form>
</div>
  )
}

export default AromasCreate