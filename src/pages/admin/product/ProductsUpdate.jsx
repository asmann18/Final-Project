import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
const ProductsUpdate = () => {
  
    const { id } = useParams();
    const [product, setProduct] = useState({
      name: "",
      description: "",
      price: 0,
      count: 0,
      discount: 0,
      productcategoryid: "",
      brandid: "",
      aromaid: "",
    });
  
    const history = useNavigate();
    const [tokenData, setTokenData] = useState([]);
  
    useEffect(() => {
      setTokenData(JSON.parse(localStorage.getItem("tokenData")));
    }, []);
  
    const [name, setName] = useState(""); 
    const [description, setDescription] = useState("");
    const [price, setPrice] = useState(0);
    const [count, setCount] = useState(0);
    const [discount, setDiscount] = useState(0);
    const [productCategoryId, setProductCategoryId] = useState(0);
    const [brandId, setBrandId] = useState(0);
    const [aromaId, setAromaId] = useState(0);
    const [productImagesF, setProductImagesF] = useState([]);
  
    useEffect(() => {
      axios
        .get(`https://localhost:7066/api/Products/GetProductById/${id}`)
        .then((res) => {
          setProduct(res.data.data);
          setName(res.data.data.name);
          setDescription(res.data.data.description);
          setPrice(res.data.data.price);
          setCount(res.data.data.count);
          setDiscount(res.data.data.discount);
          setProductCategoryId(res.data.data.productcategoryid);
          setBrandId(res.data.data.brandid);
          setAromaId(res.data.data.aromaid);
        })
        .catch((err) => {
          console.log(err);
        });
    }, [id]);


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
  const url = 'https://localhost:7066/api/Products/UpdateProduct'
  const handleCreate = async (e) => {
    e.preventDefault();
    try {
      console.log({productImagesF})
      console.log('hi')
      
      const formData = new FormData();

      formData.append("id", id);
     
      formData.append("name", name);
      formData.append("description", description);
      formData.append("price", price);
      formData.append("count", count);
      formData.append("discount", discount);
      formData.append("productcategoryid", productCategoryId);
      formData.append("brandid", brandId);
      formData.append("aromaId", aromaId);
      productImagesF.forEach((file) => {
        formData.append(`productimagesf`, file,file.name);
      });
      console.log(Array.from(formData))
      console.log(tokenData)
      const response = await axios.put(url, formData, {
        headers: {
          'Authorization': `Bearer ${tokenData.token}`
        }
      });


      console.log(response.data)
      history(-1)


      console.log(response.data)

    } catch (error) {
      console.log(error.response)
    }


  }



  return (
    <div className="AdminPanelForm">
      <h2>Update Product {id} </h2>
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
          Update
        </button>

      </form>
    </div>
  )
}

export default ProductsUpdate