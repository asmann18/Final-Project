import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const AromasDelete = () => {

    const {id}=useParams();
    const [aroma,setAroma]=useState();
    const history=useNavigate()
    useEffect(() => {
        axios.get(`https://localhost:7066/api/Aromas/GetAromaById/${id}`).then(res => {
            setAroma(res.data.data.name)
        }).catch = (e) => {
            console.log(e)
        }
    }, [])


    const DeleteAroma=async (e)=>{
        e.preventDefault();
        try{
            await axios.delete(`https://localhost:7066/api/Aromas/DeleteAroma/${id}`)
            history(-1)
        }catch(e){
            console.log(e)
        }
    }
  return (
    <div className='adminPanelDelete aromaDelete'>
    <h2>Aroma Delete</h2>
    {aroma ? (<div className="aroma">
        <div className="info">
           
            <p>{aroma.name}</p>
        </div>
        <div className="action">
            <p>Bu aromanı silmək istəyirsiniz?</p>
            <div className="buttons">
                <button onClick={DeleteAroma} className='btn btn-danger'>Delete</button>
                <button onClick={() => history(-1)} className='btn btn-primary'>Back</button>
            </div>
        </div>
    </div>) : ""}

</div>
  )
}

export default AromasDelete