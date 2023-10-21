import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import Error from '../../error/Error'
import axios from 'axios'

const MovesDetail = () => {

    const [move,setMove]=useState()
    const {id}=useParams()
    const history=useNavigate()
    
useEffect(()=>{

    axios.get(`https://localhost:7066/api/Moves/GetMoveById/${id}`).then(res=>{
        setMove(res.data.data)
    }).catch(e=>{
        console.log(e)
    })
},[])


  return (
    <div className='adminPanelDetail productDetail'>
    <h2>move Detail</h2>
    {move ? (<div className="move">
      <div className="info">
        <div className="img">
          <img src={move.moveImagePaths[0]} alt="moveImage" />
        </div>
        <p>{move.name}</p>
        <span>{move.description}</span>
        <p>Part:{move.part.name}</p>
      </div>
      <div className="action">
      
        <div className="buttons">
          <button onClick={() => history(-1)} className='btn btn-primary'>Back</button>
        </div>
      </div>
    </div>) : <Error/>}

  </div>
  )
}

export default MovesDetail