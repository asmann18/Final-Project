import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

const ProductsCreate = () => {
  const [name, setName] = useState("")
  const [description, setDescription] = useState("")
  const [price, setPrice] = useState(null)
  const [count, setCount] = useState(null)
  const [discount, setDiscount] = useState(null)
  const [productCategoryId, setProductCategoryId] = useState(null)
  const [brandId, setBrandId] = useState(null)
  const [aromaId, setAromaId] = useState(null)
  const [productImagesF, setProductImagesF] = useState([])

  const history = useNavigate();
  const [tokenData, setTokenData] = useState([])


  useEffect(() => {
    setTokenData(JSON.parse(localStorage.getItem("tokenData")));
  }, [])

  const [categories, setCategories] = useState([])
  const [aromas, setAromas] = useState([])
  const [brands, setBrands] = useState([])
  useEffect(() => {
    axios.get('https://localhost:7066/api/ProductCategories/GetAllProductCategories').then(res => {
      setCategories(res.data.data)
    }).catch(e => {
      console.log(e)
    })
    axios.get('https://localhost:7066/api/Brands/GetAllBrands').then(res => {
      setBrands(res.data.data)
    }).catch(e => {
      console.log(e)
    })
    axios.get('https://localhost:7066/api/Aromas/GetAllAromas').then(res => {
      setAromas(res.data.data)
    }).catch(e => {
      console.log(e)
    })
  }, [])
  const url = 'https://localhost:7066/api/Products/CreateProduct'
  const handleCreate = async (e) => {
    e.preventDefault();
    try {


      const formData = new FormData();
      formData.append("name", name);
      formData.append("description", description);
      formData.append("price", price);
      formData.append("count", count);
      formData.append("discount", discount);
      formData.append("productcategoryid", productCategoryId);
      formData.append("brandid", brandId);
      formData.append("aromaId", aromaId);
      productImagesF.forEach((file) => {
        formData.append(`productimagesf`, file, file.name);
      });

      const response = await axios.post(url, formData, {
        headers: {
          'Authorization': `Bearer ${tokenData.token}`
        }
      });


      console.log(response.data)
      history(-1)


    } catch (error) {
      console.log(error.response)
    }


  }



  return (
    <div className="AdminPanelForm">
      <h2>Create new Product</h2>
      <form action='post' encType='multipart/form-data' className='productCreate adminCreate'>

        <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />
        <input type="text" id='description' value={description} onChange={(e) => { setDescription(e.target.value) }} placeholder='Açıqlama daxil edin' />
        <input type="number" id='price' value={price} onChange={(e) => { setPrice(e.target.value) }} placeholder='Qiymet daxil edin' />
        <input type="number" id='count' value={count} onChange={(e) => { setCount(e.target.value) }} placeholder='Miqdar daxil edin' />
        <input type="number" id='discount' value={discount} onChange={(e) => { setDiscount(e.target.value) }} placeholder='Endirim daxil edin' />
        <select name="ProductCategoryId" id="categoryId" value={productCategoryId} onChange={(e) => setProductCategoryId(e.target.value)}>
          <option value="">Kategoriya seçin</option>
          {categories.map((category, i) => {
            return <option key={i} value={category.id}>{category.name}</option>
          })}
        </select>

        <select name="BrandId" id="brandId" value={brandId} onChange={(e) => setBrandId(e.target.value)}>
          <option value="">Brand seçin</option>
          {brands.map((brand, i) => {
            return <option key={i} value={brand.id}>{brand.name}</option>
          })}
        </select>

        <select name="AromaId" id="aromaId" value={aromaId} onChange={(e) => setAromaId(e.target.value)}>
          <option value="">Aroma seçin</option>
          {aromas.map((aroma, i) => {
            return <option key={i} value={aroma.id}>{aroma.name}</option>
          })}
        </select>

        <input type="file" multiple id='productImagesF' onChange={(e) => { setProductImagesF(Array.from(e.target.files)) }} />


        <button onClick={handleCreate} type='submit'>
          Create
        </button>

      </form>
    </div>
  )
}

export default ProductsCreate