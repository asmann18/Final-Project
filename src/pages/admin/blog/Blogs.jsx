import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import AdminPanelTable from '../../../components/Common/AdminPanelTable'

const Blogs = () => {

const [blogs,setBlogs]=useState([])
useEffect(()=>{
  axios.get('https://localhost:7066/api/Blogs/GetAllBlog').then(res=>{
    setBlogs(res.data.data)
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
  blogs.map((blog)=>{
    rows.push({id:blog.id,image:blog.blogImagePaths[0],name:blog.name,buttons:{detail:`/admin/blogs/${blog.id}`,update:`/admin/blogs/update/${blog.id}`,delete:`/admin/blogs/delete/${blog.id}`}})
  })


  return (
    <div className='Brands adminList'>
    <div className="listInfo">
    <h2>Blogs</h2>
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

export default Blogs