import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const BlogCategoriesUpdate = () => {
    const {id}=useParams()
    const [name,setName]=useState("")
    const history=useNavigate()
    const url=`https://localhost:7066/api/BlogCategories/UpdateBlogCategory`

    
useEffect(()=>{
    axios.get(`https://localhost:7066/api/BlogCategories/GetBlogCategoryById/${id}`).then(res=>{
        setName(res.data.data.name)

    }).catch=(err)=>{
        console.log(err)
    }
},[])

const UpdateCagetogory=async (e)=>{
    e.preventDefault()
    try{
       await axios.put(url,{id,name})
       history(-1)
    }catch(e){
        console.log(e)
    }
}


  return (
    <div className="AdminPanelForm">
    <h2>Update Blog Category</h2>
    <form action='post'  className='BlogCategoryUpdate adminCreate'>

        <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />


        <button onClick={UpdateCagetogory} type='submit'>
            Update
        </button>

    </form>
</div>
  )
}

export default BlogCategoriesUpdate