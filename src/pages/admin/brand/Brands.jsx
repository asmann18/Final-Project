import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import AdminPanelTable from '../../../components/Common/AdminPanelTable'
const Brands = () => {
  const [brands,setBrands]=useState([])
  useEffect(()=>{
    axios.get('https://localhost:7066/api/Brands/GetAllBrands').then(res=>{
      setBrands(res.data.data)
    }).catch=(e)=>{
      console.log(e)
    }

  },[])
  let rows=[]
  const columns=[
    { id: "id", label: "Id", minWidth: 20,maxWidth:200 },
    {id:"image", label:"Image", minWidth:20, maxWidth:200  },
    { id: "name", label: "Name", minWidth: 20,maxWidth:200 },
    { id: "buttons", label: "Actions", minWidth: 20,maxWidth:200 },
  ]
  
  brands.map((brand)=>{
    rows.push({id:brand.id,image:brand.image.path,name:brand.name,buttons:{detail:`/admin/brands/${brand.id}`,update:`/admin/brands/update/${brand.id}`,delete:`/admin/brands/delete/${brand.id}`}})
  })

  return (
    <div className='Brands adminList'>
    <div className="listInfo">
    <h2>Brands</h2>
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

export default Brands