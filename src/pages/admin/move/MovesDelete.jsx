import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import Error from '../../error/Error'

const MovesDelete = () => {
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

const DeleteMove=async (e)=>{
    e.preventDefault()
    try{
        axios.delete(`https://localhost:7066/api/Moves/DeleteMove/${id}`)
        history(-1)
    }
    catch(e){
        console.log(e)
    }
}


  return (
    <div className='adminPanelDelete blogDelete'>
        <h2>Blog Delete</h2>
        {move ? (<div className="blog">
          <div className="info">
            <div className="img">
              <img src={move.moveImagePaths[0]} alt="moveImage" />
            </div>
            <p>{move.name}</p>
            <span>{move.description}</span>
          </div>
          <div className="action">
            <p>Bu move-u silmək istəyirsiniz?</p>
            <div className="buttons">
              <button onClick={DeleteMove}  className='btn btn-danger'>Delete</button>
              <button onClick={() => history(-1)} className='btn btn-primary'>Back</button>
            </div>
          </div>
        </div>) : <Error/>}
  
      </div>
  )
}

export default MovesDelete