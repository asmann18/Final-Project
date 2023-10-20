import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import Error from '../../error/Error'

const ProductDelete = () => {
  const { id } = useParams()

  const [product, setProduct] = useState()
  const history = useNavigate();

  useEffect(() => {

    axios.get(`https://localhost:7066/api/Products/GetProductById/${id}`).then(res => {
      setProduct(res.data.data)
    })
  }, [id])


  const DeleteProduct = () => {
    axios.delete(`https://localhost:7066/api/Products/DeleteProductById/${id}`).then(res => {
      console.log(res.data.data)
    }).catch((e) => { console.log(e) })
    history(-1)
  }
  return (
    <div className='adminPanelDelete productDelete'>
      <h2>Product Delete</h2>
      {product ? (<div className="product">
        <div className="info">
          <div className="img">
            <img src={product.productImagePaths[0]} alt="productImage" />
          </div>
          <p>{product.name}</p>
          <span>{product.price}</span>
        </div>
        <div className="action">
          <p>Bu məhsulu silmək istəyirsiniz?</p>
          <div className="buttons">
            <button onClick={DeleteProduct} className='btn btn-danger'>Delete</button>
            <button onClick={() => history(-1)} className='btn btn-primary'>Back</button>
          </div>
        </div>
      </div>) : <Error />}

    </div>
  )
}

export default ProductDelete