import axios from 'axios';
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';

const ProductCategoriesCreate = () => {
    const [name, setName] = useState("")
    const [description, setDescription] = useState("")
    const url = 'https://localhost:7066/api/ProductCategories/CreateProductCategory';
    const history = useNavigate();
    const createCategory = async (e) => {
        e.preventDefault();
        try {
          
            const response = await axios.post(url, {
                'name':name,
                'description':description
            })
           
            history(-1);

        } catch (error) {
            console.log(error)
        }
    }
    return (
        <div className="AdminPanelForm">
            <h2>Create new Product Category</h2>
            <form action='post'  className='productCreate adminCreate'>

                <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />
                <input type="text" id='description' value={description} onChange={(e) => { setDescription(e.target.value) }} placeholder='Açıqlama daxil edin' />


                <button onClick={createCategory} type='submit'>
                    Create
                </button>

            </form>
        </div>
    )
}

export default ProductCategoriesCreate