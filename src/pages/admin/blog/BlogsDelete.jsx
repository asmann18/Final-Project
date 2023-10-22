import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import Error from '../../error/Error'

const BlogsDelete = () => {
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


    const DeleteBlog=async (e)=>{
        e.preventDefault();
        try{
            const response=await axios.delete(`https://localhost:7066/api/Blogs/DeleteBlog/${id}`)
            history(-1)
        }catch(e){
            console.log(e)
        }
    }
    return (
        <div className='adminPanelDelete blogDelete'>
        <h2>Blog Delete</h2>
        {blog ? (<div className="blog">
          <div className="info">
            <div className="img">
              <img src={blog.blogImagePaths[0]} alt="blogImage" />
            </div>
            <p>{blog.name}</p>
            <span>{blog.description}</span>
          </div>
          <div className="action">
            <p>Bu məhsulu silmək istəyirsiniz?</p>
            <div className="buttons">
              <button onClick={DeleteBlog}  className='btn btn-danger'>Delete</button>
              <button onClick={() => history(-1)} className='btn btn-primary'>Back</button>
            </div>
          </div>
        </div>) : <Error/>}
  
      </div>
    )
}

export default BlogsDelete