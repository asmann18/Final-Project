import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
const ProductsUpdate = () => {
const {id}=useParams();
const [product,setProduct]=useState({})
useEffect(()=>{
axios.get(`https://localhost:7066/api/Products/GetProductById/${id}`).then(res=>{
setProduct(res.data.data)
}).catch(err=>{
  console.log(err)
})
},[])

  const [name, setName] = useState(product.name)
  const [description, setDescription] = useState(product.description)
  const [price, setPrice] = useState(product.price)
  const [count, setCount] = useState(product.count)
  const [discount, setDiscount] = useState(product.discount)
  const [productCategoryId, setProductCategoryId] = useState(product.productcategoryid)
  const [brandId, setBrandId] = useState(product.brandid)
  const [aromaId, setAromaId] = useState(product.aromaid)
  const [productImagesF, setProductImagesF] = useState([])


  const [categories, setCategories] = useState([])
  const [aromas, setAromas] = useState([])
  const [brands, setBrands] = useState([])
  useEffect(() => {
    axios.get('https://localhost:7066/api/ProductCategories/GetAllProductCategories').then(res => {
      setCategories(res.data.data)
    })
    axios.get('https://localhost:7066/api/Brands/GetAllBrands').then(res => {
      setBrands(res.data.data)
    })
    axios.get('https://localhost:7066/api/Aromas/GetAllAromas').then(res => {
      setAromas(res.data.data)
    })
  }, [])
  const url = 'https://localhost:7066/api/Products/CreateProduct'
  const handleCreate = async (e) => {
    e.preventDefault();
    try {
      console.log({productImagesF})
      console.log('hi')
      
      const formData = new FormData();
      formData.append("name", name);
      formData.append("description", description);
      formData.append("price", price);
      formData.append("count", count);
      formData.append("discount", discount);
      formData.append("productcategoryid", productCategoryId);
      formData.append("brandid", brandId);
      formData.append("aromaId", aromaId);
      productImagesF.forEach((file, index) => {
        formData.append(`productimagesf[${index}]`, JSON.stringify(file));
      });
      console.log({formData})
      const response = await axios.post(url, formData, {
        method: "POST",
        headers: {
                'Content-Type': 'multipart/form-data; charset=utf-8; boundary="another cool boundary";'
        },
        body: formData,
      });


      // const response=axios.post(url,{
      //   'name':name,
      //   'description':description,
      //   'price':price,
      //   'count':count,
      //   'discount':discount,
      //   'productcategoryid':productCategoryId,
      //   'brandid':brandId,
      //   'aromaid':aromaId,
      //   'productimagesf[...productimagesf]':productImagesF
      // },{headers:{
      //   'Content-Type': 'multipart/form-data'
      // }})


      console.log(response.data)

    } catch (error) {
      console.log(error.response)
    }


  }



  return (
    <div className="AdminPanelForm">
      <h2>Create new Product {id} </h2>
      <form action='post' encType='multipart/form-data' className='productCreate adminCreate'>

        <input type="text" id='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Ad daxil edin' />
        <input type="text" id='description' value={description} onChange={(e) => { setDescription(e.target.value) }} placeholder='Açıqlama daxil edin' />
        <input type="number" id='price' value={price} onChange={(e) => { setPrice(e.target.value) }} placeholder='Qiymet daxil edin' />
        <input type="number" id='count' value={count} onChange={(e) => { setCount(e.target.value) }} placeholder='Miqdar daxil edin' />
        <input type="number" id='discount' value={discount} onChange={(e) => { setDiscount(e.target.value) }} placeholder='Endirim daxil edin' />
        <select name="ProductCategoryId" id="categoryId" value={productCategoryId} onChange={(e) => setProductCategoryId(e.target.value)}>
          <option  value="">Kategoriya seçin</option>
          {categories.map((category, i) => {
            return <option key={i} value={category.id}>{category.name}</option>
          })}
        </select>

        <select name="BrandId" id="brandId" value={brandId} onChange={(e) => setBrandId(e.target.value)}>
          <option  value="">Brand seçin</option>
          {brands.map((brand, i) => {
            return <option key={i} value={brand.id}>{brand.name}</option>
          })}
        </select>

        <select name="AromaId" id="aromaId" value={aromaId} onChange={(e) => setAromaId(e.target.value)}>
          <option  value="">Aroma seçin</option>
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

export default ProductsUpdate