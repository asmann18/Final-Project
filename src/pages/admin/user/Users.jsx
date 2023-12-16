import { Category } from '@mui/icons-material'
import axios from 'axios'
import React, { useEffect, useState } from 'react'
import AdminPanelTable from '../../../components/Common/AdminPanelTable'
import { Link } from 'react-router-dom'
const Users = () => {
  const [users,setUsers]=useState([])
  useEffect(()=>{
    axios.get('https://localhost:7066/api/Users/GetAllUsers').then(res=>{
setUsers(res.data.data)
    }).catch((e)=>{
      console.log(e)
    })
  },[])
  let rows=[]
  const columns= [
    { id: "username", label: "Username", minWidth: 20,maxWidth:200 },
    { id: "email", label: "Role", minWidth: 20,maxWidth:200 },
    { id: "role", label: "Role", minWidth: 20,maxWidth:200 },
    { id: "buttons", label: "Actions", minWidth: 20,maxWidth:200 },
];
users.map((user)=>{
  rows.push({username:user.username,email:user.email,role:user.role,buttons:{update:`/admin/users/update/${user.id}`}})
})
  return (
    <div className='productCategories adminList'>
    <div className="listInfo">
    <h2>Users</h2>
    
    </div>
    <ul className='list'>
        <AdminPanelTable Rows={rows} Columns={columns} />
    </ul>
 
</div>
  )
}

export default Users