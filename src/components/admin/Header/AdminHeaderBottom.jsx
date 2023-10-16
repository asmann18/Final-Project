import React, { useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
const AdminHeaderBottom = () => {
  const [selectClass,setSelecClass]=useState('dashboard')
  const navigate = useNavigate();

  const changeColor=(className)=>{
    setSelecClass(className);
  }
  return (
    <div className='adminHeaderBottom'>
        <Link onClick={()=> changeColor('dashboard')} className={selectClass === 'dashboard' ? 'active' : ''} to={"/admin"}>Dashboard</Link>
        <Link onClick={() => changeColor('product')} className={selectClass === 'product' ? 'active' : ''} to={"/admin/products"}>Products</Link>
        <Link onClick={() => changeColor('productCategory')}  className={selectClass === 'productCategory' ? 'active' : ''} to={"/admin/productCategories"}>Product Categories</Link>
        <Link onClick={() => changeColor('brand')}  className={selectClass === 'brand' ? 'active' : ''} to={"/admin/brands"}>Brands</Link>
        <Link onClick={() => changeColor('aroma')}  className={selectClass === 'aroma' ? 'active' : ''} to={"/admin/aromas"}>Aromas</Link>

        <Link onClick={() => changeColor('blog')}  className={selectClass === 'blog' ? 'active' : ''} to={"/admin/blogs"}>Blogs</Link>
        <Link onClick={() => changeColor('blogCategory')}  className={selectClass === 'blogCategory' ? 'active' : ''} to={"/admin/blogCategories"}>Blog Categories</Link>

        <Link onClick={() => changeColor('part')}  className={selectClass === 'part' ? 'active' : ''} to={"/admin/parts"}>Parts</Link>
        <Link onClick={() => changeColor('move')}  className={selectClass === 'move' ? 'active' : ''} to={"/admin/moves"}>Moves</Link>
    </div>
  )
}

export default AdminHeaderBottom