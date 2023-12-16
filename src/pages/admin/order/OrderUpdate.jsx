import { Try } from '@mui/icons-material'
import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const OrderUpdate = () => {
    const [order, setOrder] = useState(null)
    const { id } = useParams()
    const[refresh,setRefresh]=useState(0)
    const history = useNavigate()
    useEffect(() => {
        axios.get(`https://localhost:7066/api/Orders/GetOrderById/${id}`).then(res => {
            setOrder(res.data.data)
        }).catch(e => console.log(e))
    }, [refresh])

        const handleStatus=async ()=>{

            try{

                const response=await axios.put(`https://localhost:7066/api/Orders/ChangeOrderStatus/${id}`)
                const data=response.data.data
                setRefresh(refresh+1)
            }catch(e){
                console.log(e);
            }

        }

        const handleStatusReverse=async ()=>{

            try{

                const response=await axios.put(`https://localhost:7066/api/Orders/ChangeOrderStatusReverse/${id}`)
                const data=response.data.data
                setRefresh(refresh+1)
            }catch(e){
                console.log(e);
            }

        }

        const deleteOrder=async()=>{
            try{

                const response=await axios.delete(`https://localhost:7066/api/Orders/DeleteOrder/${id}`)
                const data=response.data.data
                setRefresh(refresh+1)
                console.log(data);
            }catch(e){
                console.log(e);
            }
        }
    return (
        <div className='adminPanelDetail productDetail'>{order ? (<div className="part">
            <div className="info">

                <p>Customer:{order.createdBy}</p>
                <p>Location:{order.location ? order.location : "Mağazadan götürmə"}</p>
                <p>Total Price:{order.totalPrice}$</p>
            </div>
           
            <table className='orderProductsList'>

              <thead className='columns'>
                <th>Img</th>
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

            <h5>Status :{order.isDeleted === true ? "Ləğv edilib" : order.isStatus ? "Çatdırlıb" : order.isStatus === false ? "Sifariş edilib" : "Yoldadır" }</h5>
            <div className="button">
                <button className='btn btn-danger' onClick={deleteOrder} >{order.isDeleted? "Bərpa et":"Ləğv et"}</button>
                <button className='btn btn-warning' onClick={handleStatusReverse}>Geri çək</button>
                <button className='btn btn-success' onClick={handleStatus}>Keçid et</button>
                <button onClick={() => history(-1)} className='btn btn-primary'>Back</button>
            </div>

        </div>) : ""}</div>
    )
}

export default OrderUpdate