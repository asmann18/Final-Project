import { Category } from '@mui/icons-material'
import axios from 'axios'
import React, { useEffect, useState } from 'react'
import AdminPanelTable from '../../../components/Common/AdminPanelTable'
import { Link } from 'react-router-dom'
const ProductCategories = () => {
  const [categories,setCategories]=useState([])
  useEffect(()=>{
    axios.get('https://localhost:7066/api/ProductCategories/GetAllProductCategories').then(res=>{
setCategories(res.data.data)
    }).catch((e)=>{
      console.log(e)
    })
  },[])
  let rows=[]
  const columns= [
    { id: "id", label: "Id", minWidth: 20,maxWidth:200 },
    { id: "name", label: "Name", minWidth: 20,maxWidth:200 },
    { id: "buttons", label: "Actions", minWidth: 20,maxWidth:200 },
];
categories.map((Category)=>{
  rows.push({id:Category.id,name:Category.name,buttons:{detail:`/admin/productCategories/${Category.id}`,update:`/admin/productCategories/update/${Category.id}`,delete:`/admin/productCategories/delete/${Category.id}`}})
})
  return (
    <div className='productCategories adminList'>
    <div className="listInfo">
    <h2>Product Categories</h2>
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

export default ProductCategories