import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const PartsDelete = () => {
    const {id}=useParams()
    const [part,setPart]=useState()
    const history=useNavigate()

    useEffect(()=>{
        axios.get(`https://localhost:7066/api/Parts/GetBlogCategoryById/${id}`).then(res=>{
            setPart(res.data.data)
        
        }).catch(error=>{
            console.log(error)
        })
    },[])

    const DeletePart=async (e)=>{
        e.preventDefault();
        try{
            await axios.delete(`https://localhost:7066/api/Parts/DeletePart/${id}`)
            history(-1);
        }catch(e){
            console.log(e)
        }
    }
  return (
    <div className='adminPanelDelete productDelete'>
            <h2>Brand Delete</h2>
            {part ? (<div className="part">
                <div className="info">
                    <div className="img">
                        <img src={part.image.path} alt="partImage" />
                    </div>
                    <p>{part.name}</p>
                </div>
                <div className="action">
                    <p>Bu partı silmək istəyirsiniz?</p>
                    <div className="buttons">
                        <button onClick={DeletePart} className='btn btn-danger'>Delete</button>
                        <button onClick={() => history(-1)} className='btn btn-primary'>Back</button>
                    </div>
                </div>
            </div>) : ""}

        </div>
  )
}

export default PartsDelete