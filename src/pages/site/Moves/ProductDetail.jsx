import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import StarIcon from '@mui/icons-material/Star';
import Loading from '../../../components/Common/Loading';
import '../../../assets/styles/site/Moves.scss';

const ProductDetail = () => {
  const {id}=useParams();
  const[product,setProduct]=useState(null);
  const [isLoading,setIsLoading]=useState(false);
  const[basketCount,setBasketCount]=useState(1);
  useEffect(()=>{
    axios.get("https://localhost:7066/api/Products/GetProductById/"+id).then(res=>{
      setProduct(res.data.data)
      setIsLoading(true);
      console.log(product)
    })
  },[])
  function Increase(){
    if(basketCount<product.count){

      setBasketCount(basketCount+1)
    }
  }
  function Decrease(){
    if(basketCount>0){

      setBasketCount(basketCount-1)
    }
  }
  return (
  isLoading ?   <div className='productDetail'>
  <div className="detailName">
  <h2>{product.name}</h2>
    <p>Brand:{product.brand.name}</p>
  </div>
  <div className="detailBody">
    <div className="detailImages">
      {product.productImagePaths.map((path,i)=>{
  
  return (<img src={path} alt="productImage" />)
      })}
    </div>
    <div className="detailInfo">
      <div className="detailInfoTop">
        <div className="detailInfoTopLeft">
          <h2>{product.price}$</h2>
        </div>
        <div className="detailInfoTopRight">
          <div className="rating">
            <p>Rating:</p>
            {Array.from({ length: product.rating }, (v, i) => (<StarIcon key={i} />))}
          </div>
          <div className="count">
            <p>Mövcudluq</p>
            <span>{product.count>0 ? "Mövcuddur" : "Mövcud deyil :(" }</span>
          </div>
          <div className="basketCount">
            <p>Sayı</p>
            <div className="input">
            <button onClick={Decrease} >-</button>
            <span>{basketCount}</span>
            <button onClick={Increase}>+</button>
            </div>
          </div>
          <div className="buy">
            <button>Almaq</button>
          </div>
        </div>
      </div>
      <div className="detailInfoBottom">
        <p>{product.description}</p>
      </div>
    </div>
  </div>
</div> : <Loading/>
  )
}

export default ProductDetail