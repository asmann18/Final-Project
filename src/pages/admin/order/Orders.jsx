import axios from 'axios'
import React, { useEffect, useState } from 'react'
import AdminPanelTable from '../../../components/Common/AdminPanelTable'

const Orders = () => {



  const [orders, setOrders] = useState([])
  useEffect(() => {
    axios.get('https://localhost:7066/api/Orders/GetAllOrders').then(res => {
      setOrders(res.data.data)
    }).catch(e => {
      console.log(e);
    })
  }, [])



  let rows = []
  const columns = [
    { id: "id", label: "Id", minWidth: 20, maxWidth: 200 },
    {id:"user",label:"User",minWidth:20,maxWidth:200},
    { id: "location", label: "Location", minWidth: 20, maxWidth: 200 },
    { id: "status", label: "Status", minWidth: 20, maxWidth: 200 },
    { id: "buttons", label: "Actions", minWidth: 20, maxWidth: 200 },
  ];
  orders.map((order) => {
    rows.push({ id: order.id,user:order.createdBy , location:  order.location ? order.location : "Mağazadan götürmə" , status: order.isDeleted === true ? "Ləğv edilib" : order.isStatus ? "Çatdırlıb" : order.isStatus === false ? "Sifariş edilib" : "Yoldadır", buttons: { update: `/admin/orders/update/${order.id}`} })
    
  })

  return (

    <div className='productCategories adminList'>
      <div className="listInfo">
        <h2>Orders</h2>
      </div>
      <ul className='list'>
        <AdminPanelTable Rows={rows} Columns={columns} />
      </ul>

    </div>
  )
}

export default Orders