import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import Error from '../../error/Error'

const BlogsDetail = () => {
    const { id } = useParams()
    const [blog, setBlog] = useState()
    const history=useNavigate()
    useEffect(() => {
        axios.get(`https://localhost:7066/api/Blogs/GetBlogById/${id}`).then(res => {
            setBlog(res.data.data)
        }).catch(e => {
            console.log(e)
        })
    }, [])


  return (
    <div className='adminPanelDetail productDetail'>
    <h2>Blog Detail</h2>
    {blog ? (<div className="blog">
      <div className="info">
        <div className="img">
          <img src={blog.blogImagePaths[0]} alt="blogImage" />
        </div>
        <p>{blog.name}</p>
        <span>{blog.description}</span>
        <p>Category:{blog.blogCategory.name}</p>
      </div>
      <div className="action">
      
        <div className="buttons">
          <button onClick={() => history(-1)} className='btn btn-primary'>Back</button>
        </div>
      </div>
    </div>) : <Error/>}

  </div>
  )
}

export default BlogsDetail