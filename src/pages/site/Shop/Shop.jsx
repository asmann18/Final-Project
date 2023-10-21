import React, { useEffect, useState } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom'
import BannerSlider from '../../../components/site/Common/BannerSlider'

const Shop = () => {
  const [categories, setCategories] = useState([])
  const [products, setProducts] = useState([{ id: 1, name: "hu", productImagePaths: ["hi"] }])
  const [active,setActive]=useState(1)
  useEffect(() => {
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



  }, [])

  const SwitchProducts = async (e, id) => {
    e.preventDefault()
    try {
      axios.get(`https://localhost:7066/api/ProductCategories/GetAllProductsInCategoryById/${id}`).then(response => {
        setProducts(response.data.data)
        setActive(id)
      }).catch(e => {
        console.log(e)
      })

    } catch (e) {
      console.log(e)
    }
  }


  return (

    <div className='shopPage'>

<BannerSlider content={"MAĞAZA"} />
      <div className="shopTable">
        <ul className="columns">
          {categories.map((category, i) => {
            return <li className={category.id===active ? 'active':""  } onClick={(e) => {
              SwitchProducts(e, category.id)
            }} key={i}>{category.name}</li>
          })}
        </ul>
        <ul className="rows">
          {products.map((product, i) => {
            return (<Link to={`/productDetail/${product.id}`} key={i} className="product">
              <div className="image">
                <img src={product.productImagePaths[0]} alt="" />
              </div>
              <div className="productInfo">

                <p>{product.name}</p>
                <span>{product.price}$</span>
              </div>
            </Link>)
          })}
        </ul>
      </div>

    </div>
  )
}

export default Shop