import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const PartsDetail = () => {
    const [part,setPart]=useState()
    const {id}=useParams()
    const history=useNavigate()
    useEffect(()=>{
        axios.get(`https://localhost:7066/api/Parts/GetBlogCategoryById/${id}`).then(res=>{
            setPart(res.data.data)
        }).catch(error=>{
            console.log(error)
        })
    },[id])

  return (
    <div className='adminPanelDetail productDetail'>{part ? (<div className="part">
    <div className="info">
        <div className="img">
            <img src={part.image.path} alt="partImage" />
        </div>
        <p>{part.name}</p>
    </div>
   
        <div className="button">
            <button onClick={() => history(-1)} className='btn btn-primary'>Back</button>
        </div>
   
</div>) : ""}</div>
  )
}

export default PartsDetail