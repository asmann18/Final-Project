import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const ProductsDetail = () => {

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
  const [productCategoryId, setProductCategoryId] = useState("");
  const [brandId, setBrandId] = useState(0);
  const [aromaId, setAromaId] = useState(0);
  const [productImagesF, setProductImagesF] = useState([]);

  const [brand, setBrand] = useState()
  const [aroma,setAroma]=useState()
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
        setBrandId(res.data.data.brandId);
        setAromaId(res.data.data.aromaId);
        setProductImagesF(res.data.data.productImagePaths)
        console.log(res.data.data)


        axios
          .get(`https://localhost:7066/api/Brands/GetBrandById/${res.data.data.brandId}`)
          .then((brandRes) => {
            setBrand(brandRes.data.data);
          })
          .catch((brandErr) => {
            console.log(brandErr);
          });


          axios
          .get(`https://localhost:7066/api/Aromas/GetAromaById/${res.data.data.aromaId}`)
          .then((aromaRes) => {
            setAroma(aromaRes.data.data);
          })
          .catch((aromaErr) => {
            console.log(aromaErr);
          });


      })
      .catch((err) => {
        console.log(err);
      });



  }
    , [id]);
  return (
    <div className='adminPanelDetail productDetail'>
      <div className="product">
        <img src={productImagesF ? productImagesF[0] : ""} alt="product" />
        <h2>{name}</h2>
        <p>{description}</p>
        <div className="counts">
          <span>Price: {price}</span>
          <span>Count: {count}</span>
          <span>Discount: {discount}</span>
        </div>
        <div className="relations">

        <p>Brand: {brand ? brand.name : ""}</p>
        <p>Aroma: {aroma ? aroma.name : ""}</p>
        </div>
        <button onClick={() => history(-1)} className='btn btn-primary'>Back</button>

      </div>
    </div>
  )
}

export default ProductsDetail