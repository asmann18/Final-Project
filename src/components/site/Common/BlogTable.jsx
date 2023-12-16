import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import Icon from '@mui/icons-material/Book';
import NotFound from './NotFound';
const BlogTable = () => {
    const [categories, setCategories] = useState([])
    const [blogs, setBlogs] = useState([])
    const [active, setActive] = useState(1)


    useEffect(() => {
        axios.get('https://localhost:7066/api/BlogCategories/GetAllBlogCategories').then(res => {
            setCategories(res.data.data)
            axios.get(`https://localhost:7066/api/BlogCategories/GetAllBlogByCategoryId/${res.data.data[0].id}`).then(response => {
                setBlogs(response.data.data)
                // setActive(response.data.data[0].id)

            })
        }).catch(e => {
            console.log(e)
        })
    }, [])

    const SwitchBlogs = async (e, id) => {
        e.preventDefault();
        try {
            const response = await axios.get(`https://localhost:7066/api/BlogCategories/GetAllBlogByCategoryId/${id}`)
            setBlogs(response.data.data)
            setActive(id)
        }
        catch (err) {
            console.log(err)
        }
    }
    return (

      
        <div className='siteTable'>
            <ul onLoad={(e) => { SwitchBlogs(e, active) }} className="columns">
                {categories.map((category, i) => {
                    return <li className={category.id === active ? "active" : ""} onClick={(e) => SwitchBlogs(e, category.id)} key={i}>
                        <p>{category.name}</p>
                    </li>
                })}
            </ul>
            <ul className="rows">

                {blogs.length>0 ?   blogs.map((blog, i) => {
                    return <Link to={`${blog.id}`} key={i}>
                       <Icon/>
                        <p>{blog.name}</p>
                    </Link>
                }) : <NotFound/>}
            </ul>
         

        </div>
    )
}

export default BlogTable