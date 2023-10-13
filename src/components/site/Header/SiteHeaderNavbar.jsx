import React, { useEffect, useState } from 'react'
import { Link } from "react-router-dom";
import HoverMenu from '../../Common/HoverMenu';
import  '../../../assets/styles/site/layout/Header.scss'
import ArrowDropDownIcon from '@mui/icons-material/ArrowDropDown';
import axios from 'axios';
import { Category } from '@mui/icons-material';
const SiteHeaderNavbar = () => {
    const [blogCategories,setBlogCategories]=useState([]);
    const [productCategories,setProductCategories]=useState([]);
    const [parts,setParts]=useState([]);
    useEffect(()=>{
        axios.get("https://localhost:7066/api/BlogCategories/GetAllBlogCategories").then(res=>{
            setBlogCategories(res.data.data)
        })
        axios.get("https://localhost:7066/api/ProductCategories/GetAllProductCategories").then(res=>{
            setProductCategories(res.data.data)
        })
        axios.get("https://localhost:7066/api/Parts/GetAllParts").then(res=>{
            setParts(res.data.data)
        })
    },[])
    return (
        <>
            <ul className='siteHeaderNavbar '>
                <li>
                    <Link to={"/"}>
                        Əsas Səhifə
                    </Link>
                </li>
                <li  >
                    <Link to={"/shop"}>
                        Mağaza<ArrowDropDownIcon/>
                    </Link>
                    <ul className="siteHeaderNavbarInfo">
                      {productCategories.map((category,i)=>{
                        return (<li key={i}>{category.name}</li>)
                      })}
                    </ul>
                </li>
                <li>
                    <Link to={"/blog"}>
                        Blog<ArrowDropDownIcon/>
                    </Link>
                    <ul className="siteHeaderNavbarInfo">
                      {blogCategories.map((category,i)=>{
                        return (<li key={i}>{category.name}</li>)
                      })}
                    </ul>
                </li>
                <li>
                    <Link to={"/moves"}>
                        Məşq Hərəkətləri<ArrowDropDownIcon/>
                    </Link>
                    <ul className="siteHeaderNavbarInfo">
                      {parts.map((part,i)=>{
                        return (<li key={i}>{part.name}</li>)
                      })}
                    </ul>
                </li>
                <li>
                    <Link to={"contact"}>
                        Əlaqə
                    </Link>
                </li>
              

            </ul>

        </>
    )
}

export default SiteHeaderNavbar