import axios from 'axios'
import React, { useEffect, useState } from 'react'
import CartEmpty from './CartEmpty'
import PlayArrowIcon from '@mui/icons-material/PlayArrow';
import Accardion from '../../Common/Accardion';
import CircleIcon from '@mui/icons-material/Circle';
const OrderTable = () => {


  const [token, setToken] = useState(localStorage.getItem("tokenData"))
  const [orders, setOrders] = useState([])
  useEffect(() => {
    axios.defaults.headers.common['Authorization'] = "Bearer " + JSON.parse(token).token;
    axios.get('https://localhost:7066/api/Orders/GetUserOrders').then(res => {
      setOrders(res.data.data)
      console.log(res.data.data)
    }).catch(e => {
      console.log(e)
    })

  }, [])

  return (
    <div className='orderTable'>

      {orders.length === 0 ? <CartEmpty /> :

        orders.map((order, i) => {
          return <Accardion title={<div key={i} className="order">
            <p>
              <strong>
                Sifariş No:
              </strong>
              {order.id} 
            </p>
            <p>{order.totalPrice}$</p>
            <p>{order.location? order.location : "Mağazadan təhvil"}</p>
            <p>
              <strong>
                Tarix:
              </strong>
              {order.createdTime.substring(0, 10)}
            </p>
            <p className='result'>
              {order.isStatus ? <div className="success"><CircleIcon /> Çatdırılıb </div> : order.isStatus === null ? <div className="loading"><CircleIcon /> Yoldadır </div> : <div className="wait"><CircleIcon /> Sifariş olunub</div>}

            </p>
            <p>
              <strong>
                Ətraflı
              </strong>
              <PlayArrowIcon /></p>
          </div>}>

            <table>

              <thead className='columns'>
                <th></th>
                <th>Ad</th>
                <th>Say</th>
                <th>Qiymət</th>
                <th>Cəm</th>
              </thead>
              <tbody className='rows'>
              {order.basketItems.map((bi, i) => {
                  return <tr className="basketItem" key={i}>
                    <td className="img">
                      <img src={bi.product.productImagePaths[0]} alt="" />
                    </td>
                    <td className="name">{bi.product.name}</td>
                    <td className="count">{bi.count}</td>
                    <td className="price">{bi.product.price}</td>
                    <td className="total">{bi.count * bi.product.price}</td>
                  </tr>
                })}


              </tbody>
            </table>
          </Accardion>

        })



      }


    </div>
  )
}

export default OrderTable