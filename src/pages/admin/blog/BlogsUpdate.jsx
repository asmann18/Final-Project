import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const BlogsUpdate = () => {
    const [name,setName]=useState("")
    const [description,setDescription]=useState("")
    const [blogImagesF,setBlogImagesF]=useState([])
    const[blogCategoryId,setBlogCategoryId]=useState(0)
    const[categories,setCategories]=useState([])

    const {id}=useParams();
    const history=useNavigate()
    const url='https://localhost:7066/api/Blogs/UpdateBlog'
    useEffect(()=>{
        axios.get(`https://localhost:7066/api/Blogs/GetBlogById/${id}`).then(res=>{
            setName(res.data.data.name)
            setDescription(res.data.data.description)
            setBlogCategoryId(res.data.data.blogCategoryId)
        }).catch(e=>{
            console.log(e)
        })
        axios.get('https://localhost:7066/api/BlogCategories/GetAllBlogCategories').then(res=>{
            setCategories(res.data.data)
        }).catch=(e)=>{
            console.log(e)
        }
    },[])

    const BlogUpdate=async (e)=>{
        e.preventDefault()
        try{
            
          const formData = new FormData();
          formData.append("id",id)
          formData.append("name", name);
          formData.append("description", description);
          formData.append("blogCategoryId",blogCategoryId)
          blogImagesF.forEach((file) => {
            formData.append(`blogimagesf`, file, file.name);
          });
          const response=await axios.put(url,formData)
          history(-1)
    
        }catch(e){
            console.log(e)
        }
    }


  return (
    <div className="AdminPanelForm">
    <h2>Update Product</h2>
    <form action='post' encType='multipart/form-data' className='productCreate adminCreate'>

      <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />
      <input type="text" id='description' value={description} onChange={(e) => { setDescription(e.target.value) }} placeholder='Açıqlama daxil edin' />
      <select name="BlogCategoryId" id="categoryId" value={blogCategoryId} onChange={(e) => setBlogCategoryId(e.target.value)}>
        <option value="">Kategoriya seçin</option>
        {categories.map((category, i) => {
          return <option key={i} value={category.id}>{category.name}</option>
        })}
      </select>

      


      <input type="file" multiple id='blogImagesF' onChange={(e) => { setBlogImagesF(Array.from(e.target.files)) }} />


      <button onClick={BlogUpdate} type='submit'>
        Update
      </button>

    </form>
  </div>
  )
}

export default BlogsUpdate