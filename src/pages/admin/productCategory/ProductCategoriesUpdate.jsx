import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const ProductCategoriesUpdate = () => {
const {id}=useParams();
const [category,setCategory]=useState({name:"",description:""})
const history=useNavigate()

const [name, setName] = useState(""); 
const [description, setDescription] = useState("");

useEffect(()=>{
    axios.get(`https://localhost:7066/api/ProductCategories/GetAllProductsInCategoryById/${id}`).then(res=>{
        setCategory(res.data.data)
        setName(res.data.data.name)
        setDescription(res.data.data.description)
        console.log(res.data)

    }).catch=(err)=>{
        console.log(err)
    }
},[])

const url='https://localhost:7066/api/ProductCategories/PutProductById';
const updateCategory=async (e)=>{
    e.preventDefault();
    try{
        const response=await axios.put(url,{id,name,description})
        console.log(response.data);
    }catch(err){
        console.log(err);
    }
}
  return (
    <div className="AdminPanelForm">
    <h2>Create new Product Category</h2>
    <form action='post'  className='productCreate adminCreate'>

        <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />
        <input type="text" id='description' value={description} onChange={(e) => { setDescription(e.target.value) }} placeholder='Açıqlama daxil edin' />


        <button onClick={updateCategory} type='submit'>
            Create
        </button>

    </form>
</div>
  )
}

export default ProductCategoriesUpdate