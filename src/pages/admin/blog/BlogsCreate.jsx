import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

const BlogsCreate = () => {

    const [name,setName]=useState("")
    const [description,setDescription]=useState("")
    const [blogImagesF,setBlogImagesF]=useState([])
    const[blogCategoryId,setBlogCategoryId]=useState(0)
    const[categories,setCategories]=useState([])

    const url='https://localhost:7066/api/Blogs/CreateBlog'
    const history=useNavigate()

    useEffect(()=>{
        axios.get('https://localhost:7066/api/BlogCategories/GetAllBlogCategories').then(res=>{
            setCategories(res.data.data)
        }).catch=(e)=>{
            console.log(e)
        }
    },[])

const BlogCreate=async (e)=>{
    e.preventDefault()
    try{
        
      const formData = new FormData();
      formData.append("name", name);
      formData.append("description", description);
      formData.append("blogCategoryId",blogCategoryId)
      blogImagesF.forEach((file) => {
        formData.append(`blogimagesf`, file, file.name);
      });
      const response=await axios.post(url,formData)
      history(-1)

    }catch(e){
        console.log(e)
    }
}

  return (
    <div className="AdminPanelForm">
    <h2>Create new Blog</h2>
    <form action='post' encType='multipart/form-data' className='blogCreate adminCreate'>

      <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />
      <input type="text" id='description' value={description} onChange={(e) => { setDescription(e.target.value) }} placeholder='Açıqlama daxil edin' />
      <select name="BlogCategoryId" id="categoryId" value={blogCategoryId} onChange={(e) => setBlogCategoryId(e.target.value)}>
        <option value="">Kategoriya seçin</option>
        {categories.map((category, i) => {
          return <option key={i} value={category.id}>{category.name}</option>
        })}
      </select>

      


      <input type="file" multiple id='blogImagesF' onChange={(e) => { setBlogImagesF(Array.from(e.target.files)) }} />


      <button onClick={BlogCreate} type='submit'>
        Create
      </button>

    </form>
  </div>
  )
}

export default BlogsCreate