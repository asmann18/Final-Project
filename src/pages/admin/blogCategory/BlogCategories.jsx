import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import AdminPanelTable from '../../../components/Common/AdminPanelTable'

const BlogCategories = () => {
  const [categories, setCategories] = useState([])
  useEffect(() => {
    axios.get('https://localhost:7066/api/BlogCategories/GetAllBlogCategories').then(res => {
      setCategories(res.data.data)
    }).catch(e => {
      console.log(e)
    })
  }, [])
  
  let rows=[]
  const columns= [
    { id: "id", label: "Id", minWidth: 20,maxWidth:200 },
    { id: "name", label: "Name", minWidth: 20,maxWidth:200 },
    { id: "buttons", label: "Actions", minWidth: 20,maxWidth:200 },
];
categories.map((Category)=>{
  rows.push({id:Category.id,name:Category.name,buttons:{update:`/admin/blogCategories/update/${Category.id}`,delete:`/admin/blogCategories/delete/${Category.id}`}})
})
  return (
    <div className='blogCategories adminList'>
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

export default BlogCategories