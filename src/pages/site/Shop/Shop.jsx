import React, { useEffect, useState } from 'react'
import axios from 'axios'
import { Link, useLocation } from 'react-router-dom'
import BannerSlider from '../../../components/site/Common/BannerSlider'
import NotFound from '../../../components/site/Common/NotFound'
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const Shop = (toastify) => {
  const [categories, setCategories] = useState([])
  const [products, setProducts] = useState([{ id: 1, name: "hu", productImagePaths: ["hi"] }])
  const [active, setActive] = useState(1)
  const [aromas, setAromas] = useState([])
  const [brands, setBrands] = useState([])
  const [aromaId, setAromaId] = useState()
  const [brandId, setBrandId] = useState()
  const [fromPrice, setFromPrice] = useState()
  const [toPrice, setToPrice] = useState()
  const [fromRating, setFromRating] = useState()
  const [toRating, setToRating] = useState()
  const location=useLocation()
  const notify = () => toast.success("Sifarişiniz qeydə alındı,sizinlə əlaqə saxlanılacaq!");
  
  
  
  const [activeCategoryId, setActiveCategoryId] = useState(1)
  
  useEffect(() => {
    
    console.log({toastify});
    if (toastify===true) {
      notify();
    }




    axios.get('https://localhost:7066/api/ProductCategories/GetAllProductCategories').then(res => {
      setCategories(res.data.data)
      axios.get(`https://localhost:7066/api/ProductCategories/GetAllProductsInCategoryById/${res.data.data[0].id}`).then(response => {
        setProducts(response.data.data)
      }).catch(e => {
        console.log(e)
      })
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


  }, [location,toastify])

  const SwitchProducts = async (e, id) => {
    e.preventDefault()
    try {
      axios.get(`https://localhost:7066/api/ProductCategories/GetAllProductsInCategoryById/${id}`).then(response => {
        setProducts(response.data.data)
        setActive(id)
        setActiveCategoryId(id)
      }).catch(e => {
        console.log(e)
      })

    } catch (e) {
      console.log(e)
    }
  }

  const ResetProducts = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.get(`https://localhost:7066/api/ProductCategories/GetAllProductsInCategoryById/${activeCategoryId}`)
      setProducts(response.data.data)
      setActive(activeCategoryId)
      setAromaId(null)
      setBrandId(null)
      setFromPrice(null)
      setToPrice(null)
      setFromRating(null)
      setToRating(null)

    } catch (e) {
      console.log(e);
    }
  }

  const FilterProducts = async (e) => {
    e.preventDefault()
    try {
      const formData = new FormData
      formData.append("categoryid", active)
      formData.append("brandid", brandId)
      formData.append("aromaid", aromaId)
      formData.append("fromprice", fromPrice)
      formData.append("toprice", toPrice)
      formData.append("fromrating", fromRating)
      formData.append("torating", toRating)
      console.log({ formData })
      const response = await axios.post("https://localhost:7066/api/Products/FilteredProducts", {
        brandId, aromaId, fromPrice, toPrice, fromRating, toRating, "categoryId": active
      })
      // const response = await axios.post("https://localhost:7066/api/Products/FilteredProducts", formData, {
      //   headers: {
      //     'Content-Type': 'application/json',
      //   },
      // });
      setProducts(response.data.data)
    } catch (e) {
      setProducts([])
      console.log(e)
    }
  }
  return (

    <div className='shopPage'>
      <ToastContainer />
      <BannerSlider content={"MAĞAZA"} />
      <div className="shopTable">
        <ul className="columns">
          {categories.map((category, i) => {
            return <li className={category.id === active ? 'active' : ""} onClick={(e) => {
              SwitchProducts(e, category.id)
            }} key={i}>{category.name}</li>
          })}
        </ul>
        <ul className="rows">
          {products.length > 0 ? products.map((product, i) => {
            return (<Link to={`/productDetail/${product.id}`} key={i} className="product">
              <div className="image">
                <img src={product.productImagePaths[0]} alt="" />
              </div>
              <div className="productInfo">

                <p>{product.name}</p>
                <span>{product.price}$</span>
              </div>
            </Link>)
          }) : <NotFound />}
        </ul>
        <form action='post' className="filters">

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
          <div className="inputGroup">
            <input type="number" id='fromPrice' value={fromPrice} onChange={(e) => { setFromPrice(e.target.value) }} placeholder='Min Qiymət' />
            <input type="number" id='toPrice' value={toPrice} onChange={(e) => { setToPrice(e.target.value) }} placeholder='Max Qiymət' />
          </div>
          <div className="inputGroup">
            <input type="number" id='fromRating' value={fromRating} onChange={(e) => { setFromRating(e.target.value) }} placeholder='Min Rating' />
            <input type="number" id='toRating' value={toRating} onChange={(e) => { setToRating(e.target.value) }} placeholder='Max Rating' />
          </div>

          <button onClick={FilterProducts} className='btn btn-success'>Filterlə</button>
          <button onClick={ResetProducts} className='btn btn-secondary'>Sıfırla</button>

        </form>
      </div>

    </div>
  )
}

export default Shop