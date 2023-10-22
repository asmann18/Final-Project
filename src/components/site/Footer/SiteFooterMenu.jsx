import React from 'react'
import { Link } from 'react-router-dom'
const SiteFooterMenu = () => {
  return (
    <div className="menu">
    <h3>Menu</h3>
    <ul>
        <Link to={"/"}>Əsas Səhifə</Link>
        
        <Link to={"/shop"}>Mağaza</Link>
        <Link to={"/blog"}>Blog</Link>
        <Link to={"moves"}>Məşq Hərəkətləri</Link>
        <Link to={"/contact"}>Əlaqə</Link>
    </ul>
    </div>
  )
}

export default SiteFooterMenu