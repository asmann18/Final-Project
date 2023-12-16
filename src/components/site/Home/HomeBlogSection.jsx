import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import axios from 'axios'

const HomeBlogSection = () => {
    const [blogs, SetBlogs] = useState([])
    useEffect(() => {
        axios.get("https://localhost:7066/api/Blogs/GetAllBlog").then(res => {
            SetBlogs(res.data.data)
        })
    }, [])
    return (
        <div className='blogSection bgRed'>
            <div className="txt"><h2>Bloqlar</h2></div>
            <div className="blogs">{blogs.slice(0, 5).map((blog, index) => {
                return (
                    <Link to={`/blog/${blog.id}`} key={index} className="blog">
                        <div className="image">
                            <img src={blog.blogImagePaths[0]} alt="" />
                        </div>
                        <div className="info">
                            <p className="blogName">{blog.name}</p>
                            <span className="blogDescription">{blog.blogCategory.name}</span>
                        </div>
                    </Link>
                );
            })} 

            </div>
            <div className="button">
                <button><Link to={"/blog"}>Read More</Link></button>
            </div>
        </div>

    )
}

export default HomeBlogSection