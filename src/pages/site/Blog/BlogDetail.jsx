import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import BannerSlider from '../../../components/site/Common/BannerSlider'

const BlogDetail = () => {

const {id}=useParams()
const[blog,setBlog]=useState()
const history=useNavigate()

useEffect(()=>{
    axios.get(`https://localhost:7066/api/Blogs/GetBlogById/${id}`).then(res=>{
        setBlog(res.data.data)
    }).catch(e=>{
        console.log(e)
    })
},[])

  return (
    <div className='moveDetail'>
    {blog ? (<> <BannerSlider content={"Blog"} child={blog ? blog.name :""} />
    <div className="detail">
        <h2>{blog.name}</h2>
        <p>{blog.description}</p>
        <div className="imgs">
            {blog.blogImagePaths.map((img,i)=>{
                return <div className="img"><img src={img} alt="blog" /></div>
            })}
        </div>
        <button className='btn ' onClick={()=>{
            history(-1)
        }}>Əvvələ qayıt</button>
    </div></>) :""}
   
</div>
  )
}

export default BlogDetail