import axios from 'axios'
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'

const BlogsCategoriesCreate = () => {
const [name,setName]=useState("")
const url='https://localhost:7066/api/BlogCategories/CreateBlogCategory'
const history=useNavigate()
const CreateCategory= async (e)=>{
    e.preventDefault()
    try{
       await axios.post(url,{name})
            history(-1)
        
    }
    catch(e){
        console.log(e)
    }
}



  return (
    <div className="AdminPanelForm">
    <h2>Create new Blog Category</h2>
    <form action='post'  className='BlogCategoryCreate adminCreate'>

        <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />


        <button onClick={CreateCategory} type='submit'>
            Create
        </button>

    </form>
</div>
  )
}

export default BlogsCategoriesCreate