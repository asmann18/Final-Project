import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Link, useNavigate, useParams } from 'react-router-dom'
import BannerSlider from '../../../components/site/Common/BannerSlider'

const MoveDetail = () => {

    const {id}=useParams()
    const [move,setMove]=useState()
    const history=useNavigate()
    useEffect(()=>{
        axios.get(`https://localhost:7066/api/Moves/GetMoveById/${id}`).then(res=>{
            setMove(res.data.data)
        }).catch(e=>{
            console.log(e)
        })
    },[])
  return (
    <div className='moveDetail'>
        {move ? (<> <BannerSlider content={"MƏŞQ HƏRƏKƏTLƏRİ"} child={move ? move.name :""} />
        <div className="detail">
            <h2>{move.name}</h2>
            <p>{move.description}</p>
            <div className="imgs">
                {move.moveImagePaths.map((img,i)=>{
                    return <div className="img"><img src={img} alt="move" /></div>
                })}
            </div>
            <button className='btn ' onClick={()=>{
                history(-1)
            }}>Əvvələ qayıt</button>
        </div></>) :""}
       
    </div>
  )
}

export default MoveDetail