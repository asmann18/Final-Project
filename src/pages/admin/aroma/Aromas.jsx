import axios from 'axios'
import React, { useEffect, useState } from 'react'
import AdminPanelTable from '../../../components/Common/AdminPanelTable'
import { Link } from 'react-router-dom'
const Aromas = () => {
  const [aromas,setAromas]=useState([])
  useEffect(()=>{
axios.get('https://localhost:7066/api/Aromas/GetAllAromas').then(res=>{
  setAromas(res.data.data)
}).catch(e=>{
  console.log(e)
})
  },[])

let rows=[]
const columns= [
  { id: "id", label: "Id", minWidth: 20,maxWidth:200 },
  { id: "name", label: "Name", minWidth: 20,maxWidth:200 },
  { id: "buttons", label: "Actions", minWidth: 20,maxWidth:200 },
];

aromas.map((aroma)=>{
  rows.push({id:aroma.id,name:aroma.name,buttons:{update:`/admin/aromas/update/${aroma.id}`,delete:`/admin/aromas/delete/${aroma.id}`}})
})

  return (
    <div className='aromas adminList'>
    <div className="listInfo">
    <h2>Aromas</h2>
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

export default Aromas