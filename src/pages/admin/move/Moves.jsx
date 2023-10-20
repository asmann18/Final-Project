import axios from 'axios'
import React, { useEffect, useState } from 'react'
import AdminPanelTable from '../../../components/Common/AdminPanelTable'
import { Link } from 'react-router-dom'



const Moves = () => {
  const [moves,setMoves]=useState([])
  useEffect(()=>{
    axios.get('https://localhost:7066/api/Moves/GetAllMoves').then(res=>{
      setMoves(res.data.data)
    }).catch(e=>{
      console.log(e)
    })
  },[])
  
  let rows=[]
    const columns=[
      { id: "id", label: "Id", minWidth: 20,maxWidth:200 },
      {id:"image", label:"Image", minWidth:20, maxWidth:200  },
      { id: "name", label: "Name", minWidth: 20,maxWidth:200 },
      { id: "buttons", label: "Actions", minWidth: 20,maxWidth:200 },
    ]
    moves.map((move)=>{
      rows.push({id:move.id,image:move.moveImagePaths[0],name:move.name,buttons:{detail:`/admin/moves/${move.id}`,update:`/admin/moves/update/${move.id}`,delete:`/admin/moves/delete/${move.id}`}})
    })
  



  return (
    <div className='Moves adminList'>
    <div className="listInfo">
    <h2>Moves</h2>
    <div className="add">
        <Link className='btn btn-success' to={"create"}>Create</Link>
    </div>
    </div>
    <ul className='list'>
        <AdminPanelTable Rows={rows} Columns={columns} />
    </ul>
 
</div>
  )
}

export default Moves