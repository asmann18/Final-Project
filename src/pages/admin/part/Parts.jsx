import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import AdminPanelTable from '../../../components/Common/AdminPanelTable'

const Parts = () => {

  const [parts, setParts] = useState([])
  useEffect(() => {
    axios.get('https://localhost:7066/api/Parts/GetAllParts').then(res => {
      setParts(res.data.data)
    }).catch(e => {
      console.log(e)
    })
  }, [])

  let rows = []
  const columns = [
    { id: "id", label: "Id", minWidth: 20, maxWidth: 200 },
    { id: "image", label: "Image", minWidth: 20, maxWidth: 200 },
    { id: "name", label: "Name", minWidth: 20, maxWidth: 200 },
    { id: "buttons", label: "Actions", minWidth: 20, maxWidth: 200 },
  ];
  parts.map((part) => {
    rows.push({ id: part.id, image:part.image.path,name: part.name, buttons: { detail: `/admin/parts/${part.id}`, update: `/admin/parts/update/${part.id}`, delete: `/admin/parts/delete/${part.id}` } })
  })


  return (
    <div className='productCategories adminList'>
      <div className="listInfo">
        <h2>Parts</h2>
        <div className="add">
          <Link className='btn btn-success' to={"create"}>Create</Link>
        </div>
      </div>
      <ul className='list'>
        <AdminPanelTable Rows={rows} Columns={columns} />
      </ul>

    </div>
  )
}

export default Parts