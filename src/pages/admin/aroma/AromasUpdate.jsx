import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
const AromasUpdate = () => {


    const { id } = useParams()
    const [name, setName] = useState("")
    const history = useNavigate()
    const url='https://localhost:7066/api/Aromas/UpdateAroma'
    useEffect(() => {
        axios.get(`https://localhost:7066/api/Aromas/GetAromaById/${id}`).then(res => {
            setName(res.data.data.name)
        }).catch = (e) => {
            console.log(e)
        }
    }, [])
    const UpdateAroma=async (e)=>{
        e.preventDefault()
        try{
            axios.put(url,{id,name})
            history(-1)
        }catch(e){
            console.log(e)
        }
    }
    return (
        <div className="AdminPanelForm">
            <h2>Update Aroma</h2>
            <form action='post' className='aromaCreate adminCreate'>

                <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />


                <button onClick={UpdateAroma} type='submit'>
                    Update
                </button>

            </form>
        </div>
    )
}

export default AromasUpdate