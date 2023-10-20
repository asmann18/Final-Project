import React, { useEffect, useState } from 'react'
import Header from '../../../layout/admin/Header/Header'
import { Outlet, useParams } from 'react-router-dom'
import Error from '../../error/Error'
const AdminRoot = () => {
    const {root}=useParams()
  const [role,setRole]=useState("")
  useEffect(()=>{
    const tokenData = localStorage.getItem("tokenData");
    if (tokenData) {
        const parsedTokenData = JSON.parse(tokenData);
        setRole(parsedTokenData.role);
    } else {
        setRole("");
    }
  },[])

  const Access = role === "Admin" || role === "Moderator";
    return (
        
        Access? < > <Header root={root} />
            <Outlet /></> :<Error/>
        
           

        
    )
}

export default AdminRoot