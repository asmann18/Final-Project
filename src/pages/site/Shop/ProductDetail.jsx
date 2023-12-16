import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import StarIcon from '@mui/icons-material/Star';
import StarBorderIcon from '@mui/icons-material/StarBorder';
import Loading from '../../../components/Common/Loading';
import '../../../assets/styles/site/Shop.scss';
import { CircularProgress } from '@mui/material';
import { ToastContainer, toast } from 'react-toastify';
  import 'react-toastify/dist/ReactToastify.css';
import CommentArea from '../../../components/site/Shop/CommentArea';
import Rating from '@mui/material/Rating';
import Typography from '@mui/material/Typography';


const ProductDetail = () => {
  const { id } = useParams();
  const [product, setProduct] = useState(null);
  const [isLoading, setIsLoading] = useState(false);
  const [basketCount, setBasketCount] = useState(1);
  const[addBasketLoading,setAddBasketLoading]=useState(false)
  const notify = () => toast.success("Səbətə uğurla əlavə olundu");

  useEffect(() => {
    axios.get("https://localhost:7066/api/Products/GetProductById/" + id).then(res => {
      setProduct(res.data.data)
      setIsLoading(true);
      setBasketCount(1)
    }).catch(e=>{
      console.log(e);
    })
  }, [id])
  function Increase() {
    if (basketCount < product.count) {

      setBasketCount(basketCount + 1)
    }
  }
  function Decrease() {
    if (basketCount > 1) {

      setBasketCount(basketCount - 1)
    }
  }

const AddToBasket=async (e)=>{
  e.preventDefault()
  try{
    setAddBasketLoading(true)
    notify()
    axios.post('https://localhost:7066/api/BasketItems/AddToBasket',{productid:id,count:basketCount})
    setTimeout(async () => {
      setAddBasketLoading(false);
    }, 1000);
  }  
  catch(e){
    console.log(e)
  }
}

  return (
    isLoading ? <div className='productDetail'>
      <ToastContainer />

      <div className="detailName">
        <h2>{product.name}</h2>
        <p>Brand:{product.brand.name}</p>
      </div>
      <div className="detailBody">
        <div className="detailImages">
          {product.productImagePaths.map((path, i) => {
           
            return (
              <div key={i} className={i === 0 ? "productImageMain" : "productImage"}>
                <img src={path} alt="productImage" />
              </div>
            )
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
                <div className="starts">

                  {/* {Array.from({ length: product.rating }, (v, i) => (<StarIcon key={i} />))}
                  {product.rating == 0 ?


                    <>
                      <StarBorderIcon />
                      <StarBorderIcon />
                      <StarBorderIcon />
                      <StarBorderIcon />
                      <StarBorderIcon />
                    </>
                    : ""


                  } */}

      <Rating name="read-only" value={product.rating} readOnly />
                </div>
              </div>
              <div className="count">
                <p>Mövcudluq:</p>
                {product.count > 0 ? <span className='countTrue'>Mövcuddur</span> : <span className='countFalse'>Mövcud deyil :(</span>}
              </div>
              <div className="basketCount">
                <p>Sayı:</p>
                <div className="input">
                  <button onClick={Decrease} >-</button>
                  <span>{basketCount}</span>
                  <button onClick={Increase}>+</button>
                </div>
              </div>
              <div className="buy">
              <button  onClick={AddToBasket} disabled={addBasketLoading || product.count==0 }>
            {addBasketLoading ? <CircularProgress className='loading'/> : "Almaq"}
          </button>
              </div>
            </div>
          </div>
          <div className="detailInfoBottom">
            <p>{product.description}</p>
          </div>
        </div>
      </div>
      <CommentArea  />  
    </div> : <Loading />
  )
}

export default ProductDetail